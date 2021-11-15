using KotGospodarczy.MyCode.v1.Basic;
using KotGospodarczy.MyCode.v1.Interfaces;
using KotGospodarczy.MyCode.v1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KotGospodarczy.MyCode.v1.Managers
{
    public class NewsManagerCNBC : NewsManager, INewsManager
    {
        public List<ModelNews> GetNewsList()
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);
            List<ModelNews> ret = new List<ModelNews>();
            for (int i = 1; i <= 10; i++)
            {
                List<ModelNews> tmp = _getSinglePageNewsList();
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

        private List<ModelNews> _getSinglePageNewsList()
        {
            List<ModelNews> ret = new List<ModelNews>();
            string body = GetBody(GetUrl());
            int startIndex = 0;
            string classString = "<h2>";
            string startString = "a href=\"";
            string criticChar = "\"";

            string startString_2 = "title=\"";
            string criticChar_2 = "\"";

            string startString_3 = "timestamp\">";
            string criticChar_3 = "<";

            getIndex_OfPlace_WhereStringIsNext(ref body, ref startIndex, classString);                         //to jest po to zeby startIndex byl maksymalnie blisko wlasciwej wartosci do wyciecia

            for (int i = 0; i < 30; i++)
            {
                string tmp_date = _getBetterValue(ref body, ref startIndex, startString_3, criticChar_3);
                startIndex -= tmp_date.Length;
                string link = _getBetterValue(ref body, ref startIndex, startString, criticChar);
                startIndex -= link.Length;
                string title = _getBetterValue(ref body, ref startIndex, startString_2, criticChar_2);
                startIndex -= title.Length;
                title = title.Trim();
                //DateTime date = DateTime.ParseExact(tmp_date, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

                if (i > 0 && ret[i - 1].Link == link)
                {
                    return ret;
                }
                ret.Add(new ModelNews() { Link = link, Title = title, PublicationDate = _parseDate(tmp_date) });
            }
            return ret;
        }

        public string GetUrl()
        {
            return @"https://www.cnbc.com/world/?region=world";
        }

        private DateTime _parseDate(string badDate)
        {
            string time_mh = "";
            for (int i = 0; i < badDate.Length; i++)
            {
                if (badDate[i] == ' ')
                {
                    switch (badDate[i + 1])
                    {
                        case 'M':
                            return DateTime.Now.AddMinutes(-int.Parse(time_mh));
                        case 'H':
                            return DateTime.Now.AddHours(-int.Parse(time_mh));
                        default:
                            return DateTime.Now.AddDays(-2);
                    }
                }
                else
                {
                    time_mh += badDate[i];
                }
            }
            return DateTime.Now.AddDays(-1);
        }
    }
}
