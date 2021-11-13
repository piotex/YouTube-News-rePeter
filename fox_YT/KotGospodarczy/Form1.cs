using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using YT_Master.Communication.Basic;
using YT_Master.Communication.Slaves;
using YT_Master.Models;
using YT_Master.Operations.Slaves;

namespace KotGospodarczy
{
    public partial class Form1 : Form
    {
        private int pageCount = 10;
        private int recordIndex = 0;
        private List<PageRecord> recordList;
        public Form1()
        {
            InitializeComponent();
            recordList = new List<PageRecord>();
        }

        private void button_GetRecords_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> Links = addLinks();
                progressBar1.Maximum = Links.Count;

                //tryLogIn(ref tmp);

                for (int i = 0; i < Links.Count; i++)
                {
                    PageRecord record = new PageRecord();
                    trySetRecord(ref record, Links[i]);

                    if (!falidDate(ref record))
                    {
                        break;
                    }
                    recordList.Add(record);
                    progressBar1.Value += 1;
                }
                progressBar1.Value = 0;
                recordList = recordList.OrderByDescending(x => x.CommentCount).ToList();
                SetDataToTextBoxes(ref recordList);

            }
            catch (Exception eee)
            {
            }
        }
        public void SetDataToTextBoxes(ref List<PageRecord> recordList)
        {
            string newLink = "\r\n";
            for (int i = 0; i < recordList.Count; i++)
            {
                if (recordList[i].Title != "")
                {
                    textBox_Title.Text += recordList[i].Title + newLink;
                }
                if (recordList[i].Link != "")
                {
                    textBox_LinkToBankier.Text += recordList[i].Link + newLink;
                }
                if (recordList[i].CommentCount != -1)
                {
                    textBox1_comentCount.Text += recordList[i].CommentCount + newLink;
                }
            }
        }
        public bool falidDate(ref PageRecord record)
        {
            DateTime yesterday = DateTime.Now.AddDays(-1);
            DateTime recordDate = DateTime.ParseExact(record.Date, "yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);

            return (recordDate > yesterday);
        }
        public void trySetRecord(ref PageRecord record, string link)
        {
            try
            {
                setRecord(ref record, link);
            }
            catch (Exception eee)
            {
            }
        }
        public int setRecord(ref PageRecord record, string link)
        {
            string body = new CommunicationBasic().GetBody(link);
            string content = new OperationGetContent().GetContent(body);

            record.Link = link;
            record.Title = new OperationGetTitle().GetTitleFromText(content);
            record.Date = new OperationGetPublicationDate().GetDate(content);
            //record.Text = new OperationGetText().GetText(content);
            record.CommentCount = int.Parse(new OperationGetKomensCount().GetCommentsCount(content));

            return 0;
        }

        public List<string> addLinks()
        {
            List<string> Linki = new List<string>();

            for (int pageNumger = 1; pageNumger <= pageCount; pageNumger++)
            {
                string pageHtml = new CommunicationBankier().GetBodyBankierNews(pageNumger);
                List<string> data = new OperationGetLinks().GetLinks(pageHtml);

                for (int j = 0; j < data.Count; j++)
                {
                    Linki.Add("https://www.bankier.pl" + data[j]);
                }
            }
            return Linki;
        }

        private void button_linkToClipboard_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(recordList[recordIndex].Link);
            recordIndex++;
        }
    }
}
