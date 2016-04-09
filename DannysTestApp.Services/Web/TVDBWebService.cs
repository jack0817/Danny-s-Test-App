using DannysTestApp.Services.Security;
using DannysTestApp.Services.Web.Contract;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DannysTestApp.Services.Web
{
    public class TVDBWebService : IWebService
    {
        private const string BASE_URL = "https://api-beta.thetvdb.com/";
        private const string API_KEY = "3F2CB03ED0901F9E";
        private const string USER_ID = "DannyTestApp";
        private const string USER_PASS = "BlargZarg123!";

        private LogService LogService { get; set; }
        private AppSettingsService SettingsService { get; set; }

        public TVDBWebService()
        {
            this.LogService = new LogService(typeof(TVDBWebService));
            this.SettingsService = new AppSettingsService();
        }

        public WebServiceRequest CreateAuthorizationRequest()
        {
            var auth = new Authentication
            {
                ApiKey = TVDBWebService.API_KEY,
                UserName = TVDBWebService.USER_ID,
                UserPass = TVDBWebService.USER_PASS
            };

            var authJson = TVDBContract.Serialize(auth);
            var request = this.CreateBaseRequest();
            request.SetPath("login");
            request.SetContent(authJson);
            return request;
        }

        public WebServiceRequest CreateBaseRequest()
        {
            return new WebServiceRequest(TVDBWebService.BASE_URL);
        }

        public async Task<T> GetAsync<T>(WebServiceRequest request)
        {
            var url = request.GetUrl();
            if (string.IsNullOrEmpty(url))
                return default(T);

            using (var client = this.CreateClient())
            {
                var response = await this.TryGetResponse(() => client.GetAsync(url));
                if (response == null || response.StatusCode != HttpStatusCode.OK)
                    return default(T);

                var responseJson = await response.Content.ReadAsStringAsync();
                return TVDBContract.Deserialize<T>(responseJson);
            }
        }

        public async Task<T> PostAsync<T>(WebServiceRequest request)
        {
            var url = request.GetUrl();
            var content = request.GetContent();
            if (string.IsNullOrEmpty(url) || content == null)
                return default(T);

            using (var client = this.CreateClient())
            {
                var response = await this.TryGetResponse(() => client.PostAsync(url, content));
                if (response == null)
                    return default(T);

                var responseJson = await response.Content.ReadAsStringAsync();
                return TVDBContract.Deserialize<T>(responseJson);
            }
        }

        private async Task<HttpResponseMessage> TryGetResponse(Func<Task<HttpResponseMessage>> getResponse)
        {
            try
            {
                return await getResponse();
            }
            catch(Exception ex)
            {
                this.LogService.Error(ex);
            }

            return null;
        }

        private HttpClient CreateClient()
        {
            var client = new HttpClient();
            var apiToken = this.SettingsService.GetValue(AppSettingsService.Keys.API_KEY);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);
            return client;
        }
    }
}
