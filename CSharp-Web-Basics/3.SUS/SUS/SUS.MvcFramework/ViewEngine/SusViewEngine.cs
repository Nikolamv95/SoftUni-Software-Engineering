using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.CodeAnalysis.Emit;

namespace SUS.MvcFramework.ViewEngine
{
    public class SusViewEngine : IViewEngine
    {
        public string GetHtml(string templateCode, object viewModel, string user)
        {
            //Step 1 - Take the template (templateCode) and generate valid C# code
            string csharpCode = GenerateCSharpFromTemplate(templateCode, viewModel);

            //Step 2 - Generate the csharpCode trough Roslyn in order to give us ExecutableCode
            //We need this IView because it`s an instance of the csharpCode
            //(this class is in the form of a string check GenerateCSharpFromTemplate)
            IView executableObject = GenerateExecutableCode(csharpCode, viewModel);

            //From the executable code get the ready html.
            //We call the ExecuteTemplate method which is inside the csharpCode
            //(the string code in GenerateCSharpFromTemplate method)
            string html = executableObject.ExecuteTemplate(viewModel, user);

            //Return the final html to be shown as a view with Custom functions like Razor @
            return html;
        }

        private string GenerateCSharpFromTemplate(string templateCode, object viewModel)
        {
            string typeOfModel = "object";

            //Check if the view model is null
            if (viewModel != null)
            {
                //Check if the view model is generic type
                if (viewModel.GetType().IsGenericType)
                {
                    //Takes the full name of the view model example -> Dictionary, List etc...
                    var modelName = viewModel.GetType().FullName;

                    //takes the arguments in the generic -> int, string, bool etc....
                    var genericArguments = viewModel.GetType().GenericTypeArguments;

                    //From List`1 which is in the memory we convert it to legit C# object Dictionary<int,int>;
                    typeOfModel = modelName.Substring(0, modelName.IndexOf('`'))
                                  + "<" + string.Join(",", genericArguments.Select(x => x.FullName)) + ">";
                }
                else
                {
                    //if its not generic we just take the full name of the view model
                    typeOfModel = viewModel.GetType().FullName;
                }
            }

            //This is the csharpCode which we send to roslyn. Inside this class we have method ExecuteTemplate which has
            //var model -> the viewModel becomes typeOfModel and the result is written in Model. With Model we can use the 
            //data written in it. Model.Name, Model.Age etc. Razor views @Model;

            //From GetMethodBody we take the legit code which will gave to Roslyn to execute without @;
            string csharpCode = @"
                                    using System;
                                    using System.Text;
                                    using System.Linq;
                                    using System.Collections.Generic;

                                    using SUS.MvcFramework.ViewEngine;

                                    namespace ViewNamespace
                                    {
	                                    public class ViewClass : IView
	                                    {
		                                    public string ExecuteTemplate(object viewModel, string user)
		                                    {
                                                var User = user;
                                                var Model = viewModel as " + typeOfModel + @";
			                                    var html = new StringBuilder();
			                                    
			                                    " + GetMethodBody(templateCode) + @"

                                                return html.ToString();
                                            }
                                        }
                                    }
                                    ";

            return csharpCode;
        }

