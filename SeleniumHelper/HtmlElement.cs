using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using SeleniumHelper.Enums;
using OpenQA.Selenium.Support.UI;

namespace SeleniumHelper
{
    public class HtmlElement : IWebElement
    {
        public IWebElement htmlElement;
        public HtmlElement() : base()
        {
        }

        public HtmlElement(IWebElement htmlElement) : base()
        {
            this.htmlElement = htmlElement;
        }

        public HtmlElement(IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex)
        {
            if (frameIndex != null)
            {
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame((int)frameIndex);
            }
            else
                driver.SwitchTo().DefaultContent();
            this.htmlElement = ControlHelper.FindControl(driver, by, timeOutInSeconds);
        }

        public HtmlElement(IWebDriver driver, By by, int timeOutInSeconds, IWebElement ancestor, int? frameIndex)
        {
            if (frameIndex != null)
            {
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame((int)frameIndex);
            }
            else
                driver.SwitchTo().DefaultContent();
            this.htmlElement = ControlHelper.FindControl(driver, by, timeOutInSeconds, ancestor);
        }

        public bool Displayed
        {
            get
            {
                return this.htmlElement.Displayed;
            }
        }

        public bool Enabled
        {
            get
            {
                return this.htmlElement.Enabled;
            }
        }

        public Point Location
        {
            get
            {
                return this.htmlElement.Location;
            }
        }

        public bool Selected
        {
            get
            {
                return this.htmlElement.Selected;
            }
        }

        public Size Size
        {
            get
            {
                return this.htmlElement.Size;
            }
        }

        public string TagName
        {
            get
            {
                return this.htmlElement.TagName;
            }
        }

        public string Text
        {
            get
            {
                return this.htmlElement.Text;
            }
        }

        public void Clear()
        {
            this.htmlElement.Clear();
        }

        public void Click()
        {
            Func<bool> sync = () => this.htmlElement.Displayed && htmlElement.Enabled;
            sync.WaitUntilTrue(20, () => new SeleniumHelperException("Element is not displayed or enabled."));
            this.htmlElement.Click();
        }

        public IWebElement FindElement(By by)
        {
            return this.htmlElement.FindElement(by);
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            return this.htmlElement.FindElements(by);
        }

        public string GetAttribute(string attributeName)
        {
            var element = this.htmlElement.GetAttribute(attributeName);
            return element;
            //throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public virtual void SendKeys(string text)
        {
            this.htmlElement.SendKeys(text);
        }

        public void Submit()
        {
            this.htmlElement.Click();
        }

        internal static string GenerateXPath(By by)
        {
            string xPath = null;
            string searchBy = by.ToString();
            string searchCriteria = searchBy.Substring(searchBy.IndexOf(".") + 1);
            string searchCriteria1 = searchCriteria.Substring(0, searchCriteria.IndexOf(":"));
            string searchAttribute = searchCriteria.Substring(searchCriteria.IndexOf(" ") + 1);

            switch (searchCriteria1)
            {
                case "ClassName[Contains]":
                    searchCriteria1 = "class";
                    xPath = "@" + searchCriteria1.ToLower() + "='" + searchAttribute + "'";
                    break;
                case "LinkText":
                    searchCriteria1 = "text()";
                    xPath = searchCriteria1.ToLower() + " = '" + searchAttribute + "'";
                    break;
                case "PartialLinkText":
                    searchCriteria1 = "contains(text()";
                    xPath = searchCriteria1.ToLower() + ", '" + searchAttribute + "')";
                    break;
                case "Name":
                case "Id":
                    xPath = "@" + searchCriteria1.ToLower() + "='" + searchAttribute + "'";
                    break;
                default:
                    break;
            }

            return xPath;
        }

        internal void SearchControl(IWebDriver driver, By by, int timeOutInSeconds, ControlType controlType, IWebElement ancestor = null, int? frameIndex = null)
        {
            if (frameIndex != null)
            {
                driver.SwitchTo().DefaultContent();
                driver.SwitchTo().Frame((int)frameIndex);
            }
            driver.SwitchTo().DefaultContent();
            if (by.ToString().Contains("XPath") || by.ToString().Contains("TagName"))
                this.htmlElement = ControlHelper.FindControl(driver, by, timeOutInSeconds, ancestor);
            else
            {
                By searchElementBy = null;
                string xPath = GenerateXPath(by);
                switch (controlType)
                {
                    case ControlType.Anchor:
                        searchElementBy = By.XPath("//a[" + xPath + "]");
                        break;
                    case ControlType.InputButton:
                        searchElementBy = By.XPath("//input[" + xPath + " and @type='button']");
                        break;
                    case ControlType.InputSubmit:
                        searchElementBy = By.XPath("//button[" + xPath + " and @type='submit']");
                        break;
                    case ControlType.Text:
                        searchElementBy = By.XPath("//input[" + xPath + " and @type='text']");
                        break;
                    case ControlType.Textarea:
                        searchElementBy = By.XPath("//textarea[" + xPath + "]");
                        break;
                    case ControlType.InputFile:
                        searchElementBy = By.XPath("//input[" + xPath + " and @type='file']");
                        break;
                    case ControlType.Select:
                        searchElementBy = By.XPath("//select[" + xPath + "]");
                        break;
                    case ControlType.CheckBox:
                        searchElementBy = By.XPath("//input[" + xPath + " and @type='checkbox']");
                        break;
                    case ControlType.Number:
                        searchElementBy = By.XPath("//input[" + xPath + " and @type='number']");
                        break;
                    case ControlType.RadioButton:
                        searchElementBy = By.XPath("//input[" + xPath + " and @type='radio']");
                        break;
                    case ControlType.Password:
                        searchElementBy = By.XPath("//input[" + xPath + " and @type='password']");
                        break;
                    case ControlType.Range:
                        searchElementBy = By.XPath("//input[" + xPath + " and @type='range']");
                        break;
                    case ControlType.Table:
                        searchElementBy = By.XPath("//table[" + xPath + "]");
                        break;
                    case ControlType.Date:
                        searchElementBy = By.XPath("//input[" + xPath + "and @type='date']");
                        break;
                    case ControlType.Button:
                        searchElementBy = By.XPath("//button[" + xPath + "]");
                        break;
                }

                this.htmlElement = ControlHelper.FindControl(driver, searchElementBy, timeOutInSeconds, ancestor);
            }
        }

        public ReadOnlyCollection<IWebElement> FindElements(IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                if (htmlElement != null)
                    return wait.Until(drv => htmlElement.FindElements(by));
                return wait.Until(drv => drv.FindElements(by));
            }
            if (htmlElement != null)
                return htmlElement.FindElements(by);
            return driver.FindElements(by);
        }

        public bool Exists()
        {
            if (this.htmlElement != null)
                return true;
            else
                return false;
        }


        public string ExecuteJavaScript(IWebDriver driver, string script)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            string returnValue = (string)js.ExecuteScript(script);
            return returnValue;
        }

        internal void SetText(HtmlElement element, string text, bool verifySetting=true)
        {
            Func<bool> sync = () => element.Displayed && htmlElement.Enabled;
            sync.WaitUntilTrue(20, () => new SeleniumHelperException("Element is not displayed or enabled."));
            element.htmlElement.SendKeys(text);
            if (verifySetting)
            {
                Func<bool> sync1 = () => element.GetAttribute("value") == text;
                sync1.WaitUntilTrue(20, () => new SeleniumHelperException($"Failed to set value {text}."));
            }
        }
    }
}
