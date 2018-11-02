using OpenQA.Selenium;
using SeleniumHelper.Enums;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumHelper
{
    public class HtmlDate : HtmlElement, IHtmlInputControl<DateTime>
    {
        public HtmlDate() : base()
        { }

        public HtmlDate(IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex)
                : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Date, null, frameIndex);
        }

        public HtmlDate(IWebDriver driver, By by, int timeOutInSeconds, IWebElement ancestor, int? frameIndex)
                : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Date, ancestor, frameIndex);
        }

        public void SetValue(DateTime value)
        {
            var dateString = value.ToString("dd-MM-yyyy");
            SetText(this, dateString, false);
        }
    }
}
