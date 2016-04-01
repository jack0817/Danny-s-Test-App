using DannysTestApp.Services.Web.Contract;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DannysTestApp.Services.Web
{
    public class TVDBWebService : IWebService
    {
        private const string BASE_URL = "https://api-beta.thetvdb.com/";

        private LogService LogService { get; set; }

        public TVDBWebService()
        {
            this.LogService = new LogService(typeof(TVDBWebService));
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

            using (var client = new HttpClient())
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

            using (var client = new HttpClient())
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
    }
}
