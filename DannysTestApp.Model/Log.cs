using DannysTestApp.Model.Extensions;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannysTestApp.Model
{
    public class Log
    {
        [PrimaryKey]
        public string LogId { get; set; }
        public string Source { get; set; }
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public DateTime LogDate { get; set; }
    }
}
