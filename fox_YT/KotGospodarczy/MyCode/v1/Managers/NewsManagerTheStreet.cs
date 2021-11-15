using KotGospodarczy.MyCode.v1.Basic;
using KotGospodarczy.MyCode.v1.Interfaces;
using KotGospodarczy.MyCode.v1.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace KotGospodarczy.MyCode.v1.Managers
{
    public class NewsManagerTheStreet : NewsManager, INewsManager
    {
        public List<ModelNews> GetNewsList()
        {
            //return _getInvestionPageNewsList();
            DateTime yesterday = DateTime.Now.AddDays(-1);
            List<ModelNews> ret = new List<ModelNews>();

            List<ModelNews> tmp = _getXXXPageNewsList("investing");
            List<ModelNews> tmp2 = _getXXXPageNewsList("personal-finance");
            List<ModelNews> tmp3 = _getXXXPageNewsList("retirement");
            //List<ModelNews> tmp4 = _getXXXPageNewsList("crypto");
            List<ModelNews> tmp5 = _getXXXPageNewsList("how-to");
            List<ModelNews> tmp6 = _getXXXPageNewsList("video");
            List<ModelNews> tmp7 = _getXXXPageNewsList("financial-advisor-center");
            List<ModelNews> tmp8 = _getXXXPageNewsList("technology");
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
            return ret;
        }

        private List<ModelNews> _getXXXPageNewsList(string xxx)
        {
            List<ModelNews> ret = new List<ModelNews>();
            string body = GetBody(GetUrl()+ xxx);
            int startIndex = 0;

            _goToStartOfPage(ref body, ref startIndex);

            for (int i = 0; i <= 12; i++)
            {
                string link = _getGoodLink(ref body, ref startIndex);

                string title = _getGoodTitle(ref body, ref startIndex);

                string cor_date_format = _getGoodDate(link);

                DateTime date = DateTime.Now.AddDays(-2);
                if (cor_date_format != "")
                {
                    date = DateTime.ParseExact(cor_date_format, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
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
            string classString = "<h2";

            getIndex_OfPlace_WhereStringIsNext(ref body, ref startIndex, classString);                         //to jest po to zeby startIndex byl maksymalnie blisko wlasciwej wartosci do wyciecia
            getIndex_OfPlace_WhereStringIsNext(ref body, ref startIndex, classString);                         //to jest po to zeby startIndex byl maksymalnie blisko wlasciwej wartosci do wyciecia
            getIndex_OfPlace_WhereStringIsNext(ref body, ref startIndex, classString);                         //to jest po to zeby startIndex byl maksymalnie blisko wlasciwej wartosci do wyciecia
            startIndex -= 500;
        }

        private string _getGoodDate(string link)
        {
            string startString_data = "datetime=\"";
            string criticChar_data = "\"";

            string body_in = GetBody(link);
            int startIndex_2 = 0;
            string classString_2 = "Publish date:";

            getIndex_OfPlace_WhereStringIsNext(ref body_in, ref startIndex_2, classString_2);                         //to jest po to zeby startIndex byl maksymalnie blisko wlasciwej wartosci do wyciecia
            string tmp_date = _getBetterValue(ref body_in, ref startIndex_2, startString_data, criticChar_data);
            string cor_date_format = "";

            for (int k = 0; k < tmp_date.Length; k++)
            {
                if (tmp_date[k] == 'T')
                {
                    k++;
                    cor_date_format += " ";
                }
                cor_date_format += tmp_date[k];
                if (k == "yyyy-MM-dd HH:mm".Length - 1)
                {
                    break;
                }
            }
            return cor_date_format;
        }
        private string _getGoodTitle(ref string body, ref int startIndex)
        {
            string startString_title = "ia-level=\"2\">";
            string criticChar_title = "<";

            string title = _getBetterValue(ref body, ref startIndex, startString_title, criticChar_title);
            startIndex -= title.Length;
            return title.Trim();
        }
        private string _getGoodLink(ref string body, ref int startIndex)
        {
            string startString_link = "href=\"";
            string criticChar_link = "\">";

            string link = _getBetterValue(ref body, ref startIndex, startString_link, criticChar_link);
            startIndex -= link.Length;

            while (link.Contains("onclick=\"retu"))
            {
                link = _getBetterValue(ref body, ref startIndex, startString_link, criticChar_link);
                string tmp_2 = "";
                for (int j = 0; j < link.Length; j++)
                {
                    if (link[j] != ' ' && link[j] != '"')
                    {
                        tmp_2 += link[j];
                    }
                    else
                    {
                        link = tmp_2;
                        break;
                    }
                }
            }
            return GetUrl() + link;
        }

        public string GetUrl()
        {
            return @"https://www.thestreet.com/";
        }

    }
}
