using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace KotGospodarczy.MyCode.v1.Basic
{
    public class NewsManager : StringCuttingOperations
    {
        public string GetBody(string url)
        {
            string body = "";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;
                    if (String.IsNullOrWhiteSpace(response.CharacterSet))
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.UTF8);
                    }
                    body = readStream.ReadToEnd();

                    response.Close();
                    readStream.Close();
                }
            }
            return body;
        }
    }
}
