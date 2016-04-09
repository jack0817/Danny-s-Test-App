using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannysTestApp.Model
{
    public class SearchResult
    {    
        public bool IsAdult { get; set; }
        public string BackdropPath { get; set; }
        public int ResultId { get; set; }
        public string OriginalLanguage { get; set; }
        public string OriginalTitle { get; set; }
        public string Overview { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string PosterPath { get; set; }
        public double Popularity { get; set; }
        public string Title { get; set; }
        public bool HasVideo { get; set; }
        public double VoteAverage { get; set; }
        public int VoteCount { get; set; }
        public string MediaType { get; set; }

        [Ignore]
        public List<int> Genres { get; set; }

    }
}
