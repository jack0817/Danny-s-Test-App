using DannysTestApp.Model;
using System.Collections.Generic;
using System.Text;
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
            //var request = this.WebService.CreateBaseRequest();
            //request.SetPath("search/series");
            //request.AddParameter("name", query);

            //var results = await this.WebService.GetAsync<SearchResults>(request);
            //if (results == null)
            //    return null;

            //return results.Data;
            await Task.Yield();

            var series1 = new Series
            {
                SeriesName = "Marky",
                Network = "NBC",
                Overview = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",

            };

            var series2 = new Series
            {
                SeriesName = "Danny",
                Network = "Fox",
                Overview = "I am the one who knocks!",

            };

            return new List<Series> { series1, series2 };
        }

        public async Task<SearchResultPage> SearchMultiAsync(string query, string searchType)
        {
            var urlQuery = this.GetCgiEscapedString(query);
            var request = this.WebService.CreateBaseRequest();
            switch(searchType)
            {
                case "All":
                    request.SetPath("search/multi");
                    break;
                case "TV":
                    request.SetPath("search/tv");
                    break;
                case "Movies":
                    request.SetPath("search/movie");
                    break;
                case "People":
                    request.SetPath("search/person");
                    break;
            }
            request.AddParameter("query", urlQuery);
            return await this.WebService.GetAsync<SearchResultPage>(request);
        }

        private string GetCgiEscapedString(string originalString)
        {
            var escapedString = new StringBuilder(originalString);
            escapedString.Replace(" ", "%20");
            return escapedString.ToString();
        }
    }
}
