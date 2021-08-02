using System;
using System.Collections.Generic;
using System.Text;

namespace YT_Master.Communication.Slaves
{
    public class CommunicationBankier
    {
        /*--------------------------------------------------------------------------------------------------------------------------------
            string url = @"https://www.bankier.pl/rynki/wiadomosci/2";
            List<string> list_of_links = new List<string>();
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
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
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            /*--------------------------------------------------------------------------------------------------------------------------------*/
    }
}
