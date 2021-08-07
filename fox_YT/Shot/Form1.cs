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
            string body = bb.GetBody(Linki[counter]);
            //string body = bb.GetBody(@"https://www.bankier.pl/wiadomosc/Apple-zamierza-kontrolowac-iCloud-pod-katem-tresci-z-pornografia-dziecieca-8166529.html");

            string content = new OperationGetContent().GetContent(body);

            textBox_tytul.Text = new OperationGetTitle().GetTitleFromText(content);
            textBox_Date.Text = new OperationGetPublicationDate().GetDate(content);
            textBox_tresc.Text = new OperationGetText().GetText(content);
            textBox_komment.Text = new OperationGetKomensCount().GetCommentsCount(content);
            textBox_link.Text = Linki[counter];
            textBox_iloscZnakow.Text = textBox_tresc.Text.Length.ToString();


            CommunicationNotionV2 tmp = new CommunicationNotionV2();
            tmp.LogIn();

            for (int i = 0; i < 10; i++)
            {
                tmp.AddScenario();
            }


            counter++;

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
