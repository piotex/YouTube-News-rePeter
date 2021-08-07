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
            string startString = "";
            string criticChar = "Podziel się";
            string partial = " " + _getBetterValue(ref body, ref startIndex, startString, criticChar);
            string ret = "";

            bool flag = false;
            for (int i = 0; i < partial.Length; i++)
            {
                if (partial[i] != ' ')
                {
                    flag = true;
                }
                if (flag)
                {
                    ret += partial[i];
                }
            }
            return getAfterBigLeter(ret);
        }
    }
}
