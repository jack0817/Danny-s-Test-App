using DannysTestApp.Services.Security;
using DannysTestApp.Services.Web.Contract;
using System.Threading.Tasks;

namespace DannysTestApp.Services
{
    public class AuthenticationService : ServiceBase
    {
        public async Task<ApiToken> GetTokenAsync()
        {
            var request = this.WebService.CreateAuthorizationRequest();
            //return await this.WebService.PostAsync<ApiToken>(request);
            return await this.WebService.GetAsync<ApiToken>(request);
        }

        public async Task<ApiToken> RefreshToken()
        {
            var request = this.WebService.CreateAuthorizationRequest();
            return await this.WebService.GetAsync<ApiToken>(request);
        }
    }
}
