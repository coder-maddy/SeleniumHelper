using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace SeleniumHelper
{
    public static class Extensions
    {
        public static void WaitUntilTrue(this Func<bool> func, int timeOutInSeconds, Func<SeleniumHelperException> exception)
        {
            var ms = DateTime.Now.Add(TimeSpan.FromSeconds(timeOutInSeconds));
            var success = false;
            do
            {
                try
                {
                    success = func?.Invoke() ?? default(bool);
                }
                catch (Exception)
                {
                    success = false;
                }
            } while (!((ms < DateTime.Now) || success));
            if (!success)
            {
                exception();
            }
        }

        public static IReadOnlyList<IWebElement> Childerns(this IWebElement webElement)
        {
            IReadOnlyList<IWebElement> childs = webElement.FindElements(By.XPath("./*"));
            return childs;
        }

        public static IWebElement Ancestor(this IWebElement webElement)
        {
            var ancestor = webElement.FindElement(By.XPath(".."));
            return ancestor;
        }

        public static IReadOnlyList<IWebElement> Descendants(this IWebElement webElement)
        {
            IReadOnlyList<IWebElement> childs = webElement.FindElements(By.XPath(".//*"));
            return childs;
        }

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds, IWebElement ancestor = null)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                if (ancestor != null)
                    return wait.Until(drv => ancestor.FindElement(by));
                return wait.Until(drv => drv.FindElement(by));
            }
            if (ancestor != null)
                return ancestor.FindElement(by);
            return driver.FindElement(by);
        }

        public static T FindControl<T>(this IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex = null)
        {
            object[] args = { driver, by, timeOutInSeconds, frameIndex };
            return (T)Activator.CreateInstance(typeof(T), args);
        }

        public static T FindControl<T>(this IWebDriver driver, By by, int timeOutInSeconds, IWebElement ancestor, int? frameIndex = null)
        {
            object[] args = { driver, by, timeOutInSeconds, ancestor, frameIndex };
            return (T)Activator.CreateInstance(typeof(T), args);
        }

        public static void Alerts(this IWebDriver driver, PopUpOperation operation, int timeOutInSeconds, string text = null)
        {
            bool isAlaertPresent = false;
            IAlert alert = null;
            var ms = DateTime.Now.Add(TimeSpan.FromSeconds(timeOutInSeconds));
            do
            {
                try
                {
                    alert = ExpectedConditions.AlertIsPresent().Invoke(driver);
                }
                catch
                {
                    isAlaertPresent = false;
                }
            } while (!((ms < DateTime.Now) || isAlaertPresent));
            if (alert == null)
                return;

            switch (operation)
            {
                case PopUpOperation.Accept:
                    alert.Accept();
                    break;
                case PopUpOperation.Dismiss:
                    alert.Dismiss();
                    break;
                case PopUpOperation.SetText:
                    alert.SendKeys(text);
                    alert.Accept();
                    break;
                default:
                    break;
            }
        }
    }
}
