using DannysTestApp.Services.Security;
using DannysTestApp.Services.Web.Contract;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace DannysTestApp.Services
{
    public class AuthenticationService : ServiceBase
    {
        private const string API_KEY = "C25CC013BC89D0C2";
        private const string USER_ID = "jack0817";
        private const string USER_PASS = "Ibanez17";

        public async Task<ApiToken> GetTokenAsync()
        {
            var auth = new Authentication
            {
                ApiKey = AuthenticationService.API_KEY,
                UserName = AuthenticationService.USER_ID,
                UserPass = AuthenticationService.USER_PASS
            };

            var authJson = TVDBContract.Serialize(auth);
            var request = this.WebService.CreateBaseRequest();
            request.SetPath("login");
            request.SetContent(authJson);
            return await this.WebService.PostAsync<ApiToken>(request);
        }

        public async Task<ApiToken> RefreshToken()
        {
            var auth = new Authentication
            {
                ApiKey = AuthenticationService.API_KEY,
                UserName = AuthenticationService.USER_ID,
                UserPass = AuthenticationService.USER_PASS
            };

            var authJson = TVDBContract.Serialize(auth);
            var request = this.WebService.CreateBaseRequest();
            request.SetPath("refresh_token");
            request.SetContent(authJson);
            return await this.WebService.GetAsync<ApiToken>(request);
        }
    }
}
