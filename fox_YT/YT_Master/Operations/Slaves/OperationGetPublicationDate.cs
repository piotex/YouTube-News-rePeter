using System;
using System.Collections.Generic;
using System.Text;

namespace YT_Master.Operations.Slaves
{
    public class OperationGetPublicationDate : OperationCutting
    {
        public string GetDate(string body)
        {
            int startIndex = 0;
            string startString = "publikacja";
            char criticChar = ' ';

            return _getValue(ref body, ref startIndex, startString, criticChar);
        }
    }
}
