using OpenQA.Selenium;
using SeleniumHelper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumHelper
{
    public class HtmlRadioButton : HtmlElement
    {
        public HtmlRadioButton() : base()
        { }

        public HtmlRadioButton(IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex)
                : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.RadioButton,null, frameIndex);
        }

        public HtmlRadioButton(IWebDriver driver, By by, int timeOutInSeconds, IWebElement ancestor, int? frameIndex)
                : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.RadioButton, ancestor, frameIndex);
        }

        public bool IsSelected
        {        
            get { return this.Selected; }
        }
    }
}

