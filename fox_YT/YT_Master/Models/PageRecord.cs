using System;
using System.Collections.Generic;
using System.Text;
using YT_Master.Communication.Basic;
using YT_Master.Operations.Slaves;

namespace YT_Master.Models
{
    public class PageRecord
    {
        public string Title; 
        public string Date; 
        public string Text;
        public string CommentCount; 
        public string Link;

        public PageRecord()
        {
            Title = "";
            Date = "";
            Text = "";
            CommentCount = "";
            Link = "";
        }

    }
}
