using OpenQA.Selenium;
using SeleniumHelper.Enums;

namespace SeleniumHelper
{
    public class HtmlInputNumber : HtmlElement, IHtmlInputControl<double>
    {
        public HtmlInputNumber() : base()
        { }

        public HtmlInputNumber(IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Number, null, frameIndex);
        }

        public HtmlInputNumber(IWebDriver driver, By by, int timeOutInSeconds, IWebElement ancestor, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Number, ancestor, frameIndex);
        }

        public void SetValue(double value)
        {
            base.SetText(this, value.ToString());
        }
    }
}
