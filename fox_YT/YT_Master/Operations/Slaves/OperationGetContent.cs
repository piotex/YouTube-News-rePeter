using NUglify;
using System;
using System.Collections.Generic;
using System.Text;

namespace YT_Master.Operations.Slaves
{
    public class OperationGetContent : OperationCutting
    {
        public string GetContent(string body)
        {
            string result = Uglify.HtmlToText(body).Code;
            int startIndex = 0;
            string startString = "Forum";
            string criticString = "dodaj komentarz";

            getIndex_OfPlace_WhereStringIsNext(ref result, ref startIndex, startString);
            string contttt = _getBetterValue(ref result, ref startIndex, startString, criticString);

            return contttt;
            /*
            throw new Exception("nie zaimplementowano ");
            int startIndex = 0;
            string startString = "<h1 class=\"a-heading -blue\">";
            char criticChar = '<';

            return _getValue(ref body, ref startIndex, startString, criticChar);
            */
        }
    }
}
