using DannysTestApp.Commands;
using DannysTestApp.Model;
using DannysTestApp.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace DannysTestApp.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private string _searchText;
        private string _outputText;
        private ButtonCommand _searchCommand;
        private bool _isSearching;
        private ObservableCollection<Series> _series = new ObservableCollection<Series>();

        
        public string SearchText
        {
            get { return this._searchText; }
            set
            {
                this._searchText = value;
                this.NotifyPropertyChanged();
                this.SearchCommand.FireCanExecuteChanged();
            }
        }

        public string OutputText
        {
            get { return this._outputText; }
            set
            {
                this._outputText = value;
                this.NotifyPropertyChanged();
            }
        }

        public ButtonCommand SearchCommand
        {
            get { return this._searchCommand; }
            set
            {
                this._searchCommand = value;
                this.NotifyPropertyChanged();
            }
        }

        public bool IsSearching
        {
            get { return this._isSearching; }
            set
            {
                this._isSearching = value;
                this.NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Series> Series
        {
            get { return this._series; }              
        }

        private SearchService SearchService { get; set; }

        /// <summary>
        /// Constructor!!! (CTOR for short)
        /// </summary>
        public SearchViewModel()
        {
            this.InitCommands();
            this.SearchService = new SearchService();
            this.CreateDesignData();
        }

        private void CreateDesignData()
        {
            if (!DesignMode.DesignModeEnabled)
                return;
            var series1 = new Series
            {
                SeriesName = "Marky",
                Network = "NBC",
                Overview = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",

            };

            var series2 = new Series
            {
                SeriesName = "Danny",
                Network = "Fox",
                Overview = "I am the one who knocks!",

            };
            this.Series.Add(series1);
            this.Series.Add(series2);
        }

        private void InitCommands()
        {
            this.SearchCommand = new ButtonCommand(this.PerformSearch, this.CanPerformSearch);
        }

        private bool CanPerformSearch()
        {
            return !string.IsNullOrEmpty(this.SearchText);
        }

        private async void PerformSearch()
        {
            this.IsSearching = true;

            var results = await this.SearchService.SearchSeriesAsync(this.SearchText);
            this.OutputText = results == null || results.Count == 0 ? "No results found" : string.Format("{0} result(s) found", results.Count);

            this.IsSearching = false;
        }
    }
}
