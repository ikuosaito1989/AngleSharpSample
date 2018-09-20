using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AngleSharp.Parser.Html;

namespace AngleSharpSample {
    class Program {
        static void Main (string[] args) {
            AngleSharpSample ().Wait ();
        }

        public static async Task AngleSharpSample () {
            var url = "https://mygkrnk.com/";
            var client = new HttpClient ();
            var response = await client.GetAsync (url);
            var html = await response.Content.ReadAsStringAsync ();

            var parser = new HtmlParser ();
            var doc = parser.Parse (html);
            var likeApp = doc.GetElementsByClassName ("like-app");
            var count = likeApp.First().Attributes["react-prop-counts"].Value;

            var titles = doc.GetElementsByClassName ("entry-title");
            var title = titles.Where(x => x.InnerHtml.Contains("In My Feelings")).First().InnerHtml;

            Console.Write(count);
            Console.Write(title);
        }
    }
}