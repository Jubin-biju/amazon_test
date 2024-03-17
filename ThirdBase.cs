using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Configuration;

namespace AmazonTake
{

    public class ThirdBase 
    {
        public BaseDriver firstBase = new BaseDriver();
        public void StartBrowser()
        {
            string browser = ConfigurationManager.AppSettings["Browser"]!;

            switch (browser)
            {
                case "chrome" :
                    firstBase.driver = new ChromeDriver();
                    break; 
                case "firefox":
                    firstBase.driver = new FirefoxDriver();
                    break;

            }
        }

        public void WindowManage()
        {
            firstBase.driver.Manage().Window.Maximize();
            firstBase.driver.Url = "https://www.amazon.com";
            firstBase.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void GenerateReport()
        {
            if(TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                string name = TestContext.CurrentContext.Test.MethodName + "_screenshot" + DateTime.Now.Ticks + ".png";
                //Screenshot screenshot = ((ITakesScreenshot).WebDriver).GetScreenshot();
                //screenshot.SaveAsFile(name);
                //TestContext.AddTestAttachment(name);

                //string name = TestContext.CurrentContext.Test.MethodName + "ss" + DateTime.Now + ".png";
                //.string name = "screen" + ".png";
                Screenshot screenshot = ((ITakesScreenshot)firstBase.driver).GetScreenshot();
                screenshot.SaveAsFile(name);
                TestContext.AddTestAttachment(name);

            }
        }
        public void tearDown()
        {
            firstBase.driver!.Quit();
        }

    }

}