using OpenQA.Selenium;
using SeleniumHelper.Enums;

namespace SeleniumHelper
{
    public class HtmlInputSubmit : HtmlElement
    {
        public HtmlInputSubmit() : base()
        { }

        public HtmlInputSubmit(IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.InputSubmit, null, frameIndex);
        }

        public HtmlInputSubmit(IWebDriver driver, By by, int timeOutInSeconds, IWebElement ancestor, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.InputSubmit, ancestor, frameIndex);
        }
    }
}
