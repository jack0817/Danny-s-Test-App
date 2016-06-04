using DannysTestApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;

namespace DannysTestApp.ViewModels
{
    public class SearchResultViewModel : ViewModelBase
    {
        private SearchResult _model;
        private string _fullImagePath;
        private ImageSource _image;

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
