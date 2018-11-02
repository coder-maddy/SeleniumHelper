using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumHelper
{
    public class EditorHelper
    {
        public static void SetValue(IWebElement webElement, string text)
        {
            if (!(webElement.Displayed && webElement.Enabled))
                throw new SeleniumHelperException("Element is not displayed or enabled.");
            webElement.Clear();
            webElement.SendKeys(text);
            //Func<bool> sync = () => webElement.Text == text;
            //sync.WaitUntilTrue(5000, new SeleniumHelperException("Failed to set value in input field"));
        }

        public static void Clear(IWebElement webElement)
        {
            if (!(webElement.Displayed && webElement.Enabled))
                throw new SeleniumHelperException("Element is not displayed or enabled.");
            webElement.Clear();
            //Func<bool> sync = () => webElement.Text == "";
            //sync.WaitUntilTrue(5000, new SeleniumHelperException("Failed to clear input field"));
        }

        public static void Click(IWebElement webElement)
        {
            if (!(webElement.Displayed && webElement.Enabled))
                throw new SeleniumHelperException("Element is not displayed or enabled.");
            webElement.Click();
        }

        public static void Submit(IWebElement webElement)
        {
            if (!(webElement.Displayed && webElement.Enabled))
                throw new SeleniumHelperException("Element is not displayed or enabled.");
            webElement.Submit();
        }
    }
}
