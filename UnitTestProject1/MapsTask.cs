using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Serilog;

namespace UnitTestProject1
{
    [TestFixture]
    class MapsTask
    {
        private IWebDriver chromeDriver;
        private IWebDriver firefoxDriver;

        [SetUp]
        public void SetupTests()
        {
            chromeDriver = new ChromeDriver(@"C:\drivers\");
            firefoxDriver = new FirefoxDriver(@"C:\drivers\");
            var mapsUrl =  @"https://www.google.pl/maps/";
            chromeDriver.Url = mapsUrl;
            List<IWebDriver> drivers = new List<IWebDriver>(){chromeDriver, firefoxDriver};
            foreach (var driver in drivers)
            {
                var consentUrl = driver.FindElement(By.ClassName("widget-consent-frame")).GetAttribute("src");
                driver.Navigate().GoToUrl(consentUrl);
                var consent = driver.FindElement(By.Id("introAgreeButton"));
                consent.Click();
                driver.Navigate().GoToUrl(mapsUrl);
                var routeButton = chromeDriver.FindElement(By.Id("searchbox")).FindElement(By.ClassName("searchbox-directions-container")).FindElement(By.TagName("button"));
                routeButton.Click();
                

            }
            
        }
        [Test]
        public void RoadToOfficeTakesLessThan40MinutesAndLessThan3km_OnFoot()
        {
            Assert.Fail();
        }
        [Test]
        public void RoadToOfficeTakesLessThan40MinutesAndLessThan3km_ByBike()
        {
            Assert.Fail();
        }
        [Test]
        public void RoadFromOfficeTakesLessThan40MinutesAndLessThan3km_OnFoot()
        {
            Assert.Fail();
        }
        [Test]
        public void RoadFromOfficeTakesLessThan40MinutesAndLessThan3km_ByBike()
        {
            Assert.Fail();
            
        }


    }
}
