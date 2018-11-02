using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumHelper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumHelper
{
    public class HtmlSelect : HtmlElement
    {

        SelectElement oSelect = null;
        public HtmlSelect() : base()
        { }

        public HtmlSelect(IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex)
            : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Select, null, frameIndex);
            oSelect = new SelectElement(this);
        }

        public HtmlSelect(IWebDriver driver, By by, int timeOutInSeconds,IWebElement ancestor, int? frameIndex)
           : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.Select, ancestor, frameIndex);
            oSelect = new SelectElement(this);
        }


        public IWebElement SelectedItem()
        {
            return oSelect.SelectedOption;
        }
        public void SelectItemByValue(string value)
        {
            oSelect.SelectByValue(value);
        }

        public void SelectItemByText( string value)
        {
            oSelect.SelectByText(value);
        }
        public void SelectItemByIndex(int index)
        {
            oSelect.SelectByIndex(index);
        }
    }
}

