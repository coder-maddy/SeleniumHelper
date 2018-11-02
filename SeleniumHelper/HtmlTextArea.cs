
using System;
using OpenQA.Selenium;
using SeleniumHelper.Enums;

namespace SeleniumHelper
{
    public class HtmlTextArea : HtmlElement, IHtmlInputControl<string>
    {
        public HtmlTextArea() : base()
        { }

        public HtmlTextArea(IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Textarea, null, frameIndex);
        }

        public HtmlTextArea(IWebDriver driver, By by, int timeOutInSeconds, IWebElement ancestor, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Textarea, ancestor, frameIndex);
        }

        public void SetValue(string value)
        {
            base.SetText(this, value, false);
        }
    }
}
