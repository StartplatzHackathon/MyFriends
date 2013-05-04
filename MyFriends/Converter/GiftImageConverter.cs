using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace MyFriends.Converter
{
    public class GiftImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is Guid)
            {
                var imageId = (Guid)value;
                return imageId != Guid.Empty ? CreateBitmapImage(imageId) : null;
            }
            else
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        private BitmapImage CreateBitmapImage(Guid imageId)
        {            
            var bitmapImage = new BitmapImage();

            Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.High, async () => 
            {
                String imageName = String.Format("{0:N}", imageId);
                var folder = await ApplicationData.Current.RoamingFolder.CreateFolderAsync("GiftImages", CreationCollisionOption.OpenIfExists);
                try
                {
                    var imageFile = await folder.GetFileAsync(imageName);
                    await bitmapImage.SetSourceAsync(await imageFile.OpenReadAsync());
                }
                catch { }
            });

            return bitmapImage;
        }
    }
}
