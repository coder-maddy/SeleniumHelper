using OpenQA.Selenium;
using SeleniumHelper.Enums;

namespace SeleniumHelper
{
    public class HtmlInputFile : HtmlElement, IHtmlInputControl<string>
    {
        public HtmlInputFile() : base()
        { }

        public HtmlInputFile(IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.InputFile, null, frameIndex);
        }

        public HtmlInputFile(IWebDriver driver, By by, int timeOutInSeconds, IWebElement ancestor, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.InputFile, ancestor, frameIndex);
        }

        public void SetValue(string value)
        {
            this.htmlElement.SendKeys(value);
        }
    }
}
