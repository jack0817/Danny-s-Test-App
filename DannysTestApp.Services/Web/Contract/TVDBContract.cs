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

        private void BuildContract(Type contactType)
        {
            this.Mapping.Clear();

            if(contactType == typeof(Authentication))
            {
                this.Mapping.Add("ApiKey", "apikey");
                this.Mapping.Add("UserName", "username");
                this.Mapping.Add("UserPass", "userpass");
                return;
            }

            if(contactType == typeof(ApiToken))
            {
                this.Mapping.Add("Token", "token");
                return;
            }
        }
    }
}
