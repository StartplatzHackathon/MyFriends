using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace MyFriends.DataModel
{
    public static class ImageManager
    {
        public static BitmapImage GetGiftImage(Guid giftId)
        {
            var bitmapImage = new BitmapImage();

            Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.High, async () =>
            {
                String imageName = String.Format("{0:N}", giftId);
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
