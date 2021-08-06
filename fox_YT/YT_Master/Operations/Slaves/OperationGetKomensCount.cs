using System;
using System.Collections.Generic;
using System.Text;

namespace YT_Master.Operations.Slaves
{
    public class OperationGetKomensCount : OperationCutting
    {
        public string GetCommentsCount(string body)
        {
            int startIndex = 0;
            string startString = "Komentarze (";
            char criticChar = ')';

            return _getValue(ref body, ref startIndex, startString, criticChar);
        }
    }
}
