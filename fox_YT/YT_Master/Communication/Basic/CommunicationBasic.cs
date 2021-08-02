using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace YT_Master.Communication.Basic
{
    public abstract class CommunicationBasic
    {
        protected string GetBody(string url)
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
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
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
