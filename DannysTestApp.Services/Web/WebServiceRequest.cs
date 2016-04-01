using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DannysTestApp.Services.Web
{
    public class WebServiceRequest
    {
        public string BaseUrl { get; private set; }
        public string Path { get; private set; }
        public object Content { get; private set; }
        public Dictionary<string, string> Parameters { get; private set; }

        public WebServiceRequest(string baseUrl)
        {
            this.BaseUrl = baseUrl;
            this.Parameters = new Dictionary<string, string>();
        }

        public void SetPath(string path)
        {
            this.Path = path;
        }

        public void SetContent(object content)
        {
            this.Content = content;
        }


        public void AddParameter(string name, string value)
        {
            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(value))
                return;

            this.Parameters.Add(name, value);
        }

        public string GetUrl()
        {
            var urlBuilder = new StringBuilder();
            urlBuilder.Append(this.BaseUrl);
            urlBuilder.Append(this.GetPathString());
            urlBuilder.Append(this.GetParameterString());
            return urlBuilder.ToString();
        }

        public HttpContent GetContent()
        {
            if (this.Content == null)
                return null;

            return new StringContent(this.Content.ToString(), Encoding.UTF8, "application/json");
        }

        private string GetPathString()
        {
            return string.IsNullOrEmpty(this.Path) ? string.Empty : this.Path;
        }

        private string GetParameterString()
        {
            if (this.Parameters.Count == 0)
                return string.Empty;

            var paramStrings = this.Parameters.Select(entry => string.Format("{0}={1}", entry.Key, entry.Value));
            return string.Format("?{0}", string.Join("&", paramStrings));
        }
    }
}
