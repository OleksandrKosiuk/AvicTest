using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace AvicTest
{
    public class AvisTests
    {
        private IWebDriver driver;

        [SetUp]
        public void ProfileSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://avic.ua/");
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void CheckThatUrlContainsSearchWord()
        {
            driver.FindElement(By.XPath("//input[@id='input_search']")).SendKeys("iPhone 13");
            driver.FindElement(By.XPath("//button[@class='button-reset search-btn']")).Click();
            Assert.True(driver.Url.Contains("query=iPhone"));
        }

        [Test]

        public void CheckElementsAmountOnSearchPage()
        {
            driver.FindElement(By.XPath("//input[@id='input_search']")).SendKeys("iPhone 13");
            driver.FindElement(By.XPath("//button[@class='button-reset search-btn']")).Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            IList<IWebElement> elementsList = driver.FindElements(By.XPath("//div[@class='prod-cart__descr']"));
            int actualElementsSize = elementsList.Count;
            Assert.AreEqual(12, actualElementsSize);
        }

        [Test]

        public void CheckThatSearchResultsContainSearchWord()
        {
            driver.FindElement(By.XPath("//input[@id='input_search']")).SendKeys("iPhone 13");
            driver.FindElement(By.XPath("//button[@class='button-reset search-btn']")).Click();
            IList<IWebElement> elementsList = driver.FindElements(By.XPath("//div[@class='prod-cart__descr']"));
            foreach (IWebElement element in elementsList)
            {
                Assert.True(element.Text.Contains("iPhone"));
            }
        }

        [Test]
        public void CheckThatUrlContainsSearchWordGoogle()
        {
            driver.FindElement(By.XPath("//input[@id='input_search']")).SendKeys("google телефон");
            driver.FindElement(By.XPath("//button[@class='button-reset search-btn']")).Click();
            Assert.True(driver.Url.Contains("query=google"));
        }
    }
}