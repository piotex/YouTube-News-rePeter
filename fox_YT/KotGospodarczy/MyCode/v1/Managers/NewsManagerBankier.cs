using KotGospodarczy.MyCode.v1.Basic;
using KotGospodarczy.MyCode.v1.Interfaces;
using KotGospodarczy.MyCode.v1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KotGospodarczy.MyCode.v1.Managers
{
    public class NewsManagerBankier : NewsManager ,INewsManager
    {
        public List<ModelNews> GetNewsList()
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);
            List<ModelNews> ret = new List<ModelNews>();
            for (int i = 1; i <= 10; i++)
            {
                List<ModelNews> tmp = _getSinglePageNewsList(i);
                for (int j = 0; j < tmp.Count; j++)
                {
                    if (tmp[j].PublicationDate > yesterday)
                    {
                        ret.Add(tmp[j]);
                    }
                    else
                    {
                        return ret;
                    }
                }
            }
            return ret;   
        }

        private List<ModelNews> _getSinglePageNewsList(int pageNumber)
        {
            List<ModelNews> ret = new List<ModelNews>();
            string body = GetBody(GetUrl()+pageNumber);
            int startIndex = 0;
            string classString = "entry-content";
            string startString = "a href=\"";
            string criticChar = "\"";

            string startString_2 = ">";
            string criticChar_2 = "<";

            string startString_3 = "ubdate>";
            string criticChar_3 = "<";

            for (int i = 0; i < 10; i++)
            {
                getIndex_OfPlace_WhereStringIsNext(ref body, ref startIndex, classString);                         //to jest po to zeby startIndex byl maksymalnie blisko wlasciwej wartosci do wyciecia
                string tmp_date = _getBetterValue(ref body, ref startIndex, startString_3, criticChar_3);
                string link = _getBetterValue(ref body, ref startIndex, startString, criticChar);
                string title = _getBetterValue(ref body, ref startIndex, startString_2, criticChar_2);
                title = title.Trim();
                link = @"https://www.bankier.pl" + link;
                DateTime date = DateTime.ParseExact(tmp_date, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

                if (i > 0 && ret[i - 1].Link == link)
                {
                    return ret;
                }
                ret.Add(new ModelNews() { Link = link, Title = title, PublicationDate=date });
            }
            return ret;
        }

        public string GetUrl()
        {
            return @"https://www.bankier.pl/wiadomosc/";
        }
    }
}
