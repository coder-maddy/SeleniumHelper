using OpenQA.Selenium;
using SeleniumHelper.Enums;

namespace SeleniumHelper
{
    public class HtmlInputPassword : HtmlElement, IHtmlInputControl<string>
    {
        public HtmlInputPassword() : base()
        { }

        public HtmlInputPassword(IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Password, null, frameIndex);
        }

        public HtmlInputPassword(IWebDriver driver, By by, int timeOutInSeconds, IWebElement ancestor, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Password, ancestor, frameIndex);
        }

        public void SetValue(string value)
        {
            base.SetText(this, value);
        }
    }
}
