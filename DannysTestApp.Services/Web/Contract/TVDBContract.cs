using DannysTestApp.Model;
using DannysTestApp.Services.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannysTestApp.Services.Web.Contract
{
    public class TVDBContract : DefaultContractResolver
    {
        private static JsonSerializerSettings _settings;

        private static JsonSerializerSettings Settings
        {
            get
            {
                if(TVDBContract._settings == null)
                {
                    TVDBContract._settings = new JsonSerializerSettings();
                    TVDBContract._settings.ContractResolver = new TVDBContract();
                }

                return TVDBContract._settings;
            }
        }

        private Dictionary<string, string> Mapping = new Dictionary<string, string>();

        public static T Deserialize<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString, TVDBContract.Settings);
        }

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, TVDBContract.Settings);
        }

        #region JsonSerializerSettings
        protected override JsonContract CreateContract(Type objectType)
        {
            this.BuildContract(objectType);
            return base.CreateContract(objectType);
        }
        protected override string ResolvePropertyName(string propertyName)
        {
            if (this.Mapping.ContainsKey(propertyName))
                return this.Mapping[propertyName];

            return base.ResolvePropertyName(propertyName);
        }
        #endregion

        private void BuildContract(Type contractType)
        {
            this.Mapping.Clear();

            if(contractType == typeof(Authentication))
            {
                this.Mapping.Add("ApiKey", "apikey");
                this.Mapping.Add("UserName", "username");
                this.Mapping.Add("UserPass", "userpass");
                return;
            }

            if(contractType == typeof(ApiToken))
            {
                this.Mapping.Add("Token", "token");
                return;
            }

            if (contractType == typeof(SearchResults))
            {
                this.Mapping.Add("Data", "data");
                return;
            }

            if (contractType == typeof(Series))
            {   
                this.Mapping.Add("SeriesId", "id");
                this.Mapping.Add("SeriesName", "seriesName");
                this.Mapping.Add("Banner", "banner");
                this.Mapping.Add("FirstAired", "firstAired");
                this.Mapping.Add("Network", "network");
                this.Mapping.Add("Overview", "overview");
                this.Mapping.Add("Status", "status");
                this.Mapping.Add("Aliases", "aliases");
                return;
            }
        }
    }
}
