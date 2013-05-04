using System;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace MyFriends.Services
{
    public class LoadImages
    {
        BitmapImage LoadImage(string folderName, Guid id)
        {
            var bitmapImage = new BitmapImage();

            Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.High, async () =>
            {
                var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);
                try
                {
                    var imageFile = await folder.GetFileAsync(String.Format("{0}", id));
                    await bitmapImage.SetSourceAsync(await imageFile.OpenReadAsync());
                }
                catch { }
            });

            return bitmapImage;
        }

        public BitmapImage LoadGiftImage(Guid id)
        {
            return LoadImage("GiftImages", id);
        }

        public BitmapImage LoadPersonImage(Guid id)
        {
            return LoadImage("PersonImages", id);
        }
    }
}