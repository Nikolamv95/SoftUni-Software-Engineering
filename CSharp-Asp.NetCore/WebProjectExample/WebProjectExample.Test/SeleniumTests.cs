using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace WebProjectExample.Test
{
    public class SeleniumTests
    {
        [Fact]
        public void PElementIsRemovedFromPrivacyPage()
        {
            // Create server with SeleniumServer and startPoint is Startup
            var serverFactory = new SeleniumServerFactory<Startup>();

            // Create options for Chrome and create virtual Web Browser
            var options = new ChromeOptions();
            options.AcceptInsecureCertificates = true;
            options.AddArguments("--headless"); 

            var webDriver = new ChromeDriver(options);

            // Open the address /Home/Privacy on our server (our app)
            webDriver.Navigate().GoToUrl(serverFactory.RootUri + "/Home/Privacy");

            // Find <p>some text</p> element and throw and exception if its not visible.
            // The check will be done after all scripts on the page are loaded
            Assert.Throws<NoSuchElementException>(() => webDriver.FindElementByTagName("p"));
        }
    }
}
