using OpenQA.Selenium;
using SeleniumHelper.Enums;

namespace SeleniumHelper
{
    public class HtmlAnchor : HtmlElement
    {
        public HtmlAnchor() : base()
        { }

        public HtmlAnchor(IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Anchor, null, frameIndex);
        }


        public HtmlAnchor(IWebDriver driver, By by, int timeOutInSeconds, IWebElement ancestor, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Anchor, ancestor, frameIndex);
        }
    }
}
