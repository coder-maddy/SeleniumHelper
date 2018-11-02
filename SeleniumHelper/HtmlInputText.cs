
using OpenQA.Selenium;
using SeleniumHelper.Enums;

namespace SeleniumHelper
{
    public class HtmlInputText : HtmlElement, IHtmlInputControl<string>
    {
        public HtmlInputText() : base()
        { }

        public HtmlInputText(IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Text, null, frameIndex);
        }

        public HtmlInputText(IWebDriver driver, By by, int timeOutInSeconds, IWebElement ancestor, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Text, ancestor, frameIndex);
        }

        public void SetValue(string value)
        {
            base.SetText(this, value);
        }
    }
}
