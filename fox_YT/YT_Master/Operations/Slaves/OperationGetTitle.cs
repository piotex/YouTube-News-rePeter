using System;
using System.Collections.Generic;
using System.Text;

namespace YT_Master.Operations.Slaves
{
    public class OperationGetTitle : OperationCutting
    {
        public string GetTitleFromText(string body)
        {
            int startIndex = 0;
            string startString = "     ";
            char criticChar = '2';
         
            return _getValue(ref body, ref startIndex, startString, criticChar);
        }
    }
}
