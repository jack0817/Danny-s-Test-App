using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannysTestApp.Services.Web
{
    public interface IWebService
    {
        WebServiceRequest CreateBaseRequest();
        Task<T> GetAsync<T>(WebServiceRequest request);
        Task<T> PostAsync<T>(WebServiceRequest request);
    }
}
