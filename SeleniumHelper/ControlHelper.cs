using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Drawing;
using System.Threading;

namespace SeleniumHelper
{
    public class ControlHelper
    {
        public static IWebElement FindControl(IWebDriver webDriver, By by, int timeoutInSeconds, IWebElement ancestor = null)
        {
            IWebElement webElement = null;
            if (ancestor == null)
            {
                webElement = webDriver.FindElement(by, timeoutInSeconds);
            }
            else
            {
                webElement = webDriver.FindElement(by, timeoutInSeconds, ancestor);
            }
            if (webElement == null)
                throw new Exception("Control is null");
            return webElement;
        }


        public static void WaitForCondtion(Action action, Func<bool> condition, int timeOutInSeconds, Exception exception = null)
        {
            try
            {
                action();
            }
            catch (Exception e) when (e.InnerException.Message.Contains("timeout"))
            {
                //ignored exception may occur due to slow internet
                Thread.Sleep(10000);
            }

            var ms = DateTime.Now.Add(TimeSpan.FromSeconds(timeOutInSeconds));
            var success = false;
            do
            {
                try
                {
                    success = condition();
                }
                catch
                {
                    success = false;
                }

            } while (!((ms < DateTime.Now) || success));
            if (!success)
                throw new Exception("Failed to load page");
        }

        public void DragDrop(IWebDriver driver,IWebElement source, IWebElement destination)
        {
            Actions builder = new Actions(driver);
            IAction dragAndDrop = builder.ClickAndHold(source).MoveToElement(destination).Release(destination).Build();

            dragAndDrop.Perform();
        }

        public void DragDrop(IWebDriver driver, IWebElement source, Point point)
        {
            int x = point.X, y=point.Y;
            Actions builder = new Actions(driver);
            IAction dragAndDrop = builder.DragAndDropToOffset(source, x, y).Build();

            dragAndDrop.Perform();
        }
    }
}
