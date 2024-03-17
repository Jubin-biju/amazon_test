

using Newtonsoft.Json.Linq;
using NUnit.Framework.Internal;
using RestSharp;
using RestSharp.Authenticators;
using System.Net;

namespace AmazonTake
{
    public class ApiTest
    {
        public JObject Testapi()
        {
            RestClient client = new RestClient("https://graph.test-frontiersin.net");
            RestRequest request = new RestRequest("/v1/graphql", Method.Post);
            JObject jsonfile = JObject.Parse(File.ReadAllText("D:\\new22\\TestProgram\\TestProgram\\json1.json"));
            jsonfile["variables"]["article"] = "499614";
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("x-hasura-admin-secret", "GgGO26AGZbrQMUAUKMFtlJkz");
            request.AddJsonBody(jsonfile.ToString());
            RestResponse response = client.Execute(request);
            return JObject.Parse(response.Content);
        }

        public JObject TestapiCookieAuthentication(CookieCollection cookieCollection)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest("https://aira-app.frontiers-int8.info/api/v2.0/configurations/journals/post", Method.Post);
            JObject jsonfile = JObject.Parse(File.ReadAllText("D:\\AmazonTest\\AmazonTake\\action1.json"));
            jsonfile["journalId"] = int.Parse("27");
            jsonfile["actionConfigurationList"]![0]!["isEnabled"] = true;
            jsonfile["actionConfigurationList"]![1]!["isEnabled"] = false;
            request.AddJsonBody(jsonfile.ToString());
            request.AddCookie(cookieCollection[0].Name, cookieCollection[0].Value, cookieCollection[0].Path, cookieCollection[0].Domain);
            RestResponse response = client.Execute(request);
            return JObject.Parse(response.Content);
        }

        public JObject TestapiAuthentication(CookieCollection cookieCollection)
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest("https://aira-app.frontiers-int8.info/api/v2.0/configurations/journals/post", Method.Post);
            JObject jsonfile = JObject.Parse(File.ReadAllText("D:\\AmazonTest\\AmazonTake\\action1.json"));
            jsonfile["journalId"] = int.Parse("27");
            jsonfile["actionConfigurationList"]![0]!["isEnabled"] = true;
            jsonfile["actionConfigurationList"]![1]!["isEnabled"] = false;
            request.AddJsonBody(jsonfile.ToString());
            request.Authenticator = new HttpBasicAuthenticator("username", "password");
            RestResponse response = client.Execute(request);
            return JObject.Parse(response.Content);
        }

        public CookieCollection CookieAuthenticationDetails()
        {
            RestClient client = new RestClient();
            RestRequest request = new RestRequest("https://registration-ui.frontiers-int8.info/api/v2/user/login", Method.Post);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("Email", "sabareesh.g@automation.pitsolutions.com.test");
            request.AddParameter("Password", "test@v2");
            request.AddParameter("RememberMe", false);
            RestResponse response = client.Execute(request);
            return response.Cookies;
        }
    }
}
