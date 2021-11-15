using KotGospodarczy.MyCode.v1.Managers;
using KotGospodarczy.MyCode.v1.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace KotGospodarczy
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void button_GetBankierNews_Click(object sender, EventArgs e)
        {
            _add_Form(new NewsManagerBankier().GetNewsList());
        }


        private void button_GetCNBCNews_Click(object sender, EventArgs e)
        {
            _add_Form(new NewsManagerCNBC().GetNewsList());
        }
        private void button_theStreet_Click(object sender, EventArgs e)
        {
            _add_Form(new NewsManagerTheStreet().GetNewsList());
        }
        private void button_FoxNews_Click(object sender, EventArgs e)
        {
            _add_Form(new NewsManagerFoxNews().GetNewsList());
        }

        private void onClickEventHandler(object sender, EventArgs e)
        {
            Clipboard.SetText(((Button)sender).Text);
        }
        private void _add_Form(List<ModelNews> tmp)
        {
            int size_x = 30;
            int size_y = 600;

            Form bankierForm = new Form();
            bankierForm.Size = new Size(1300, 700);
            bankierForm.AutoScroll = true;
            bankierForm.Show();

            for (int i = 0; i < tmp.Count; i++)
            {
                TextBox Title = new TextBox();
                Title.Location = new Point(0, size_x * i);
                Title.Size = new Size(size_y, size_x);
                Title.Text = tmp[i].Title;

                Button button = new Button();
                button.Click += onClickEventHandler;
                button.Location = new Point(size_y, size_x * i);
                button.Text = tmp[i].Link;
                button.Size = new Size(size_y, size_x);

                bankierForm.Controls.Add(Title);
                bankierForm.Controls.Add(button);
            }
        }

    }
}
