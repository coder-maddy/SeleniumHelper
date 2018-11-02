using OpenQA.Selenium;
using SeleniumHelper.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumHelper
{
    public class HtmlCheckBox : HtmlElement, IHtmlInputControl<HtmlCheckState>
    {

        public HtmlCheckBox() : base()
        { }

        public HtmlCheckBox(IWebDriver driver, By by, int timeOutInSeconds, int? frameIndex)
                : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.CheckBox, null, frameIndex);
        }

        public HtmlCheckBox(IWebDriver driver, By by, int timeOutInSeconds, IWebElement ancestor, int? frameIndex)
                : base()
        {
            SearchControl(driver, by, timeOutInSeconds, ControlType.CheckBox, ancestor, frameIndex);
        }

        public HtmlCheckState CheckState
        {
            get
            {
                if (this.Selected)
                    return HtmlCheckState.Check;
                return HtmlCheckState.UnCheck;
            }
        }

        public void SetValue(HtmlCheckState value)
        {
            if (value == HtmlCheckState.Check)
            {
                if (this.Selected)
                    return;
                else
                    this.Click();
            }
            else
            {
                if (!this.Selected)
                    return;
                else
                    this.Click();
            }
        }
    }
}
