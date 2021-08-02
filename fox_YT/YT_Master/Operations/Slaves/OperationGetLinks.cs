using System;
using System.Collections.Generic;
using System.Text;

namespace YT_Master.Operations.Slaves
{
    public class OperationGetLinks : OperationCutting<List<string>,string>
    {
        public override List<string> MakeOperation(ref string body)
        {
            List<string> ret = new List<string>();
            int startIndex = 0;
            string classString = "entry-title";
            string startString = "a href=\"";
            char criticChar = '"';

            for (int i = 0; i < 100; i++)
            {
                _isNext(ref body, ref startIndex, classString);                         //to jest po to zeby startIndex byl maksymalnie blisko wlasciwej wartosci do wyciecia
                string tmp = _getValue(ref body, ref startIndex, startString, criticChar);
                if (i>0 && ret[i-1] == tmp)
                {
                    return ret;
                }
                ret.Add(tmp);
            }
            throw new Exception("OperationGetLinks -> MakeOperation -> nothing to return");
            return null;
        }
    }
}
