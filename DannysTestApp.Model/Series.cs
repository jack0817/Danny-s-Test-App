using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;

namespace DannysTestApp.Model
{
    public class Series
    {
        [PrimaryKey]
        public string SeriesId { get; set; }
        public string SeriesName { get; set; }
        public string Banner { get; set; }
        public DateTime? FirstAired { get; set; }
        public string Network { get; set; }
        public string Overview { get; set; }
        public string Status { get; set; }

        [Ignore]
        public List<string> Aliases { get; set; }
    }
}
