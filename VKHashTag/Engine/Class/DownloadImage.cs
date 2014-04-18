using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace VKHashTag.Engine.Class
{
    class DownloadImage
    {
        public async Task<BitmapImage> BitmapImageAsync(string url)
        {
            Stream stream = null;
            HttpClient WebClient = new HttpClient();
            BitmapImage image = new BitmapImage();

            try
            {
                stream = new MemoryStream(await WebClient.GetByteArrayAsync(url));
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = stream;
                image.EndInit();
                image.Freeze();
            }
            catch { }

            if (stream != null)
            {
                stream.Close(); stream.Dispose(); stream = null;
            }

            url = null; WebClient.CancelPendingRequests(); WebClient.Dispose(); WebClient = null;
            return image;
        }



        public BitmapImage BitmapImage(string url)
        {
            Stream stream = null;
            WebClient webClient = new WebClient();
            BitmapImage image = new BitmapImage();

            try
            {
                stream = new MemoryStream(webClient.DownloadData(url));
                image.BeginInit();
                image.CacheOption = BitmapCacheOption.OnLoad; // here
                image.StreamSource = stream;
                image.EndInit();
                image.Freeze();
            }
            catch { }

            if (stream != null)
            {
                stream.Close(); stream.Dispose(); stream = null;
            }

            url = null; webClient.Dispose(); webClient = null;
            return image;
        }
    }
}
