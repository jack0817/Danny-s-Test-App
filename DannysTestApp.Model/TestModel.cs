using SQLite.Net.Attributes;
using System;

namespace DannysTestApp.Model
{
    public class TestModel
    {
        [PrimaryKey]
        public string TestModelId { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Average { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
