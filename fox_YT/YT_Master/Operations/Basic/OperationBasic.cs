using System;
using System.Collections.Generic;
using System.Text;

namespace YT_Master.Operations.Basic
{
    public abstract class OperationBasic<T_Val,T_Arg>
    {
        public abstract T_Val MakeOperation(ref T_Arg arg);
    }
}
