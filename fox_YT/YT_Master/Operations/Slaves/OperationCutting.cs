using System;
using System.Collections.Generic;
using System.Text;
using YT_Master.Operations.Basic;

namespace YT_Master.Operations.Slaves
{
    public abstract class OperationCutting<T_Val, T_Arg> : OperationBasic<T_Val, T_Arg>
    {
        protected string _getValue(ref string body, ref int startIndex, string startString, char criticChar)
        {
            string ret = "";
            if (_isNext(ref body, ref startIndex, startString))
            {
                startIndex += startString.Length;
                while (body[startIndex] != criticChar)
                {
                    ret += body[startIndex];
                    startIndex++;
                }
                startIndex += ret.Length;
            }
            return ret;
        }
        protected bool _isNext(ref string body, ref int startIndex, string nextString)
        {
            for (int i = startIndex; i < body.Length; i++)
            {
                bool notOk = false;
                for (int j = 0; j < nextString.Length; j++)
                {
                    if (body[(i + j)] != nextString[j])
                    {
                        notOk = true;
                        break;
                    }
                }
                if (!notOk)
                {
                    startIndex = i;
                    return true;
                }
            }
            return false;
        }
    }
}
