using DannysTestApp.Commands;
using DannysTestApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DannysTestApp.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private string _searchText;
        private string _outputText;
        private ButtonCommand _searchCommand;

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

        private SearchService SearchService { get; set; }

        public SearchViewModel()
        {
            this.InitCommands();
            this.SearchService = new SearchService();
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
            var results = await this.SearchService.SearchSeriesAsync(this.SearchText);
            this.OutputText = results == null || results.Count == 0 ? "No results found" : string.Format("{0} result(s) found", results.Count);
        }
    }
}
