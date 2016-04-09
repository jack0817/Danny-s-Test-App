using DannysTestApp.Services.Web.Contract;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DannysTestApp.Services.Web
{
    public class TheMovieDbService : IWebService
    {
        private const string BASE_URL = "https://api.themoviedb.org/3/";
        private const string API_KEY = "f4976a0eb42a765189ee56b32a96a7a8";

        private AppSettingsService SettingsService { get; set; }

        public TheMovieDbService()
        {
            this.SettingsService = new AppSettingsService();
        }

        public WebServiceRequest CreateAuthorizationRequest()
        {
            var request = new WebServiceRequest(TheMovieDbService.BASE_URL);
            request.SetPath("authentication/token/new");
            request.AddParameter("api_key", TheMovieDbService.API_KEY);
            return request;
        }

        public WebServiceRequest CreateBaseRequest()
        {
            var request = new WebServiceRequest(TheMovieDbService.BASE_URL);
            request.AddParameter("api_key", TheMovieDbService.API_KEY);
            return request;
        }

        public async Task<T> GetAsync<T>(WebServiceRequest request)
        {
            using(var client = new HttpClient())
            {
                var url = request.GetUrl();
                var response = await client.GetAsync(url);
                if (response == null || response.StatusCode != HttpStatusCode.OK)
                    return default(T);

                var jsonString = await response.Content.ReadAsStringAsync();
                return TheMovieDbContract.Deserialize<T>(jsonString);
            }
        }

        public Task<T> PostAsync<T>(WebServiceRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
