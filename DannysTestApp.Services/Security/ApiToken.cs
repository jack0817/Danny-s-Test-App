using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannysTestApp.Services.Security
{
    public class ApiToken
    {
        public string Token { get; set; }
        public string Error { get; set; }
        public bool Success { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
