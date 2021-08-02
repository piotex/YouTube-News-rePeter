using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml;
using YT_Master.Models;

namespace YT_Master.Xml
{
    public class XmlReader_My
    {
        public List<List<string>> getData(string path)
        {
            List<List<string>> tmp = new List<List<string>>();
            XmlDocument doc = new XmlDocument();
            doc.Load(path);

            for (int i = 0; i < doc.DocumentElement.ChildNodes.Count; i++)
            {
                tmp.Add(new List<string>());
                XmlNode parent_node = doc.DocumentElement.ChildNodes[i];
                for (int j = 0; j < parent_node.ChildNodes.Count; j++)
                {
                    XmlNode child_node = parent_node.ChildNodes[j];
                    tmp[i].Add(child_node.InnerText);
                }

            }
            return tmp;
        }
        public User getNotionUser()
        {
            string path = @"..\..\..\..\..\..\NotionLogin.xml";
            User ret = new User();

            List<List<string>> tmp = getData(path);
            ret.Email = tmp[0][0];
            ret.Pwd = tmp[0][1];

            return ret;
        }
    }
}
