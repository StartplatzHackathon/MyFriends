using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media.Imaging;

namespace MyFriends.Services
{
    public class StoreImages
    {
        public StoreImages()
        {
            
        }

        async public Task StorePerson(IRandomAccessStreamWithContentType stream, Guid id)
        {
            await StoreImage("PersonImages", stream, id);
        }
        async public Task StoreGift(IRandomAccessStreamWithContentType stream, Guid id)
        {
            await StoreImage("GiftImages", stream, id);
        }

        static async Task StoreImage(string folderName, IRandomAccessStreamWithContentType stream, Guid id)
        {
            var folder =
                await ApplicationData.Current.LocalFolder.CreateFolderAsync(folderName, CreationCollisionOption.OpenIfExists);

            var file = await folder.CreateFileAsync(string.Format("{0}", id));

            using (var newFileStream = await file.OpenStreamForWriteAsync())
            {
                stream.AsStreamForRead().CopyTo(newFileStream);
            }
        }
    }

    public class LoadImages
    {
        public LoadImages()
        {
              
        }

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