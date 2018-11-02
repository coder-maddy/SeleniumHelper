
using System;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;

namespace SeleniumHelper.Test
{
    [TestFixture]
    public class MobileTest
    {
        public IWebDriver driver;
        //private TouchCapableRemoteWebDriver _driver;
        public MobileTest()
        {

        }

        [Test]
        public void AndroidBrowserTest()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability("browserName", "chrome");
            capabilities.SetCapability("deviceName", "Motorola Moto g");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "7.0");
            
            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities);
            driver.Navigate().GoToUrl("https://facebook.com/");
        }
    }
}
