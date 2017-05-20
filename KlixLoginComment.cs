using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class KlixLoginComment
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://www.klix.ba/";
            verificationErrors = new StringBuilder();
        }
        
        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
        
        [Test]
        public void TheKlixLoginCommentTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.CssSelector("div.item.user-icon > a.pointer")).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys("***");
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys("***");
            driver.FindElement(By.CssSelector("input[type=\"checkbox\"]")).Click();
            driver.FindElement(By.Id("prijava-req")).Click();
            driver.FindElement(By.LinkText("Vijesti")).Click();
            driver.FindElement(By.XPath("//body[@id='kat_naslovnica']/div[4]/div[2]/div/div/div[2]/div/div[2]/div/article/a/div[2]/div")).Click();
            driver.FindElement(By.XPath("//body[@id='kat_clanak']/div[3]/div[2]/div[3]/div[3]/div/div/komentari/div/div/textarea")).Clear();
            driver.FindElement(By.XPath("//body[@id='kat_clanak']/div[3]/div[2]/div[3]/div[3]/div/div/komentari/div/div/textarea")).SendKeys("Sramota");
            driver.FindElement(By.LinkText("Komentariši")).Click();
            driver.FindElement(By.LinkText("Odjavi se")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        
        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
