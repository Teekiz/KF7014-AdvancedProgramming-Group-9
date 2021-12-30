
namespace PresentationLayer
{
    partial class OFCcountry
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OFCcountry));
            this.OFCnameF = new System.Windows.Forms.TextBox();
            this.OFCaddr1F = new System.Windows.Forms.TextBox();
            this.OFCphoneF = new System.Windows.Forms.TextBox();
            this.OFCname = new System.Windows.Forms.Label();
            this.OFCbirthdate = new System.Windows.Forms.Label();
            this.OFCaddr1 = new System.Windows.Forms.Label();
            this.OFCphone = new System.Windows.Forms.Label();
            this.OFCot = new System.Windows.Forms.Label();
            this.OFCncd = new System.Windows.Forms.Label();
            this.OFCncdF = new System.Windows.Forms.DateTimePicker();
            this.OFCbirthdateF = new System.Windows.Forms.DateTimePicker();
            this.OFCnotes = new System.Windows.Forms.Label();
            this.OFCsubmit = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.OFCtermscond = new System.Windows.Forms.CheckBox();
            this.OFCnotesF = new System.Windows.Forms.RichTextBox();
            this.OFCcustomerform = new System.Windows.Forms.Label();
            this.OFCot1q = new System.Windows.Forms.TextBox();
            this.OFCot2q = new System.Windows.Forms.TextBox();
            this.OFCot3q = new System.Windows.Forms.TextBox();
            this.OFCaddr2 = new System.Windows.Forms.Label();
            this.OFCcounty = new System.Windows.Forms.Label();
            this.OFCaddr2F = new System.Windows.Forms.TextBox();
            this.OFCcountyF = new System.Windows.Forms.TextBox();
            this.OFCot1desc = new System.Windows.Forms.TextBox();
            this.OFCot2desc = new System.Windows.Forms.TextBox();
            this.OFCot3desc = new System.Windows.Forms.TextBox();
            this.OFCot1 = new System.Windows.Forms.CheckBox();
            this.OFCot2 = new System.Windows.Forms.CheckBox();
            this.OFcot3 = new System.Windows.Forms.CheckBox();
            this.OFCpostcode = new System.Windows.Forms.Label();
            this.OFCpostcodeF = new System.Windows.Forms.TextBox();
            this.OFCtown = new System.Windows.Forms.Label();
            this.OFCtownF = new System.Windows.Forms.TextBox();
            this.OFCcountryF = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OFCgroupbox = new System.Windows.Forms.GroupBox();
            this.OFCct3 = new System.Windows.Forms.RadioButton();
            this.OFCct2 = new System.Windows.Forms.RadioButton();
            this.OFCct1 = new System.Windows.Forms.RadioButton();
            this.OFCcustomertype = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.OFCpicturebox = new System.Windows.Forms.PictureBox();
            this.OFCgroupbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OFCpicturebox)).BeginInit();
            this.SuspendLayout();
            // 
            // OFCnameF
            // 
            this.OFCnameF.Location = new System.Drawing.Point(132, 41);
            this.OFCnameF.Name = "OFCnameF";
            this.OFCnameF.Size = new System.Drawing.Size(399, 20);
            this.OFCnameF.TabIndex = 0;
            this.OFCnameF.TextChanged += new System.EventHandler(this.OFCnameF_TextChanged);
            // 
            // OFCaddr1F
            // 
            this.OFCaddr1F.Location = new System.Drawing.Point(132, 171);
            this.OFCaddr1F.Name = "OFCaddr1F";
            this.OFCaddr1F.Size = new System.Drawing.Size(399, 20);
            this.OFCaddr1F.TabIndex = 2;
            // 
            // OFCphoneF
            // 
            this.OFCphoneF.Location = new System.Drawing.Point(132, 131);
            this.OFCphoneF.Name = "OFCphoneF";
            this.OFCphoneF.Size = new System.Drawing.Size(399, 20);
            this.OFCphoneF.TabIndex = 3;
            // 
            // OFCname
            // 
            this.OFCname.AutoSize = true;
            this.OFCname.Location = new System.Drawing.Point(28, 48);
            this.OFCname.Name = "OFCname";
            this.OFCname.Size = new System.Drawing.Size(42, 13);
            this.OFCname.TabIndex = 7;
            this.OFCname.Text = "Name *";
            // 
            // OFCbirthdate
            // 
            this.OFCbirthdate.AutoSize = true;
            this.OFCbirthdate.Location = new System.Drawing.Point(22, 85);
            this.OFCbirthdate.Name = "OFCbirthdate";
            this.OFCbirthdate.Size = new System.Drawing.Size(61, 13);
            this.OFCbirthdate.TabIndex = 8;
            this.OFCbirthdate.Text = "Birth Date *";
            // 
            // OFCaddr1
            // 
            this.OFCaddr1.AutoSize = true;
            this.OFCaddr1.Location = new System.Drawing.Point(8, 171);
            this.OFCaddr1.Name = "OFCaddr1";
            this.OFCaddr1.Size = new System.Drawing.Size(90, 13);
            this.OFCaddr1.TabIndex = 9;
            this.OFCaddr1.Text = "Address - Line 1 *";
            this.OFCaddr1.Click += new System.EventHandler(this.label3_Click);
            // 
            // OFCphone
            // 
            this.OFCphone.AutoSize = true;
            this.OFCphone.Location = new System.Drawing.Point(28, 131);
            this.OFCphone.Name = "OFCphone";
            this.OFCphone.Size = new System.Drawing.Size(45, 13);
            this.OFCphone.TabIndex = 10;
            this.OFCphone.Text = "Phone *";
            // 
            // OFCot
            // 
            this.OFCot.AutoSize = true;
            this.OFCot.Location = new System.Drawing.Point(12, 437);
            this.OFCot.Name = "OFCot";
            this.OFCot.Size = new System.Drawing.Size(67, 13);
            this.OFCot.TabIndex = 12;
            this.OFCot.Text = "Order Type *";
            // 
            // OFCncd
            // 
            this.OFCncd.AutoSize = true;
            this.OFCncd.Location = new System.Drawing.Point(-2, 719);
            this.OFCncd.Name = "OFCncd";
            this.OFCncd.Size = new System.Drawing.Size(123, 13);
            this.OFCncd.TabIndex = 16;
            this.OFCncd.Text = "Needed completion date";
            // 
            // OFCncdF
            // 
            this.OFCncdF.Location = new System.Drawing.Point(137, 712);
            this.OFCncdF.Name = "OFCncdF";
            this.OFCncdF.Size = new System.Drawing.Size(399, 20);
            this.OFCncdF.TabIndex = 17;
            // 
            // OFCbirthdateF
            // 
            this.OFCbirthdateF.Location = new System.Drawing.Point(132, 85);
            this.OFCbirthdateF.Name = "OFCbirthdateF";
            this.OFCbirthdateF.Size = new System.Drawing.Size(399, 20);
            this.OFCbirthdateF.TabIndex = 19;
            // 
            // OFCnotes
            // 
            this.OFCnotes.AutoSize = true;
            this.OFCnotes.Location = new System.Drawing.Point(16, 747);
            this.OFCnotes.Name = "OFCnotes";
            this.OFCnotes.Size = new System.Drawing.Size(64, 13);
            this.OFCnotes.TabIndex = 23;
            this.OFCnotes.Text = "Order Notes";
            // 
            // OFCsubmit
            // 
            this.OFCsubmit.Location = new System.Drawing.Point(603, 585);
            this.OFCsubmit.Name = "OFCsubmit";
            this.OFCsubmit.Size = new System.Drawing.Size(250, 96);
            this.OFCsubmit.TabIndex = 25;
            this.OFCsubmit.Text = "Submit";
            this.OFCsubmit.UseVisualStyleBackColor = true;
            this.OFCsubmit.Click += new System.EventHandler(this.OFCsubmit_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(-2, 811);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(178, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "I Agree to the terms and conditions *";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // OFCtermscond
            // 
            this.OFCtermscond.AutoSize = true;
            this.OFCtermscond.Location = new System.Drawing.Point(193, 810);
            this.OFCtermscond.Name = "OFCtermscond";
            this.OFCtermscond.Size = new System.Drawing.Size(44, 17);
            this.OFCtermscond.TabIndex = 27;
            this.OFCtermscond.Text = "Yes";
            this.OFCtermscond.UseVisualStyleBackColor = true;
            // 
            // OFCnotesF
            // 
            this.OFCnotesF.Location = new System.Drawing.Point(137, 747);
            this.OFCnotesF.Name = "OFCnotesF";
            this.OFCnotesF.Size = new System.Drawing.Size(399, 52);
            this.OFCnotesF.TabIndex = 29;
            this.OFCnotesF.Text = "";
            // 
            // OFCcustomerform
            // 
            this.OFCcustomerform.AutoSize = true;
            this.OFCcustomerform.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OFCcustomerform.Location = new System.Drawing.Point(205, 5);
            this.OFCcustomerform.Name = "OFCcustomerform";
            this.OFCcustomerform.Size = new System.Drawing.Size(232, 25);
            this.OFCcustomerform.TabIndex = 59;
            this.OFCcustomerform.Text = "Order Form - Customer";
            // 
            // OFCot1q
            // 
            this.OFCot1q.Location = new System.Drawing.Point(132, 434);
            this.OFCot1q.Name = "OFCot1q";
            this.OFCot1q.Size = new System.Drawing.Size(19, 20);
            this.OFCot1q.TabIndex = 60;
            // 
            // OFCot2q
            // 
            this.OFCot2q.Location = new System.Drawing.Point(132, 519);
            this.OFCot2q.Name = "OFCot2q";
            this.OFCot2q.Size = new System.Drawing.Size(19, 20);
            this.OFCot2q.TabIndex = 61;
            // 
            // OFCot3q
            // 
            this.OFCot3q.Location = new System.Drawing.Point(132, 611);
            this.OFCot3q.Name = "OFCot3q";
            this.OFCot3q.Size = new System.Drawing.Size(19, 20);
            this.OFCot3q.TabIndex = 62;
            // 
            // OFCaddr2
            // 
            this.OFCaddr2.AutoSize = true;
            this.OFCaddr2.Location = new System.Drawing.Point(8, 215);
            this.OFCaddr2.Name = "OFCaddr2";
            this.OFCaddr2.Size = new System.Drawing.Size(83, 13);
            this.OFCaddr2.TabIndex = 63;
            this.OFCaddr2.Text = "Address - Line 2";
            // 
            // OFCcounty
            // 
            this.OFCcounty.AutoSize = true;
            this.OFCcounty.Location = new System.Drawing.Point(28, 313);
            this.OFCcounty.Name = "OFCcounty";
            this.OFCcounty.Size = new System.Drawing.Size(47, 13);
            this.OFCcounty.TabIndex = 64;
            this.OFCcounty.Text = "County *";
            // 
            // OFCaddr2F
            // 
            this.OFCaddr2F.Location = new System.Drawing.Point(132, 213);
            this.OFCaddr2F.Name = "OFCaddr2F";
            this.OFCaddr2F.Size = new System.Drawing.Size(399, 20);
            this.OFCaddr2F.TabIndex = 65;
            // 
            // OFCcountyF
            // 
            this.OFCcountyF.Location = new System.Drawing.Point(132, 310);
            this.OFCcountyF.Name = "OFCcountyF";
            this.OFCcountyF.Size = new System.Drawing.Size(399, 20);
            this.OFCcountyF.TabIndex = 66;
            // 
            // OFCot1desc
            // 
            this.OFCot1desc.Location = new System.Drawing.Point(157, 459);
            this.OFCot1desc.Margin = new System.Windows.Forms.Padding(2);
            this.OFCot1desc.Multiline = true;
            this.OFCot1desc.Name = "OFCot1desc";
            this.OFCot1desc.Size = new System.Drawing.Size(380, 58);
            this.OFCot1desc.TabIndex = 67;
            this.OFCot1desc.Text = "Enter description of items here";
            // 
            // OFCot2desc
            // 
            this.OFCot2desc.Location = new System.Drawing.Point(156, 550);
            this.OFCot2desc.Margin = new System.Windows.Forms.Padding(2);
            this.OFCot2desc.Multiline = true;
            this.OFCot2desc.Name = "OFCot2desc";
            this.OFCot2desc.Size = new System.Drawing.Size(380, 58);
            this.OFCot2desc.TabIndex = 68;
            this.OFCot2desc.Text = "Enter description of items here";
            // 
            // OFCot3desc
            // 
            this.OFCot3desc.Location = new System.Drawing.Point(157, 635);
            this.OFCot3desc.Margin = new System.Windows.Forms.Padding(2);
            this.OFCot3desc.Multiline = true;
            this.OFCot3desc.Name = "OFCot3desc";
            this.OFCot3desc.Size = new System.Drawing.Size(380, 58);
            this.OFCot3desc.TabIndex = 69;
            this.OFCot3desc.Text = "Enter description of items here";
            // 
            // OFCot1
            // 
            this.OFCot1.AutoSize = true;
            this.OFCot1.Location = new System.Drawing.Point(168, 437);
            this.OFCot1.Name = "OFCot1";
            this.OFCot1.Size = new System.Drawing.Size(116, 17);
            this.OFCot1.TabIndex = 70;
            this.OFCot1.Text = "Ceremonial Swords";
            this.OFCot1.UseVisualStyleBackColor = true;
            // 
            // OFCot2
            // 
            this.OFCot2.AutoSize = true;
            this.OFCot2.Location = new System.Drawing.Point(168, 522);
            this.OFCot2.Name = "OFCot2";
            this.OFCot2.Size = new System.Drawing.Size(124, 17);
            this.OFCot2.TabIndex = 71;
            this.OFCot2.Text = "\"Film Grade\" Swords";
            this.OFCot2.UseVisualStyleBackColor = true;
            // 
            // OFcot3
            // 
            this.OFcot3.AutoSize = true;
            this.OFcot3.Location = new System.Drawing.Point(168, 613);
            this.OFcot3.Name = "OFcot3";
            this.OFcot3.Size = new System.Drawing.Size(59, 17);
            this.OFcot3.TabIndex = 72;
            this.OFcot3.Text = "Armour";
            this.OFcot3.UseVisualStyleBackColor = true;
            // 
            // OFCpostcode
            // 
            this.OFCpostcode.AutoSize = true;
            this.OFCpostcode.Location = new System.Drawing.Point(20, 276);
            this.OFCpostcode.Name = "OFCpostcode";
            this.OFCpostcode.Size = new System.Drawing.Size(59, 13);
            this.OFCpostcode.TabIndex = 73;
            this.OFCpostcode.Text = "Postcode *";
            // 
            // OFCpostcodeF
            // 
            this.OFCpostcodeF.Location = new System.Drawing.Point(132, 276);
            this.OFCpostcodeF.Name = "OFCpostcodeF";
            this.OFCpostcodeF.Size = new System.Drawing.Size(399, 20);
            this.OFCpostcodeF.TabIndex = 74;
            // 
            // OFCtown
            // 
            this.OFCtown.AutoSize = true;
            this.OFCtown.Location = new System.Drawing.Point(17, 244);
            this.OFCtown.Name = "OFCtown";
            this.OFCtown.Size = new System.Drawing.Size(63, 13);
            this.OFCtown.TabIndex = 75;
            this.OFCtown.Text = "Town/City *";
            // 
            // OFCtownF
            // 
            this.OFCtownF.Location = new System.Drawing.Point(132, 244);
            this.OFCtownF.Name = "OFCtownF";
            this.OFCtownF.Size = new System.Drawing.Size(399, 20);
            this.OFCtownF.TabIndex = 76;
            // 
            // OFCcountryF
            // 
            this.OFCcountryF.Location = new System.Drawing.Point(132, 348);
            this.OFCcountryF.Name = "OFCcountryF";
            this.OFCcountryF.Size = new System.Drawing.Size(399, 20);
            this.OFCcountryF.TabIndex = 77;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 355);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Country *";
            // 
            // OFCgroupbox
            // 
            this.OFCgroupbox.Controls.Add(this.OFCct3);
            this.OFCgroupbox.Controls.Add(this.OFCct2);
            this.OFCgroupbox.Controls.Add(this.OFCct1);
            this.OFCgroupbox.Location = new System.Drawing.Point(132, 374);
            this.OFCgroupbox.Name = "OFCgroupbox";
            this.OFCgroupbox.Size = new System.Drawing.Size(399, 54);
            this.OFCgroupbox.TabIndex = 79;
            this.OFCgroupbox.TabStop = false;
            // 
            // OFCct3
            // 
            this.OFCct3.AutoSize = true;
            this.OFCct3.Location = new System.Drawing.Point(317, 16);
            this.OFCct3.Name = "OFCct3";
            this.OFCct3.Size = new System.Drawing.Size(66, 17);
            this.OFCct3.TabIndex = 2;
            this.OFCct3.TabStop = true;
            this.OFCct3.Text = "Collector";
            this.OFCct3.UseVisualStyleBackColor = true;
            // 
            // OFCct2
            // 
            this.OFCct2.AutoSize = true;
            this.OFCct2.Location = new System.Drawing.Point(158, 16);
            this.OFCct2.Name = "OFCct2";
            this.OFCct2.Size = new System.Drawing.Size(90, 17);
            this.OFCct2.TabIndex = 1;
            this.OFCct2.TabStop = true;
            this.OFCct2.Text = "Entertainment";
            this.OFCct2.UseVisualStyleBackColor = true;
            // 
            // OFCct1
            // 
            this.OFCct1.AutoSize = true;
            this.OFCct1.Location = new System.Drawing.Point(24, 16);
            this.OFCct1.Name = "OFCct1";
            this.OFCct1.Size = new System.Drawing.Size(91, 17);
            this.OFCct1.TabIndex = 0;
            this.OFCct1.TabStop = true;
            this.OFCct1.Text = "Governmental";
            this.OFCct1.UseVisualStyleBackColor = true;
            // 
            // OFCcustomertype
            // 
            this.OFCcustomertype.AutoSize = true;
            this.OFCcustomertype.Location = new System.Drawing.Point(16, 399);
            this.OFCcustomertype.Name = "OFCcustomertype";
            this.OFCcustomertype.Size = new System.Drawing.Size(81, 13);
            this.OFCcustomertype.TabIndex = 11;
            this.OFCcustomertype.Text = "Customer type *";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PresentationLayer.Properties.Resources.estimates;
            this.pictureBox2.Location = new System.Drawing.Point(603, 228);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(250, 336);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 24;
            this.pictureBox2.TabStop = false;
            // 
            // OFCpicturebox
            // 
            this.OFCpicturebox.Image = global::PresentationLayer.Properties.Resources.logo1;
            this.OFCpicturebox.Location = new System.Drawing.Point(603, 5);
            this.OFCpicturebox.Name = "OFCpicturebox";
            this.OFCpicturebox.Size = new System.Drawing.Size(250, 204);
            this.OFCpicturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.OFCpicturebox.TabIndex = 14;
            this.OFCpicturebox.TabStop = false;
            // 
            // OFCcountry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(876, 832);
            this.Controls.Add(this.OFCcustomertype);
            this.Controls.Add(this.OFCgroupbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.OFCcountryF);
            this.Controls.Add(this.OFCtownF);
            this.Controls.Add(this.OFCtown);
            this.Controls.Add(this.OFCpostcodeF);
            this.Controls.Add(this.OFCpostcode);
            this.Controls.Add(this.OFcot3);
            this.Controls.Add(this.OFCot2);
            this.Controls.Add(this.OFCot1);
            this.Controls.Add(this.OFCot3desc);
            this.Controls.Add(this.OFCot2desc);
            this.Controls.Add(this.OFCot1desc);
            this.Controls.Add(this.OFCcountyF);
            this.Controls.Add(this.OFCaddr2F);
            this.Controls.Add(this.OFCcounty);
            this.Controls.Add(this.OFCaddr2);
            this.Controls.Add(this.OFCot3q);
            this.Controls.Add(this.OFCot2q);
            this.Controls.Add(this.OFCot1q);
            this.Controls.Add(this.OFCcustomerform);
            this.Controls.Add(this.OFCnotesF);
            this.Controls.Add(this.OFCtermscond);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.OFCsubmit);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.OFCnotes);
            this.Controls.Add(this.OFCbirthdateF);
            this.Controls.Add(this.OFCncdF);
            this.Controls.Add(this.OFCncd);
            this.Controls.Add(this.OFCpicturebox);
            this.Controls.Add(this.OFCot);
            this.Controls.Add(this.OFCphone);
            this.Controls.Add(this.OFCaddr1);
            this.Controls.Add(this.OFCbirthdate);
            this.Controls.Add(this.OFCname);
            this.Controls.Add(this.OFCphoneF);
            this.Controls.Add(this.OFCaddr1F);
            this.Controls.Add(this.OFCnameF);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OFCcountry";
            this.Text = "Order Form - Customer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.OFCgroupbox.ResumeLayout(false);
            this.OFCgroupbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OFCpicturebox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox OFCnameF;
        private System.Windows.Forms.TextBox OFCaddr1F;
        private System.Windows.Forms.TextBox OFCphoneF;
        private System.Windows.Forms.Label OFCname;
        private System.Windows.Forms.Label OFCbirthdate;
        private System.Windows.Forms.Label OFCaddr1;
        private System.Windows.Forms.Label OFCphone;
        private System.Windows.Forms.Label OFCot;
        private System.Windows.Forms.PictureBox OFCpicturebox;
        private System.Windows.Forms.Label OFCncd;
        private System.Windows.Forms.DateTimePicker OFCncdF;
        private System.Windows.Forms.DateTimePicker OFCbirthdateF;
        private System.Windows.Forms.Label OFCnotes;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button OFCsubmit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox OFCtermscond;
        private System.Windows.Forms.RichTextBox OFCnotesF;
        private System.Windows.Forms.Label OFCcustomerform;
        private System.Windows.Forms.TextBox OFCot1q;
        private System.Windows.Forms.TextBox OFCot2q;
        private System.Windows.Forms.TextBox OFCot3q;
        private System.Windows.Forms.Label OFCaddr2;
        private System.Windows.Forms.Label OFCcounty;
        private System.Windows.Forms.TextBox OFCaddr2F;
        private System.Windows.Forms.TextBox OFCcountyF;
        private System.Windows.Forms.TextBox OFCot1desc;
        private System.Windows.Forms.TextBox OFCot2desc;
        private System.Windows.Forms.TextBox OFCot3desc;
        private System.Windows.Forms.CheckBox OFCot1;
        private System.Windows.Forms.CheckBox OFCot2;
        private System.Windows.Forms.CheckBox OFcot3;
        private System.Windows.Forms.Label OFCpostcode;
        private System.Windows.Forms.TextBox OFCpostcodeF;
        private System.Windows.Forms.Label OFCtown;
        private System.Windows.Forms.TextBox OFCtownF;
        private System.Windows.Forms.TextBox OFCcountryF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox OFCgroupbox;
        private System.Windows.Forms.RadioButton OFCct3;
        private System.Windows.Forms.RadioButton OFCct2;
        private System.Windows.Forms.RadioButton OFCct1;
        private System.Windows.Forms.Label OFCcustomertype;
    }
}

