using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace UnitTestProject1
{    
    [TestClass]
    public class UnitTest1
    {
        public AndroidDriver<AppiumWebElement> driver;

        [TestInitialize]
        public void BeforeAll()
        {

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability(CapabilityType.Platform, "Windows");
            capabilities.SetCapability("deviceName", "ZTE");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("platformVersion", "5.1");
            //capabilities.SetCapability("appPackage", "com.android.calculator2");
            //capabilities.SetCapability("appActivity", "com.android.calculator2.Calculator");
            capabilities.SetCapability("appPackage", "com.skina.android");
            capabilities.SetCapability("appActivity", "com.skina.android.ui.activities.SplashFullscreenActivity");

            driver = new AndroidDriver<AppiumWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
            
        }

        [TestCleanup]
        public void AfterAll()
        {
            driver.Quit();
        }

        [TestMethod]
        //public void TestCalculator()
        //{

        //    var two = driver.FindElement(By.Name("2"));
        //    two.Click();
        //    var plus = driver.FindElement(By.Name("+"));
        //    plus.Click();
        //    var four = driver.FindElement(By.Name("4"));
        //    four.Click();
        //    var equalTo = driver.FindElement(By.Name("="));
        //    equalTo.Click();

        //    var results = driver.FindElement(By.ClassName("android.widget.EditText"));

        //    Assert.AreEqual("6", results.Text);
        //}

        public void SkinaBasic()
        {            
            var opcaoBuscar = driver.FindElement(By.Name("Buscar"));
            opcaoBuscar.Click();
            var inputBusca = driver.FindElement(By.ClassName("android.widget.EditText"));
            inputBusca.Click();
            inputBusca.SendKeys("devicelab");
            var botaoAplicar = driver.FindElement(By.Id("search_apply_button"));
            botaoAplicar.Click();

            Thread.Sleep(5000);

            //Assertion
            var productName = driver.FindElement(By.Id("com.skina.android:id/name"));
            var productValue = driver.FindElement(By.Id("com.skina.android:id/product_price"));

            Assert.AreEqual("DeviceLab ", productName.Text);
            Assert.AreEqual("R$200", productValue.Text);
        }
    }
}
