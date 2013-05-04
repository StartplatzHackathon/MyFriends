using System;
using MyFriends.Services;
using Windows.UI.Xaml.Data;

namespace MyFriends.Converter
{
    public class PersonImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var id = value is Guid ? (Guid) value : Guid.Empty;
            if (id == Guid.Empty)
                return null;

            return  new LoadImages().LoadPersonImage(id);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}