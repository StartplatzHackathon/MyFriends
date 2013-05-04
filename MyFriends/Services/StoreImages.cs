using System;
using System.IO;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace MyFriends.Services
{
    public class StoreImages
    {
        async public Task StorePersonImage(IRandomAccessStreamWithContentType stream, Guid id)
        {
            await StoreImage("PersonImages", stream, id);
        }
        async public Task StoreGiftImage(IRandomAccessStreamWithContentType stream, Guid id)
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

}