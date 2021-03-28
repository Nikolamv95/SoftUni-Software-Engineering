using System;
using SUS.HTTP;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using SUS.MvcFramework.ViewEngine;

namespace SUS.MvcFramework
{
    public class Controller
    {
        private const string UserIdSessionName = "UserId";
        private SusViewEngine viewEngine;

        public Controller()
        {
            this.viewEngine = new SusViewEngine();
        }
        public HttpRequest Request { get; set; }

        protected HttpResponse View(object viewModel = null,[CallerMemberName]string viewPath = null)
        {
            var viewContent = System.IO.File.ReadAllText("Views/" 
                                                          + this.GetType().Name.Replace("Controller",String.Empty) 
                                                          + "/" 
                                                          + viewPath 
                                                          + ".cshtml");

            viewContent = this.viewEngine.GetHtml(viewContent, viewModel, this.GetUserId());

            var responseHtml = this.PutViewInLayout(viewContent, viewModel);
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        protected HttpResponse File(string filePath, string contentType)
        {
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var response = new HttpResponse(contentType, fileBytes);
            return response;
        }

        protected HttpResponse Redirect(string url)
        {
            var response = new HttpResponse(HttpStatusCode.Found);
            response.Headers.Add(new Header("Location",url));
            return response;
        }

        protected HttpResponse Error(string errorText)
        {
            var viewContent = $"<div class=\"alert alert-danger\" role=\"alert\">{errorText}</div>";
            var responseHtml = this.PutViewInLayout(viewContent);
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes, HttpStatusCode.ServerError);
            return response;
        }

        //Set the userId in to the current session if the user wants to SignIn
        protected void SignIn(string userId)
        {
            this.Request.Session[UserIdSessionName] = userId;
        }

        //Set the null value to the current session if the user wants to SignOut
        protected void SignOut()
        {
            this.Request.Session[UserIdSessionName] = null;
        }

        //Check if the user is signedIn
        protected bool IsUserSignedIn() =>
            this.Request.Session.ContainsKey(UserIdSessionName) &&
            this.Request.Session[UserIdSessionName] != null;

        //Get the user id from the current session
        protected string GetUserId() =>
            this.Request.Session.ContainsKey(UserIdSessionName) ?
                this.Request.Session[UserIdSessionName] : null;

        private string PutViewInLayout(string viewContent, object viewModel = null)
        {
            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");
            layout = layout.Replace("@RenderBody()", "___VIEW_GOES_HERE___");
            layout = this.viewEngine.GetHtml(layout, viewModel, this.GetUserId());
            var responseHtml = layout.Replace("___VIEW_GOES_HERE___", viewContent);

            return responseHtml;
        }

    }
}
