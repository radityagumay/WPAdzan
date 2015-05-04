using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using wpadzan.Models;
using HtmlAgilityPack;
using System.Diagnostics;
using System.Net;
using System.IO;
using System.Windows;

namespace wpadzan.Services
{
    public class Services : IServices
    {
        private string url = "http://jadwalwaktusholat.info/monthly.php?id=";
        //http://blog.galasoft.ch/posts/2013/01/using-asyncawait-with-webclient-in-windows-phone-8-or-taskcompletionsource-saves-the-day/
        //http://www.codeproject.com/Articles/156610/WP-WebClient-vs-HttpWebRequest
        public void getData(string id, Action<AdzanModel, Exception> callback)
        {
            var request = (HttpWebRequest)WebRequest.Create(new Uri(url + 1));
            request.BeginGetResponse(r =>
            {
                var httpRequest = (HttpWebRequest)r.AsyncState;
                var httpResponse = (HttpWebResponse)httpRequest.EndGetResponse(r);

                using (var reader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var response = reader.ReadToEnd();
                    Deployment.Current.Dispatcher.BeginInvoke(new Action(() =>
                    {
                        HtmlDocument doc = new HtmlDocument();
                        doc.LoadHtml(response);

                        HtmlNode table = (from d in doc.DocumentNode.Descendants()
                                          where d.Name == "tr"
                                          select d).First();

                        IEnumerable<HtmlNode> row = from d in table.Descendants() where d.Name == "tr" select d;

                        foreach (HtmlNode node in row)
                        { 

                        }

                        Debug.WriteLine("RADITYA GUMAY");
                        //callback.Invoke(text, new Exception());
                    }));
                }
            }, request);

            //var requestUri = url + id;
            //var request = (HttpWebRequest)WebRequest.Create(requestUri);
            //using (request as IDisposable)
            //{
            //    // fetching HTML
            //    WebClient client = new WebClient();

            //    string pixarHtml = client.DownloadString("http://en.wikipedia.org/wiki/List_of_Pixar_films");

            //    HtmlDocument document = new HtmlDocument();
            //    document.LoadHtml(pixarHtml);

            //    HtmlNode pixarTable = (from d in document.DocumentNode.Descendants()
            //                           where d.Name == "table" && d.Attributes["class"].Value == "sortable wikitable"
            //                           select d).First();

            //    IEnumerable<HtmlNode> pixarRows = from d in pixarTable.Descendants() where d.Name == "tr" select d;

            //    // removing first row that contains header information
            //    pixarRows.ElementAt(0).Remove();

            //    foreach (HtmlNode row in pixarRows)
            //    {
            //        IEnumerable<HtmlNode> columns = from d in row.Descendants() where d.Name == "td" select d;

            //        int count = 0;
            //        string title = string.Empty;

            //        foreach (HtmlNode column in columns)
            //        {
            //            if (count > 1)
            //                break;

            //            if (count == 0)
            //            {
            //                title = column.Element("i").Element("a").InnerText;
            //            }
            //            else
            //            {
            //                Console.WriteLine(column.InnerText + " - " + title);
            //            }
            //            count++;
            //        }
            //    }
            //}

            //var client = new WebClient();
            //client.DownloadStringCompleted += (s, e) =>
            //{
            //    try
            //    {
            //        if (e.Error == null)
            //        {
            //            // TODO this things in here
            //            using (HtmlNode node in e.d)
                        
            //            AdzanModel model = new AdzanModel();
            //            callback.Invoke(model, new Exception());
            //        }
            //        else
            //        {
            //            callback.Invoke(null, e.Error);                      
            //        }
            //    }
            //    catch
            //    { 
                
            //    }
            //};

            //client.DownloadStringAsync(new Uri(url + id), UriKind.RelativeOrAbsolute);
        }
    }
}
