using System;
using System.Collections.Generic;
using System.Windows.Forms;
using YT_Master.Communication.Basic;
using YT_Master.Communication.Slaves;
using YT_Master.Models;
using YT_Master.Operations.Slaves;

namespace Shot
{
    public partial class Form1 : Form
    {
        private List<string> Linki;
        private int counter;
        public PageRecord record;

        public Form1()
        {
            InitializeComponent();

            counter = 0;
            Linki = new List<string>();
            // /*
            //int pageCount = 20;
            int pageCount = 2;
            for (int pageNumger = 1; pageNumger < pageCount; pageNumger++)
            {
                string pageHtml = new CommunicationBankier().GetBodyBankierNews(pageNumger);
                List<string> data = new OperationGetLinks().GetLinks(pageHtml);

                for (int j = 0; j < data.Count; j++)
                {
                    Linki.Add("https://www.bankier.pl" + data[j]);
                }
            }
            // */
            Uzupelnij();
        }

        private void Uzupelnij()
        {
            CommunicationBasic bb = new CommunicationBasic();
            CommunicationNotionV2 tmp = new CommunicationNotionV2();
            tmp.LogIn();

            for (int i = 0; i < Linki.Count; i++)
            {
                PageRecord record = new PageRecord();
                string body = bb.GetBody(Linki[i]);
                string content = new OperationGetContent().GetContent(body);

                record.Link = Linki[counter];
                record.Title = new OperationGetTitle().GetTitleFromText(content);
                record.Date = new OperationGetPublicationDate().GetDate(content);
                record.Text = new OperationGetText().GetText(content);
                record.CommentCount = new OperationGetKomensCount().GetCommentsCount(content);

                tmp.AddScenario(record);
            }
        }

        private void nextRecerdButton_Click(object sender, EventArgs e)
        {
            Uzupelnij();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_link.Text);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_Date.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_tytul.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_tresc.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_komment.Text);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(textBox_iloscZnakow.Text);
        }
    }
}