        private string GetMethodBody(string templateCode)
        {
            //Symbols which interrupt the c# code
            Regex csharpCodeRegex = new Regex(@"[^\""\s&\'\<]+");

            //Supported operators in our code.
            var supportedOperators = new List<string> { "for", "while", "if", "else", "foreach" };

            StringBuilder csharpCode = new StringBuilder();

            //Read the template which we gave from the GenerateCSharpFromTemplate. With StringReader we can read certain text row by row
            StringReader sr = new StringReader(templateCode);

            string line;

            //line takes the current row of the text until is sr is null
            while ((line = sr.ReadLine()) != null)
            {
                //Step 1 - remove the @
                if (supportedOperators.Any(x => line.TrimStart().StartsWith("@" + x)))
                {
                    var atSignLocation = line.IndexOf("@");
                    line = line.Remove(atSignLocation, 1);
                    csharpCode.AppendLine(line);
                }
                else if (line.TrimStart().StartsWith("{") ||
                         line.TrimStart().StartsWith("}"))
                {   //Step 2 - if we have {some code} add it to new line in the code 
                    csharpCode.AppendLine(line);
                }
                else
                {
                    csharpCode.Append($"html.AppendLine(@\"");

                    while (line.Contains("@"))
                    {
                        //We take the first index of @
                        var atSignLocation = line.IndexOf("@");

                        //we take the left side before the first @
                        var htmlBeforeAtSign = line.Substring(0, atSignLocation);

                        //replace all symbols in the left side of the string and append them to the string builder -> csharpCode
                        csharpCode.Append(htmlBeforeAtSign.Replace("\"", "\"\"") + "\" + ");

                        //take the right side of the string
                        var lineAfterAtSign = line.Substring(atSignLocation + 1);

                        //take only the c# code without the regex symbols
                        var code = csharpCodeRegex.Match(lineAfterAtSign).Value;

                        //replace all symbols in the left side of the string and append them to the string builder -> csharpCode
                        csharpCode.Append(code + " + @\"");

                        //overwrite the line with the right side of the string to double check if we have second @ symbol.
                        //if we have second @ do the same process.
                        line = lineAfterAtSign.Substring(code.Length);
                    }

                    csharpCode.AppendLine(line.Replace("\"", "\"\"") + "\");");
                }
            }
            //Return the valid C# code
            return csharpCode.ToString();
        }

        private IView GenerateExecutableCode(string csharpCode, object viewModel)
        {
            //Create ViewAssembly dll with reference to an assembly or standalone module stored in a file.
            //Reads the content of the file into memory.
            var compileResult = CSharpCompilation
                .Create("ViewAssembly")
                .WithOptions(new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary))
                .AddReferences(MetadataReference.CreateFromFile(typeof(object).Assembly.Location))
                .AddReferences(MetadataReference.CreateFromFile(typeof(IView).Assembly.Location));

            //If viewModel is null take all the info where viewModel is stored
            if (viewModel != null)
            {
                if (viewModel.GetType().IsGenericType)
                {
                    var genericArguments = viewModel.GetType().GenericTypeArguments;
                    foreach (var genericArgument in genericArguments)
                    {
                        compileResult = compileResult
                            .AddReferences(MetadataReference.CreateFromFile(genericArgument.Assembly.Location));
                    }
                }

                compileResult = compileResult
                    .AddReferences(MetadataReference.CreateFromFile(viewModel.GetType().Assembly.Location));
            }

            //Take all the packages, libraries and info which dotnet standard contains (Read the code of dotnet standard and take it)
            var libraries = Assembly.Load(new AssemblyName("netstandard")).GetReferencedAssemblies();

            //write all the info from the dotnet standard in to our compileResult
            foreach (var library in libraries)
            {
                compileResult =
                    compileResult.AddReferences(
                        MetadataReference.CreateFromFile(Assembly.Load(library).Location));
            }

            //Produces a syntax tree by parsing the source text.
            compileResult = compileResult.AddSyntaxTrees(SyntaxFactory.ParseSyntaxTree(csharpCode));


            //We create stream to put the IL instruction there and convert them to byte[] in order to create assembly
            using MemoryStream memoryStream = new MemoryStream();
            EmitResult result = compileResult.Emit(memoryStream);

            //If the result is not successful show the ErrorView which we created
            if (!result.Success)
            {
                return new ErrorView(result.Diagnostics
                    .Where(x => x.Severity == DiagnosticSeverity.Error)
                    .Select(x => x.GetMessage()), csharpCode);
            }

            try
            {
                //If the result is successful read the stream from the beginning and write it in to byte []
                memoryStream.Seek(0, SeekOrigin.Begin);
                var byteAssembly = memoryStream.ToArray();

                //Load the byteAssembly
                var assembly = Assembly.Load(byteAssembly);

                //Get the type of the assembly with name "ViewNamespace.ViewClass"
                var viewType = assembly.GetType("ViewNamespace.ViewClass");

                //Create instance of this viewType
                var instance = Activator.CreateInstance(viewType);

                //return the instance as IView and if there is a mistake return the ErrorView
                return (instance as IView) 
                       ?? new ErrorView(new List<string>() { "Instance is null!" }, csharpCode);
            }
            catch (Exception ex)
            {
                return new ErrorView(new List<string>() { ex.ToString() }, csharpCode);
            }
        }
    }
}
