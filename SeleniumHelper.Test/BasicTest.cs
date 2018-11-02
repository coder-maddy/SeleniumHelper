using SeleniumHelper.Enums;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using System.Linq;
using System;
using System.Threading;
using OpenQA.Selenium.Remote;

namespace SeleniumHelper.Test
{
    public class TestBase
    {
        public IWebDriver webDriver { get; set; }
        public BrowserType browserType { get; set; }

        public string userName = "your-username", password = "your-password";

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
                webDriver = BrowserHelper.OpenBrowser(browserType, "https://wordpress.com/", capabilities);
            else
                webDriver = BrowserHelper.OpenBrowser(browserType, "https://wordpress.com/");
            Login();
        }

        private void Login()
        {
            HtmlElement htmlElement = webDriver.FindControl<HtmlElement>(By.ClassName("menu-login"), 1000);
            HtmlAnchor loginButton = webDriver.FindControl<HtmlAnchor>(By.Id("navbar-login-link"), 5000, htmlElement);
            ControlHelper.WaitForCondtion(() => loginButton.Click(), () => webDriver.FindControl<HtmlInputText>(By.Id("usernameOrEmail"), 10).Exists(), 20);
            webDriver.FindControl<HtmlInputText>(By.Id("usernameOrEmail"), 10).SendKeys(userName);
            webDriver.FindControl<HtmlInputPassword>(By.Id("password"), 10).SendKeys(password);
            HtmlElement submitButton = webDriver.FindControl<HtmlElement>(By.CssSelector(".button.form-button.is-primary"), 10);
            ControlHelper.WaitForCondtion(() => submitButton.Submit(), () => webDriver.FindControl<HtmlAnchor>(By.XPath(".//a[@title='Create a New Post']"), 10).Exists(), 30);
        }

        [TestFixtureTearDown]
        public void Logout()
        {
            webDriver.FindControl<HtmlAnchor>(By.XPath(".//a[@title='Update your profile, personal settings, and more']"), 20).Click();
            webDriver.FindControl<HtmlButton>(By.ClassName("button me-sidebar__signout-button is-compact"), 20).Click();
            Assert.IsTrue(webDriver.FindControl<HtmlAnchor>(By.LinkText("Sign In"), 20).Exists());
        }
    }

    [TestFixture(BrowserType.Chrome)]
    [TestFixture(BrowserType.InternetExplorer)]
    [TestFixture(BrowserType.ChromeOnAndroid)]
    public class WriteBlogTest : TestBase
    {
        string window;

        public WriteBlogTest(BrowserType browserType)
        {
            this.browserType = browserType;
            this.userName = File.ReadLines("Credentials.txt").ElementAt(0);
            this.password = File.ReadLines("Credentials.txt").ElementAt(1);
        }

        [SetUp]
        public void ClickOnPublish()
        {
            webDriver.FindControl<HtmlAnchor>(By.XPath(".//a[@title='View a list of your sites and access their dashboards']"), 20).Click();
            //var manage = webDriver.FindControl<HtmlElement>(By.ClassName("sidebar__heading"), 30);
            Thread.Sleep(2000);
            var post = webDriver.FindControl<HtmlAnchor>(By.XPath(".//a[text()='Add'][1]"), 30);
            post.Click();
        }

        [Test, TestCaseSource("CreateBlogData")]
        public void WriteBlog(string title, string content)
        {
            Thread.Sleep(10000);
            Func<bool> sync = () => webDriver.FindControl<HtmlElement>(By.XPath(".//textarea[@placeholder='Title']"), 20).Exists();
            sync.WaitUntilTrue(100, () => new SeleniumHelperException("Element not found."));
            webDriver.FindControl<HtmlElement>(By.XPath(".//textarea[@placeholder='Title']"), 20).SendKeys(title);
            Thread.Sleep(2000);
            webDriver.FindControl<HtmlElement>(By.Id("tinymce"), 10, 0).SendKeys(content);
            webDriver.FindControl<HtmlElement>(By.XPath(".//button[text()='Publish']"), 10).Click();
            Thread.Sleep(20000);
            webDriver.FindControl<HtmlAnchor>(By.LinkText("vikas454"), 20).Click();
            window = webDriver.WindowHandles.FirstOrDefault();
            webDriver.SwitchTo().Window(webDriver.WindowHandles.ElementAt(1));
            Assert.IsTrue(webDriver.FindControl<HtmlAnchor>(By.LinkText(title), 20).Exists());

        }

        [TearDown]
        public void CloseWindow()
        {
            webDriver.SwitchTo().Window(webDriver.WindowHandles.ElementAt(1)).Close();
            webDriver = webDriver.SwitchTo().Window(window);
            var home = webDriver.FindControl<HtmlAnchor>(By.XPath(".//a[@title='View a list of your sites and access their dashboards']"), 20);
            ControlHelper.WaitForCondtion(() => home.Click(), () => webDriver.FindControl<HtmlElement>(By.ClassName("sidebar__heading"), 20).Exists(), 30);
        }

        private object[] CreateBlogData = {
            new object[] {"Blog1", "This is blog1"},
            new object[] {"Blog2", "This is blog2"},
            new object[] {"Blog3", "This is blog3"},
            new object[] {"Blog4", "This is blog4"},
            new object[] {"Blog5", "This is blog5s"},
        };
    }

    public class DeleteBlogTest : TestBase
    {
        public DeleteBlogTest(BrowserType browserType)
        {
            this.browserType = browserType;
            this.userName = File.ReadLines("Credentials.txt").ElementAt(0);
            this.password = File.ReadLines("Credentials.txt").ElementAt(1);
        }

        [Test, TestCaseSource("DeleteBlogData")]
        public void DeleteBlog(string title)
        {
            var articles = webDriver.FindElements(By.XPath(".//article[@class='card post']"));
            var article = articles.FirstOrDefault().Descendants().FirstOrDefault(item => item.Text == title);
            article.FindElement(By.ClassName("post-controls__more")).Click();
            article.FindElement(By.ClassName("post-controls__trash")).Click();
            
        }

        [SetUp]
        public void ClickOnMySite()
        {
            webDriver.FindControl<HtmlAnchor>(By.XPath(".//a[@title='View a list of your sites and access their dashboards']"), 20).Click();
            //var manage = webDriver.FindControl<HtmlElement>(By.ClassName("sidebar__heading"), 30);
            Thread.Sleep(2000);
            var post = webDriver.FindControl<HtmlAnchor>(By.XPath(".//a[text()='Add'][1]"), 30);
            post.Ancestor().Click();
        }

        [SetUp]
        public void ClickOnReader()
        {
            webDriver.FindControl<HtmlAnchor>(By.XPath(".//a[@title='Read the blogs and topics you follow']"), 20).Click();
        }

        private object[] DeleteBlogData = {
            new object[] {"Blog1"},
            new object[] {"Blog2"},
            new object[] {"Blog3"},
            new object[] {"Blog4"},
            new object[] {"Blog5"}
        };
    }
}
