using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace DannysTestApp.Services
{
    public class AppSettingsService
    {
        public struct Keys
        {
            public const string API_KEY = "AppApiKey";
        }

        private ApplicationDataContainer Settings
        {
            get { return ApplicationData.Current.LocalSettings; }
        }

        public string GetValue(string key)
        {
            return this.Settings.Values[key] as string;
        }

        public void SetValue(string key, string value)
        {
            this.Settings.Values[key] = value;
        }
    }
}
