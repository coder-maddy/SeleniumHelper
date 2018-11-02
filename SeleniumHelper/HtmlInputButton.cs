using OpenQA.Selenium;
using SeleniumHelper.Enums;

namespace SeleniumHelper
{
    public class HtmlInputButton : HtmlElement
    {
        public HtmlInputButton() : base()
        { }

        public HtmlInputButton(IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.InputButton, null, frameIndex);
        }

        public HtmlInputButton(IWebDriver driver, By by, int timeOutInSeconds, IWebElement ancestor, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.InputButton, ancestor, frameIndex);
        }
    }
}
