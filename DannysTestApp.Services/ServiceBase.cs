using DannysTestApp.Services.Data;
using DannysTestApp.Services.Web;

namespace DannysTestApp.Services
{
    public abstract class ServiceBase
    {
        private IWebService _webService;

        protected IWebService WebService
        {
            get
            {
                if(this._webService == null)
                {
                    //this._webService = new TVDBWebService();
                    this._webService = new TheMovieDbService();
                }

                return this._webService;
            }
        }

        protected DataContext DataContext
        {
            get { return DataContext.Shared; }
        }
    }
}
