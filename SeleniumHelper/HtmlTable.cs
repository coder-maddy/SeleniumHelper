using OpenQA.Selenium;
using SeleniumHelper.Enums;
using System.Collections.Generic;

namespace SeleniumHelper
{
    public class HtmlTable : HtmlElement
    {
        IWebDriver driver;
        public HtmlTable(IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex) 
            : base()
        {
            this.driver = driver;
            SearchControl(driver, by, timeOutInSeconds, ControlType.Table, null, frameIndex);
        }

        public HtmlTable(IWebDriver driver, By by, int timeOutInSeconds, IWebElement ancestor, int? frameIndex) 
            : base()
        {
            this.driver = driver;
            SearchControl(driver, by, timeOutInSeconds, ControlType.Table, ancestor, frameIndex);
        }

        public IEnumerable<HtmlRow> Rows
        {
            get
            {
                var rows = this.FindElements(driver, By.XPath(".//tr"), 5000);
                foreach (var item in rows)
                {
                    yield return new HtmlRow(item);
                }
            }
        }
    }
}