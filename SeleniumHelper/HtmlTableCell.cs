using System.Linq;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using SeleniumHelper.Enums;
using System.Collections.Generic;

namespace SeleniumHelper
{
    public class HtmlTableCell : HtmlElement
    {
        private IWebElement cellElement;

        public HtmlTableCell(IWebElement cell)
            :base(cell)
        {
            this.cellElement = cell;
        }
    }
}