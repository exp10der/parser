//using System.IO;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;



//namespace ParserBL
//{
//    /// <summary>
//    /// Класс для скачивания исходного кода страницы
//    /// </summary>
//    public class HtmlDownloadHelper
//    {
//        /// <summary>
//        /// Скачать страницу
//        /// </summary>
//        /// <param name="url">страница сайта</param>
//        /// <returns>исходный код</returns>
//        public static async Task<string> DownloadHtml(string url)
//        {

//            try
//            {
//                string html;
//                var webReq = (HttpWebRequest)WebRequest.Create(url);
//                using (WebResponse response = await webReq.GetResponseAsync())
//                {response.Headers
//                    using (StreamReader responseStream = new StreamReader(response.GetResponseStream()))
//                    {
//                        html = responseStream.ReadToEnd();
//                    }
//                }
//                return html;


//            }
//            catch (WebException)
//            {

//                return "Немогу скачать";
//            }
//        }

        // public void Coding()
        // {
        //    var resp = (HttpWebResponse)await webReq.GetResponseAsync();

        //    using (var stream = new StreamReader(stream: resp.GetResponseStream(), encoding: Encoding.GetEncoding(resp.CharacterSet)))
        //    {
        //        html = stream.ReadToEnd();
        //    }
        //    return html;
        //}

//    }
//}

using System.IO;
using System.Net;
using System.Text;


namespace Pars.MyToolsLibrary
{
    class HtmlDownloadHelper
    {
        /// <summary>
        /// Скачать страницу
        /// </summary>
        /// <param name="uri">страница сайта</param>
        /// <returns>исходный код</returns>
        public static string DownloadHtml(string uri)
        {
            try
            {
                var req = (HttpWebRequest)WebRequest.Create(uri);
                var resp = (HttpWebResponse)req.GetResponse();
                if (resp.CharacterSet == "")
                    return uri;
                using (var stream = new StreamReader(stream: resp.GetResponseStream(), encoding: Encoding.GetEncoding(resp.CharacterSet)))
                {
                    var html = stream.ReadToEnd();
                    return html;
                }

            }

            catch (WebException)
            {
                 return "-1";
            }

        }
    }
}
