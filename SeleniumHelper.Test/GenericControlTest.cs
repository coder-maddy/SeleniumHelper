using SeleniumHelper.Enums;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.Generic;
using System;
using System.Globalization;
using OpenQA.Selenium.Remote;

namespace SeleniumHelper.Test
{
    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.InternetExplorer)]
    [TestFixture(BrowserType.MozillaFireFox)]
    [TestFixture(BrowserType.ChromeOnAndroid)]
    public class GenericControlTest
    {
        IWebDriver webDriver;
        BrowserType browserType;
        public GenericControlTest(BrowserType browserType)
        {
            this.browserType = browserType;
        }

        [TestFixtureSetUp]
        public void Setup()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability("browserName", "chrome");
            capabilities.SetCapability("deviceName", "Motorola Moto g");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "7.0");
            if (browserType == BrowserType.ChromeOnAndroid)
                webDriver = BrowserHelper.OpenBrowser(browserType, @"file://D:/TAContest/SeleniumHelper/SeleniumHelper.Test/Pages/GenericControl.html", capabilities);
            else
                webDriver = BrowserHelper.OpenBrowser(browserType, @"file://D:/TAContest/SeleniumHelper/SeleniumHelper.Test/Pages/GenericControl.html");
        }

        [TestFixtureTearDown]
        public void Close()
        {
            webDriver.Quit();
            webDriver = null;
        }


        [Test]
        public void FindControlTest()
        {
            Assert.IsNotNull(webDriver.FindControl<HtmlAnchor>(By.LinkText("Generic Control Test Page"), 5));
            Assert.IsNotNull(webDriver.FindControl<HtmlAnchor>(By.ClassName("reload-page"), 5));
            Assert.IsNotNull(webDriver.FindControl<HtmlAnchor>(By.Id("reload-page"), 5));
            Assert.IsNotNull(webDriver.FindControl<HtmlInputButton>(By.Name("My Button"), 5));
            Assert.IsNotNull(webDriver.FindControl<HtmlAnchor>(By.PartialLinkText("Generic Control Test"), 5));
        }

        [Test]
        public void HtmlTableTest()
        {
            HtmlTable table = webDriver.FindControl<HtmlTable>(By.Id("mytable"), 5);
            Assert.IsNotNullOrEmpty(table.Rows.ElementAt(1).Text);
            Assert.IsNotNullOrEmpty(table.Rows.ElementAt(1).Cells.ElementAt(1).Text);
        }

        [Test]
        public void HtmlTextFieldTest()
        {
            HtmlInputText textBox = webDriver.FindControl<HtmlInputText>(By.Id("myTextField"), 5);
            Assert.IsNullOrEmpty(textBox.Text);
            textBox.SendKeys("alph");
        }

        [Test]
        public void HtmlTextareaFieldTest()
        {
            HtmlTextArea textBox = webDriver.FindControl<HtmlTextArea>(By.Id("mytextarea"), 5);
            textBox.SendKeys("alphabets has 26 english letters.\n The letters can be written in Small and upper case \n for example : A is upper and a is small.Just like CheckBox & Radio Buttons, DropDown & Multiple Select Operations also works together and almost the same way.\n To perform any action, the first task is to identify the element group. I am saying it a group, as DropDown /Multiple Select is not a single element.\n They always have a single name but and they contains one or more than one elements in them.\n I should rather say more than one option in DropDown and Multiple Select. The only difference between these two is deselecting statement & multiple selections are not allowed on DropDown . \n Let’s look at the different operations \n it is working \n  yeah \n hmm....");
        }

        [Test]
        public void HtmlNumberFieldTest()
        {
            HtmlInputNumber textBox = webDriver.FindControl<HtmlInputNumber>(By.Id("myTextField"), 5);
            Assert.IsNullOrEmpty(textBox.Text);
            textBox.SetValue(10);
        }

        [Test]
        public void HtmlRangeTest()
        {
            HtmlInputRange textBox = webDriver.FindControl<HtmlInputRange>(By.Id("myslider"), 5);
            textBox.SetValue(10.50);
        }

        [Test]
        public void HtmlButtonTest()
        {
            HtmlInputButton button = webDriver.FindControl<HtmlInputButton>(By.Name("My Button"), 5);
            button.Click();
            Assert.AreEqual(webDriver.FindControl<HtmlElement>(By.Id("myLabel"), 5).Text, "Button Clicked");
        }

        [Test]
        public void HtmlSelectTest()
        {
            webDriver.FindControl<HtmlSelect>(By.Name("mySelect"), 10).SelectItemByValue("mercedes");
            // Assert.AreEqual(webDriver.FindControl<HtmlElement>(By.Id("myLabel"), 5).Text, "Button Clicked");
        }

        [Test]
        public void IFrameTest()
        {
            HtmlInputButton button = webDriver.FindControl<HtmlInputButton>(By.Name("My Button"), 5, 1);
            button.Click();
            Assert.AreEqual(webDriver.FindControl<HtmlElement>(By.Id("myLabel"), 5, 1).Text, "IFrame Button Clicked");

            HtmlInputButton button1 = webDriver.FindControl<HtmlInputButton>(By.Name("My Button"), 5);
            button1.Click();
            Assert.AreEqual(webDriver.FindControl<HtmlElement>(By.Id("myLabel"), 5).Text, "Button Clicked");
        }

        [Test]
        public void CheckBoxRadioButtonTest()
        {
            HtmlCheckBox checkBox1 = webDriver.FindControl<HtmlCheckBox>(By.Id("myCheckBox"), 5);
            HtmlCheckBox checkBox2 = webDriver.FindControl<HtmlCheckBox>(By.Id("myCheckBox1"), 5);
            HtmlRadioButton radio1 = webDriver.FindControl<HtmlRadioButton>(By.Id("gender0"), 5);
            HtmlRadioButton radio2 = webDriver.FindControl<HtmlRadioButton>(By.Id("gender1"), 5);
            Assert.IsTrue(checkBox2.CheckState == HtmlCheckState.Check);
            Assert.IsTrue(radio1.IsSelected);
            radio2.Click();
            Assert.IsFalse(radio1.IsSelected);
            checkBox1.SetValue(HtmlCheckState.Check);
            checkBox2.SetValue(HtmlCheckState.UnCheck);
        }


        [Test]
        public void DateTest()
        {
            //DateTime date = DateTime.ParseExact( "12/02/2017 ","(d)", CultureInfo.CurrentCulture);
            HtmlDate setDate = webDriver.FindControl<HtmlDate>(By.Id("date"), 5);
            setDate.SetValue(DateTime.Now);
        }
    }
}
