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
            var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("PersonImages", CreationCollisionOption.OpenIfExists);

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

        public BitmapImage LoadPersonImage(Guid id)
        {
            var bitmapImage = new BitmapImage();

            Window.Current.Dispatcher.RunAsync(CoreDispatcherPriority.High, async () =>
            {
                var folder = await ApplicationData.Current.LocalFolder.CreateFolderAsync("PersonImages", CreationCollisionOption.OpenIfExists);
                try
                {
                    var imageFile = await folder.GetFileAsync(String.Format("{0}", id));
                    await bitmapImage.SetSourceAsync(await imageFile.OpenReadAsync());
                }
                catch { }
            });

            return bitmapImage;
        }
    }
}