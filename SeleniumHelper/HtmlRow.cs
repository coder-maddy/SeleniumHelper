using System.Linq;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using SeleniumHelper.Enums;
using System.Collections.Generic;

namespace SeleniumHelper
{
    public class HtmlRow:HtmlElement
    {
        private IWebElement rowElement;

        public HtmlRow(IWebElement row)
            :base(row)
        {
            this.rowElement = row;
        }

        public IEnumerable<HtmlTableCell> Cells
        {
            get
            {
                var cells = rowElement.FindElements(By.XPath(".//td"));
                foreach (var cell in cells)
                {
                    yield return new HtmlTableCell(cell);
                }
            }
        }
    }
}