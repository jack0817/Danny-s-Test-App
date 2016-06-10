using DannysTestApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace DannysTestApp.ViewModels
{
    public enum SearchMediaType
    {
        Unknown,
        All,
        Movies,
        TV,
        Person,
    }

    public class SearchResultViewModel : ViewModelBase
    {
        private SearchResult _model;
        private string _fullImagePath;
        private string _fullPosterPath;
        private string _fullProfilePath;
        private ImageSource _image;
        private string _userSelectedMediaType;


        public SearchResult Model
        {
            get
            {
                return this._model;
            }
            set
            {
                this._model = value;
                this.NotifyPropertyChanged();
            }
        }

        public string FullImagePath
        {
            get { return this._fullImagePath; }
            set
            {
                this._fullImagePath = value;
                this.NotifyPropertyChanged();
            }
        }

        public string FullPosterPath
        {
            get { return this._fullPosterPath; }
            set
            {
                this._fullPosterPath = value;
                this.NotifyPropertyChanged();
            }
        }

        public string FullProfilePath
        {
            get { return this._fullProfilePath; }
            set
            {
                this._fullProfilePath = value;
                this.NotifyPropertyChanged();
            }
        }

        public string UserSelectedMediaType
        {
            get { return this._userSelectedMediaType; }
            set
            {
                this._userSelectedMediaType = value;
                this.NotifyPropertyChanged();
            }
        }

        public SearchMediaType MediaType
        {
            get
            {
                var mediaType = this.Model.MediaType ?? this.UserSelectedMediaType;
                switch (mediaType)
                {
                    case "tv":
                        return SearchMediaType.TV;
                    case "movie":
                        return SearchMediaType.Movies;
                    case "person":
                        return SearchMediaType.Person;
                    default:
                        return SearchMediaType.Unknown;
                }
            }
        }

        //public ImageSource Image
        //{
        //    get
        //    {
        //        return this._image;
        //    }
        //    set
        //    {
        //        this._image = value;
        //        this.NotifyPropertyChanged();
        //    }


        //}

        public SearchResultViewModel(SearchResult model)
        {
            this.Model = model;
        }
    }
}
