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
            string criticChar = "Podziel";
            string notCoolString = "aktualizacja";
            string tmp = _getBetterValue(ref body, ref startIndex, startString, criticChar);

            if (tmp.Contains(notCoolString))
            {
                tmp = tmp.Remove(0, (notCoolString + " yyyy-MM-dd HH:mm").Length);
            }
            
            return tmp;
        }
    }
}
