
namespace KotGospodarczy
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_GetBankierNews = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_GetCNBCNews = new System.Windows.Forms.Button();
            this.button_theStreet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_GetBankierNews
            // 
            this.button_GetBankierNews.Location = new System.Drawing.Point(12, 12);
            this.button_GetBankierNews.Name = "button_GetBankierNews";
            this.button_GetBankierNews.Size = new System.Drawing.Size(134, 38);
            this.button_GetBankierNews.TabIndex = 0;
            this.button_GetBankierNews.Text = "Get Bankier News";
            this.button_GetBankierNews.UseVisualStyleBackColor = true;
            this.button_GetBankierNews.Click += new System.EventHandler(this.button_GetBankierNews_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 343);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 1;
            // 
            // button_GetCNBCNews
            // 
            this.button_GetCNBCNews.Location = new System.Drawing.Point(12, 56);
            this.button_GetCNBCNews.Name = "button_GetCNBCNews";
            this.button_GetCNBCNews.Size = new System.Drawing.Size(134, 38);
            this.button_GetCNBCNews.TabIndex = 2;
            this.button_GetCNBCNews.Text = "Get CNBC News";
            this.button_GetCNBCNews.UseVisualStyleBackColor = true;
            this.button_GetCNBCNews.Click += new System.EventHandler(this.button_GetCNBCNews_Click);
            // 
            // button_theStreet
            // 
            this.button_theStreet.Location = new System.Drawing.Point(12, 100);
            this.button_theStreet.Name = "button_theStreet";
            this.button_theStreet.Size = new System.Drawing.Size(134, 38);
            this.button_theStreet.TabIndex = 3;
            this.button_theStreet.Text = "Get TheStreet News";
            this.button_theStreet.UseVisualStyleBackColor = true;
            this.button_theStreet.Click += new System.EventHandler(this.button_theStreet_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_theStreet);
            this.Controls.Add(this.button_GetCNBCNews);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button_GetBankierNews);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_GetBankierNews;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_GetCNBCNews;
        private System.Windows.Forms.Button button_theStreet;
    }
}