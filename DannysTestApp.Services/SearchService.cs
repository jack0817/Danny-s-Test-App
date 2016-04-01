using DannysTestApp.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DannysTestApp.Services
{
    internal class SearchResults
    {
        public List<Series> Data { get; set; }
    }

    public class SearchService : ServiceBase
    {
        public async Task<List<Series>> SearchSeriesAsync(string query)
        {
            var request = this.WebService.CreateBaseRequest();
            request.SetPath("search/series");
            request.AddParameter("name", query);

            var results = await this.WebService.GetAsync<SearchResults>(request);
            if (results == null)
                return null;

            return results.Data;
        }
    }
}
