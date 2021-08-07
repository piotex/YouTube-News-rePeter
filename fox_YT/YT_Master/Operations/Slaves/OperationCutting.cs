using System;
using System.Collections.Generic;
using System.Text;
using YT_Master.Operations.Basic;

namespace YT_Master.Operations.Slaves
{
    public abstract class OperationCutting : OperationBasic
    {
        protected string getAfterBigLeter(string data)
        {
            bool after = false;
            string ret = "";
            for (int i = 1; i < data.Length; i++)       //ToDo znalezc metode która tnie stringa zeby to ladniej wygladalo :>
            {
                if (Char.IsUpper(data[i]))
                {
                    after = true;
                }
                if (after)
                {
                    ret += data[i];
                }
            }
            return ret;
        }

        protected string _getBetterValue(ref string body, ref int startIndex, string startString, string criticString)
        {
            string ret = "";
            if (getIndex_OfPlace_WhereStringIsNext(ref body, ref startIndex, startString))
            {
                while (!isNext(ref body, ref startIndex, criticString))
                {
                    ret += body[startIndex];
                    if (startIndex<body.Length-1)
                    {
                        startIndex++;
                    }
                    else
                    {
                        break;
                    }
                }
                startIndex += ret.Length;
            }
            return ret;
        }
        protected string _getValue(ref string body, ref int startIndex, string startString, char criticChar)
        {
            string ret = "";
            if (getIndex_OfPlace_WhereStringIsNext(ref body, ref startIndex, startString))          //ToDo - raczej nigdy, ale może: dodac for-a i zamienic na isNext()
            {
                while (body[startIndex] != criticChar )
                {
                    ret += body[startIndex];
                    startIndex++;
                }
                startIndex += ret.Length;
            }
            return ret;
        }

        protected bool isNext(ref string body, ref int startIndex, string nextString)           // to sie moze wywalic po pierwszym zlym znaku
        {
            for (int i = startIndex; i < body.Length; i++)
            {
                bool notOk = false;
                for (int j = 0; j < nextString.Length; j++)
                {
                    if (body[(i + j)] != nextString[j])
                    {
                        return false;
                    }
                }
                if (!notOk)
                {
                    startIndex = i + nextString.Length;
                    return true;
                }
            }
            return false;
        }

        protected bool getIndex_OfPlace_WhereStringIsNext(ref string body, ref int startIndex, string nextString)       // to bedzie leciec do skutku
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
                    startIndex = i + nextString.Length;
                    return true;
                }
            }
            return false;
        }
    }
}
