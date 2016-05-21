﻿using DannysTestApp.Commands;
using DannysTestApp.Constants;
using DannysTestApp.Extensions;
using DannysTestApp.Model;
using DannysTestApp.Services;
using DannysTestApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;

namespace DannysTestApp.ViewModels
{
    public class SearchType
    {
        public SearchMediaType MediaType { get; set; }
        public string DisplayName { get; set; }
        public string ApiMediaType { get; set; }
        public string ApiUrlPath { get; set; }
    }

    public class SearchViewModel : ViewModelBase
    {
        private string _searchText;
        private string _outputText;
        private ButtonCommand _searchCommand;
        private bool _isSearching;
        private ObservableCollection<Series> _series = new ObservableCollection<Series>();
        private ObservableCollection<SearchResult> _searchResults = new ObservableCollection<SearchResult>();
        private ObservableCollection<SearchType> _searchTypes = new ObservableCollection<SearchType>();
        private SearchType _selectedSearchType;


        
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

        public ObservableCollection<SearchResult> SearchResults
        {
            get { return this._searchResults; }
        }

        public ObservableCollection<SearchType> SearchTypes
        {
            get { return this._searchTypes; }
        }

        public SearchType SelectedSearchType
        {
            get { return this._selectedSearchType; }
            set
            {
                this._selectedSearchType = value;
                this.NotifyPropertyChanged();

            }
        }
        
        public SearchView ParentView { get; set; }

        private SearchService SearchService { get; set; }


        /// <summary>
        /// Constructor!!! (CTOR for short)
        /// </summary>
        public SearchViewModel()
        {
            this.InitCommands();
            this.SearchService = new SearchService();
            this.CreateDesignData();
            this.LoadSearchTypes();
            this.SetDefaults();
        }

        private void LoadSearchTypes()
        {
            this.SearchTypes.Add(new SearchType { MediaType = SearchMediaType.All, DisplayName = "All", ApiMediaType = null, ApiUrlPath = "search/multi" });
            this.SearchTypes.Add(new SearchType { MediaType = SearchMediaType.Movies, DisplayName = "Movies", ApiMediaType = "movie", ApiUrlPath = "search/movie" });
            this.SearchTypes.Add(new SearchType { MediaType = SearchMediaType.TV, DisplayName = "TV", ApiMediaType = "tv", ApiUrlPath = "search/tv" });
            this.SearchTypes.Add(new SearchType { MediaType = SearchMediaType.Person, DisplayName = "Person", ApiMediaType = "person", ApiUrlPath = "search/person" });
        }

        private void CreateDesignData()
        {
            if (!DesignMode.DesignModeEnabled)
                return;

            var serachResult1 = new SearchResult
            {
                Title = "Design Result 001",
                OriginalTitle = "Design Result 001",
                Overview = DesignConstants.LOREM_IPSUM,
            };

            var serachResult2 = new SearchResult
            {
                Title = "Design Result 002",
                OriginalTitle = "Design Result 002",
                Overview = DesignConstants.LOREM_IPSUM,
            };

            this.SearchResults.Add(serachResult1);
            this.SearchResults.Add(serachResult2);
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
            this.ParentView.UserSearchType = this.SelectedSearchType;

            this.IsSearching = true;

            this.SearchResults.Clear();
            var resultsPage = await this.SearchService.SearchMultiAsync(this.SearchText, this.SelectedSearchType.ApiUrlPath);
            if(resultsPage != null)
            {
                this.SearchResults.AddRange(resultsPage.Results);  
            }

            this.IsSearching = false;
        }
        private void SetDefaults()
        {
            this.SelectedSearchType = this.SearchTypes.ElementAt(0);
        }
    }
}
