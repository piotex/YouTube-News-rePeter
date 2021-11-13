
namespace KotGospodarczy
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_GetRecords = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox_Title = new System.Windows.Forms.TextBox();
            this.textBox1_comentCount = new System.Windows.Forms.TextBox();
            this.textBox = new System.Windows.Forms.TextBox();
            this.textBox_LinkToBankier = new System.Windows.Forms.TextBox();
            this.button_linkToClipboard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_GetRecords
            // 
            this.button_GetRecords.Location = new System.Drawing.Point(12, 12);
            this.button_GetRecords.Name = "button_GetRecords";
            this.button_GetRecords.Size = new System.Drawing.Size(141, 23);
            this.button_GetRecords.TabIndex = 0;
            this.button_GetRecords.Text = "Get Records";
            this.button_GetRecords.UseVisualStyleBackColor = true;
            this.button_GetRecords.Click += new System.EventHandler(this.button_GetRecords_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 41);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(1824, 23);
            this.progressBar1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(842, 23);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "Title";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(860, 70);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(104, 23);
            this.textBox5.TabIndex = 6;
            this.textBox5.Text = "Comments Count";
            // 
            // textBox_Title
            // 
            this.textBox_Title.Location = new System.Drawing.Point(12, 99);
            this.textBox_Title.Multiline = true;
            this.textBox_Title.Name = "textBox_Title";
            this.textBox_Title.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Title.Size = new System.Drawing.Size(842, 650);
            this.textBox_Title.TabIndex = 7;
            // 
            // textBox1_comentCount
            // 
            this.textBox1_comentCount.Location = new System.Drawing.Point(860, 99);
            this.textBox1_comentCount.Multiline = true;
            this.textBox1_comentCount.Name = "textBox1_comentCount";
            this.textBox1_comentCount.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1_comentCount.Size = new System.Drawing.Size(104, 650);
            this.textBox1_comentCount.TabIndex = 11;
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(970, 70);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(866, 23);
            this.textBox.TabIndex = 12;
            this.textBox.Text = "Link To Bankier";
            // 
            // textBox_LinkToBankier
            // 
            this.textBox_LinkToBankier.Location = new System.Drawing.Point(970, 99);
            this.textBox_LinkToBankier.Multiline = true;
            this.textBox_LinkToBankier.Name = "textBox_LinkToBankier";
            this.textBox_LinkToBankier.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_LinkToBankier.Size = new System.Drawing.Size(866, 650);
            this.textBox_LinkToBankier.TabIndex = 13;
            // 
            // button_linkToClipboard
            // 
            this.button_linkToClipboard.Location = new System.Drawing.Point(159, 12);
            this.button_linkToClipboard.Name = "button_linkToClipboard";
            this.button_linkToClipboard.Size = new System.Drawing.Size(1677, 23);
            this.button_linkToClipboard.TabIndex = 14;
            this.button_linkToClipboard.Text = "Copy Link To Clipboard";
            this.button_linkToClipboard.UseVisualStyleBackColor = true;
            this.button_linkToClipboard.Click += new System.EventHandler(this.button_linkToClipboard_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1848, 761);
            this.Controls.Add(this.button_linkToClipboard);
            this.Controls.Add(this.textBox_LinkToBankier);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.textBox1_comentCount);
            this.Controls.Add(this.textBox_Title);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_GetRecords);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_GetRecords;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox_Title;
        private System.Windows.Forms.TextBox textBox1_comentCount;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.TextBox textBox_LinkToBankier;
        private System.Windows.Forms.Button button_linkToClipboard;
    }
}

