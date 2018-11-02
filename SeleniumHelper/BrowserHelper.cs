using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using SeleniumHelper.Enums;
using System;

namespace SeleniumHelper
{
    public class BrowserHelper
    {
        public static IWebDriver webDriver;
        public static IWebDriver OpenBrowser(BrowserType browserType, string url, DesiredCapabilities capabilities=null)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    webDriver = new ChromeDriver();
                    webDriver.Manage().Window.Maximize();
                    break;
                case BrowserType.InternetExplorer:
                    webDriver = new InternetExplorerDriver();
                    webDriver.Manage().Window.Maximize();
                    break;
                case BrowserType.MozillaFireFox:
                    webDriver = new FirefoxDriver();
                    break;
                case BrowserType.Safari:
                    webDriver = new SafariDriver();
                    webDriver.Manage().Window.Maximize();
                    break;
                case BrowserType.ChromeOnAndroid:
                    webDriver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
                    break;
            }
            //webDriver.Manage().Timeouts().PageLoad=(System.TimeSpan.FromSeconds(10));
            webDriver.Navigate().GoToUrl(url);
            return webDriver;
        }
    }
}
