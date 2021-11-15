using KotGospodarczy.MyCode.v1.Basic;
using KotGospodarczy.MyCode.v1.Interfaces;
using KotGospodarczy.MyCode.v1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace KotGospodarczy.MyCode.v1.Managers
{
    public class NewsManagerFoxNews : NewsManager, INewsManager
    {
        public List<ModelNews> GetNewsList()
        {
            List<ModelNews> ret = new List<ModelNews>();

            List<ModelNews> tmp_1 = _getXXXPageNewsList("economy");
            List<ModelNews> tmp_2 = _getXXXPageNewsList("markets");
            List<ModelNews> tmp_3 = _getXXXPageNewsList("lifestyle");
            List<ModelNews> tmp_4 = _getXXXPageNewsList("real-estate");
            List<ModelNews> tmp_5 = _getXXXPageNewsList("technology");

            ret.AddRange(tmp_1);
            ret.AddRange(tmp_2);
            ret.AddRange(tmp_3);
            ret.AddRange(tmp_4);
            ret.AddRange(tmp_5);

            List<ModelNews> ret2 = ret.GroupBy(x => x.Link).Select(y => y.First()).ToList();

            return ret2;
        }

        private List<ModelNews> _getXXXPageNewsList(string xxx)
        {
            List<ModelNews> ret = new List<ModelNews>();
            string body = GetBody(GetUrl() + xxx);
            int startIndex = 0;

            _goToStartOfPage(ref body, ref startIndex);

            for (int i = 0; i <= 15; i++)
            {
                string cor_date_format = _getGoodDate(ref body, ref startIndex);

                string link = _getGoodLink(ref body, ref startIndex);

                string title = _getGoodTitle(ref body, ref startIndex);


                DateTime date = DateTime.Now.AddDays(-2);
                if (cor_date_format != "")
                {
                    date = _parseDate(cor_date_format);
                    if (date <= DateTime.Now.AddDays(-1))
                    {
                        return ret;
                    }
                }
                ret.Add(new ModelNews() { Title = title, Link = link, PublicationDate = date });
            }
            return ret;
        }








        private void _goToStartOfPage(ref string body, ref int startIndex)
        {
            string classString = "<h3";
            getIndex_OfPlace_WhereStringIsNext(ref body, ref startIndex, classString);                         //to jest po to zeby startIndex byl maksymalnie blisko wlasciwej wartosci do wyciecia
            startIndex -= 100;
        }

        private string _getGoodDate(ref string body, ref int startIndex)
        {
            string startString_data = "ass=\"time\">";
            string criticChar_data = "<";

            return _getBetterValue(ref body, ref startIndex, startString_data, criticChar_data);
        }
        private string _getGoodTitle(ref string body, ref int startIndex)
        {
            string startString_title = "aria-label=\"";
            string criticChar_title = "\">";

            string title = _getBetterValue(ref body, ref startIndex, startString_title, criticChar_title);

            startIndex -= title.Length;
            return title.Trim();
        }
        private string _getGoodLink(ref string body, ref int startIndex)
        {
            string startString_link = "a href=\"";
            string criticChar_link = "\"";

            string link = _getBetterValue(ref body, ref startIndex, startString_link, criticChar_link);
            startIndex -= link.Length;

            return GetUrl() + link;
        }

        public string GetUrl()
        {
            return @"https://www.foxbusiness.com/";
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
                        case 'm':
                            return DateTime.Now.AddMinutes(-int.Parse(time_mh));
                        case 'h':
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
