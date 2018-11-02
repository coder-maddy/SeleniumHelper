using OpenQA.Selenium;
using SeleniumHelper.Enums;

namespace SeleniumHelper
{
    public class HtmlButton : HtmlElement
    {
        public HtmlButton() : base()
        { }

        public HtmlButton(IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Button, null, frameIndex);
        }

        public HtmlButton(IWebDriver driver, By by, int timeOutInSeconds, IWebElement ancestor, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Button, ancestor, frameIndex);
        }

        public override void SendKeys(string text)
        {
            throw new SeleniumHelperException("Send keys are not supported by button.");
        }
    }
}
