using DannysTestApp.Model;
using DannysTestApp.Services.Security;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;

namespace DannysTestApp.Services.Web.Contract
{
    public class TheMovieDbContract : DefaultContractResolver
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss UTC";
        private static JsonSerializerSettings _settings;

        private static JsonSerializerSettings Settings
        {
            get
            {
                if (TheMovieDbContract._settings == null)
                {
                    TheMovieDbContract._settings = new JsonSerializerSettings();
                    TheMovieDbContract._settings.DateFormatString = TheMovieDbContract.DATE_FORMAT;
                    TheMovieDbContract._settings.ContractResolver = new TheMovieDbContract();
                }

                return TheMovieDbContract._settings;
            }
        }

        private Dictionary<string, string> Mapping = new Dictionary<string, string>();

        public static T Deserialize<T>(string jsonString)
        {
            return JsonConvert.DeserializeObject<T>(jsonString, TheMovieDbContract.Settings);
        }

        public static string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, TheMovieDbContract.Settings);
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

            if (contractType == typeof(Authentication))
            {
                this.Mapping.Add("ApiKey", "apikey");
                this.Mapping.Add("UserName", "username");
                this.Mapping.Add("UserPass", "userpass");
                return;
            }

            if (contractType == typeof(ApiToken))
            {
                this.Mapping.Add("Token", "request_token");
                this.Mapping.Add("Success", "success");
                this.Mapping.Add("ExpireDate", "expires_at");
                return;
            }

            if (contractType == typeof(SearchResultPage))
            {
                this.Mapping.Add("Page", "page");
                this.Mapping.Add("TotalPages", "total_pages");
                this.Mapping.Add("TotalResults", "total_results");
                this.Mapping.Add("Results", "results");
                return;
            }

            if (contractType == typeof(SearchResult))
            {
                this.Mapping.Add("IsAdult", "adult");
                this.Mapping.Add("BackdropPath", "backdrop_path");
                this.Mapping.Add("ResultId", "id");
                this.Mapping.Add("OriginalLanguage", "original_language");
                this.Mapping.Add("OriginalTitle", "original_title");
                this.Mapping.Add("Overview", "overview");
                this.Mapping.Add("ReleaseDate", "release_date");
                this.Mapping.Add("FirstAirDate", "first_air_date");
                this.Mapping.Add("PosterPath", "poster_path");
                this.Mapping.Add("Popularity", "popularity");
                this.Mapping.Add("Title", "title");
                this.Mapping.Add("HasVideo", "video");
                this.Mapping.Add("VoteAverage", "vote_average");
                this.Mapping.Add("VoteCount", "vote_count");
                this.Mapping.Add("MediaType", "media_type");
                this.Mapping.Add("Genres", "genre_ids");
                this.Mapping.Add("Name", "name");
                return;
            }
        }
    }
}
