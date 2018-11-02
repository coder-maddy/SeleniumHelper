using OpenQA.Selenium;
using SeleniumHelper.Enums;

namespace SeleniumHelper
{
    public class HtmlInputRange:HtmlElement, IHtmlInputControl<double>
    {

        public HtmlInputRange() : base()
        { }

        public HtmlInputRange(IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Range, null, frameIndex);
        }

        public HtmlInputRange(IWebDriver driver, By by, int timeOutInSeconds, IWebElement ancestor, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Range, ancestor, frameIndex);
        }

        public void SetValue(double number)
        {
            base.SetText(this, number.ToString());
        }

        public double Minimum
        {
            get { return double.Parse(this.htmlElement.GetAttribute("max")); }
        }

        public double CurrentValue
        {
            get { return double.Parse(this.htmlElement.GetAttribute("cur-val")); }
        }
        public double Maximum
        {
            get { return double.Parse(this.htmlElement.GetAttribute("min")); }
        }
    }
}
