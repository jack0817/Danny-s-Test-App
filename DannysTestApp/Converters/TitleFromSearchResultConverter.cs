using DannysTestApp.Model;
using System;
using Windows.UI.Xaml.Data;

namespace DannysTestApp.Converters
{
    public class TitleFromSearchResultConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var searchResult = value as SearchResult;
            return searchResult.Title ?? searchResult.OriginalTitle;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
