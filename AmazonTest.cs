using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Net;

namespace AmazonTake
{
    public class AmazonTest : ThirdBase
    {
        private readonly AmzonLogin amzonLogin;
        private readonly ApiTest apiTest;

        private readonly Dictionary<string, string> testdata;

        [OneTimeSetUp]
        public void strtBrowser()
        {
            StartBrowser();
        }


        [SetUp]
        public void WindowIntialization()
        {
            WindowManage();
        }

        [TearDown]

        public void screenShot()
        {
            GenerateReport();
        }

        [OneTimeTearDown]

        public void down()
        {
            tearDown();
        }
        public AmazonTest()
        {
            apiTest = new ApiTest();
            amzonLogin = new AmzonLogin(firstBase);
            testdata = JObject.Parse(File.ReadAllText("D:\\AmazonTest\\AmazonTake\\Testdata.json")).ToObject<Dictionary<string, string>>()!;
        }


        [Test]
        public void AmazonLoginTest()
        {
            CookieCollection cc = apiTest.CookieAuthenticationDetails();
            apiTest.TestapiCookieAuthentication(cc);
            amzonLogin.ClickHelloSignIn();
            string ab = testdata["MobileName"];
            string ac = amzonLogin.getUrl();
        }

        [Test]
        public void AmazonLoginTest1()
        {
            amzonLogin.ClickHelloSignIn();

        }


    }
}
