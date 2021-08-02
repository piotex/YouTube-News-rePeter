using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using YT_Master.Communication.Basic;

namespace YT_Master.Communication.Slaves
{
    public class CommunicationBankier : CommunicationBasic
    {
        public string GetBodyBankierNews(int page)
        {
            string url = @"https://www.bankier.pl/rynki/wiadomosci/" + page.ToString();
            return GetBody(url);
        }
    }
}
