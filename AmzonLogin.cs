

using AmazonTakeExtenasion;
using OpenQA.Selenium;

namespace AmazonTake
{
    public class AmzonLogin : PageBase
    {
        public AmzonLogin(BaseDriver base1): base(base1)
        {

        }

  
        #region Locator
        protected readonly string helloSignInLocator = "twotabsearchtextbox";

        IWebElement _helloSignIn => driver.FindElement(By.Id(helloSignInLocator));

        protected readonly string emailTextBoxLocator = "ap_email";

        IWebElement _emailTextBox => driver.FindElement(By.Id(emailTextBoxLocator));

        protected readonly string continueButtonLocator = "continue";

        IWebElement _continueButton => driver.FindElement(By.Id(continueButtonLocator));


        #endregion Locator

        #region Method

        public void ClickHelloSignIn()
        {
            _helloSignIn.Click();
            _helloSignIn.SendKeys("Redmi");
        }

        public void SendTheEmailId(string emailid)
        {
            _emailTextBox.SendKeys(emailid);
        }

        public void ClickOnContinueButton()
        {
            _continueButton.Click();
        }

        public void getMessage()
        {
            _continueButton.GetText();
        }

        public string getUrl()
        {
            return driver.Url;
        }

        #endregion Method




    }
}

