﻿
namespace PresentationLayer
{
    partial class OrderManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderManager));
            this.label1 = new System.Windows.Forms.Label();
            this.OFMdate = new System.Windows.Forms.Label();
            this.OFMphone = new System.Windows.Forms.Label();
            this.OFMaddr1 = new System.Windows.Forms.Label();
            this.OFMname = new System.Windows.Forms.Label();
            this.OFMphoneF = new System.Windows.Forms.TextBox();
            this.OFMaddr1F = new System.Windows.Forms.TextBox();
            this.OFNnameF = new System.Windows.Forms.TextBox();
            this.lblCustomerType = new System.Windows.Forms.Label();
            this.OFMsystemrec = new System.Windows.Forms.Label();
            this.OFMacceptorder = new System.Windows.Forms.Label();
            this.OFMrttcF = new System.Windows.Forms.DateTimePicker();
            this.OFMsystemrecF = new System.Windows.Forms.TextBox();
            this.OFMaoY = new System.Windows.Forms.RadioButton();
            this.OFMaoN = new System.Windows.Forms.RadioButton();
            this.txtOMOrderNumber = new System.Windows.Forms.TextBox();
            this.OFMdateF = new System.Windows.Forms.DateTimePicker();
            this.OFMcn = new System.Windows.Forms.Label();
            this.OFMco = new System.Windows.Forms.Label();
            this.OFMcs = new System.Windows.Forms.Label();
            this.OFMmordernotes = new System.Windows.Forms.Label();
            this.OFMmordernotesF = new System.Windows.Forms.RichTextBox();
            this.OFMcsF = new System.Windows.Forms.TableLayoutPanel();
            this.OFMcnF = new System.Windows.Forms.RichTextBox();
            this.OFMlabel = new System.Windows.Forms.Label();
            this.OFMsubmit = new System.Windows.Forms.Button();
            this.OFMaddr2 = new System.Windows.Forms.Label();
            this.OFMaddr2F = new System.Windows.Forms.TextBox();
            this.OFMcountyF = new System.Windows.Forms.TextBox();
            this.OFMcounty = new System.Windows.Forms.Label();
            this.txtCustomerType = new System.Windows.Forms.TextBox();
            this.lblOFPrice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOFTime = new System.Windows.Forms.TextBox();
            this.txtPriceActual = new System.Windows.Forms.TextBox();
            this.lblDeadline = new System.Windows.Forms.Label();
            this.lstBoxItems = new System.Windows.Forms.ListBox();
            this.lblMStartDate = new System.Windows.Forms.Label();
            this.dtpMstartDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Order Number";
            // 
            // OFMdate
            // 
            this.OFMdate.AutoSize = true;
            this.OFMdate.Location = new System.Drawing.Point(301, 45);
            this.OFMdate.Name = "OFMdate";
            this.OFMdate.Size = new System.Drawing.Size(79, 13);
            this.OFMdate.TabIndex = 9;
            this.OFMdate.Text = "Date Received";
            // 
            // OFMphone
            // 
            this.OFMphone.AutoSize = true;
            this.OFMphone.Location = new System.Drawing.Point(25, 123);
            this.OFMphone.Name = "OFMphone";
            this.OFMphone.Size = new System.Drawing.Size(38, 13);
            this.OFMphone.TabIndex = 26;
            this.OFMphone.Text = "Phone";
            this.OFMphone.Click += new System.EventHandler(this.label4_Click);
            // 
            // OFMaddr1
            // 
            this.OFMaddr1.AutoSize = true;
            this.OFMaddr1.Location = new System.Drawing.Point(12, 153);
            this.OFMaddr1.Name = "OFMaddr1";
            this.OFMaddr1.Size = new System.Drawing.Size(83, 13);
            this.OFMaddr1.TabIndex = 25;
            this.OFMaddr1.Text = "Address - Line 1";
            // 
            // OFMname
            // 
            this.OFMname.AutoSize = true;
            this.OFMname.Location = new System.Drawing.Point(23, 87);
            this.OFMname.Name = "OFMname";
            this.OFMname.Size = new System.Drawing.Size(35, 13);
            this.OFMname.TabIndex = 23;
            this.OFMname.Text = "Name";
            // 
            // OFMphoneF
            // 
            this.OFMphoneF.Location = new System.Drawing.Point(138, 123);
            this.OFMphoneF.Name = "OFMphoneF";
            this.OFMphoneF.Size = new System.Drawing.Size(399, 20);
            this.OFMphoneF.TabIndex = 22;
            // 
            // OFMaddr1F
            // 
            this.OFMaddr1F.Location = new System.Drawing.Point(138, 150);
            this.OFMaddr1F.Name = "OFMaddr1F";
            this.OFMaddr1F.Size = new System.Drawing.Size(402, 20);
            this.OFMaddr1F.TabIndex = 21;
            // 
            // OFNnameF
            // 
            this.OFNnameF.Location = new System.Drawing.Point(138, 84);
            this.OFNnameF.Name = "OFNnameF";
            this.OFNnameF.Size = new System.Drawing.Size(399, 20);
            this.OFNnameF.TabIndex = 20;
            // 
            // lblCustomerType
            // 
            this.lblCustomerType.AutoSize = true;
            this.lblCustomerType.Location = new System.Drawing.Point(16, 250);
            this.lblCustomerType.Name = "lblCustomerType";
            this.lblCustomerType.Size = new System.Drawing.Size(74, 13);
            this.lblCustomerType.TabIndex = 31;
            this.lblCustomerType.Text = "Customer type";
            // 
            // OFMsystemrec
            // 
            this.OFMsystemrec.AutoSize = true;
            this.OFMsystemrec.Location = new System.Drawing.Point(3, 364);
            this.OFMsystemrec.Name = "OFMsystemrec";
            this.OFMsystemrec.Size = new System.Drawing.Size(127, 13);
            this.OFMsystemrec.TabIndex = 35;
            this.OFMsystemrec.Text = "System Recommendation";
            // 
            // OFMacceptorder
            // 
            this.OFMacceptorder.AutoSize = true;
            this.OFMacceptorder.Location = new System.Drawing.Point(12, 392);
            this.OFMacceptorder.Name = "OFMacceptorder";
            this.OFMacceptorder.Size = new System.Drawing.Size(76, 13);
            this.OFMacceptorder.TabIndex = 36;
            this.OFMacceptorder.Text = "Accept Order?";
            // 
            // OFMrttcF
            // 
            this.OFMrttcF.Location = new System.Drawing.Point(138, 306);
            this.OFMrttcF.Name = "OFMrttcF";
            this.OFMrttcF.Size = new System.Drawing.Size(399, 20);
            this.OFMrttcF.TabIndex = 38;
            // 
            // OFMsystemrecF
            // 
            this.OFMsystemrecF.Location = new System.Drawing.Point(136, 361);
            this.OFMsystemrecF.Name = "OFMsystemrecF";
            this.OFMsystemrecF.Size = new System.Drawing.Size(399, 20);
            this.OFMsystemrecF.TabIndex = 41;
            // 
            // OFMaoY
            // 
            this.OFMaoY.AutoSize = true;
            this.OFMaoY.Location = new System.Drawing.Point(147, 388);
            this.OFMaoY.Name = "OFMaoY";
            this.OFMaoY.Size = new System.Drawing.Size(43, 17);
            this.OFMaoY.TabIndex = 43;
            this.OFMaoY.TabStop = true;
            this.OFMaoY.Text = "Yes";
            this.OFMaoY.UseVisualStyleBackColor = true;
            // 
            // OFMaoN
            // 
            this.OFMaoN.AutoSize = true;
            this.OFMaoN.Location = new System.Drawing.Point(442, 390);
            this.OFMaoN.Name = "OFMaoN";
            this.OFMaoN.Size = new System.Drawing.Size(39, 17);
            this.OFMaoN.TabIndex = 44;
            this.OFMaoN.TabStop = true;
            this.OFMaoN.Text = "No";
            this.OFMaoN.UseVisualStyleBackColor = true;
            // 
            // txtOMOrderNumber
            // 
            this.txtOMOrderNumber.Location = new System.Drawing.Point(138, 45);
            this.txtOMOrderNumber.Name = "txtOMOrderNumber";
            this.txtOMOrderNumber.Size = new System.Drawing.Size(157, 20);
            this.txtOMOrderNumber.TabIndex = 45;
            this.txtOMOrderNumber.Leave += new System.EventHandler(this.txtOMOrderNumber_Leave);
            // 
            // OFMdateF
            // 
            this.OFMdateF.Location = new System.Drawing.Point(386, 45);
            this.OFMdateF.Name = "OFMdateF";
            this.OFMdateF.Size = new System.Drawing.Size(151, 20);
            this.OFMdateF.TabIndex = 46;
            // 
            // OFMcn
            // 
            this.OFMcn.AutoSize = true;
            this.OFMcn.Location = new System.Drawing.Point(733, 9);
            this.OFMcn.Name = "OFMcn";
            this.OFMcn.Size = new System.Drawing.Size(82, 13);
            this.OFMcn.TabIndex = 47;
            this.OFMcn.Text = "Customer Notes";
            // 
            // OFMco
            // 
            this.OFMco.AutoSize = true;
            this.OFMco.Location = new System.Drawing.Point(733, 114);
            this.OFMco.Name = "OFMco";
            this.OFMco.Size = new System.Drawing.Size(72, 13);
            this.OFMco.TabIndex = 48;
            this.OFMco.Text = "Items in Order";
            // 
            // OFMcs
            // 
            this.OFMcs.AutoSize = true;
            this.OFMcs.Location = new System.Drawing.Point(733, 279);
            this.OFMcs.Name = "OFMcs";
            this.OFMcs.Size = new System.Drawing.Size(89, 13);
            this.OFMcs.TabIndex = 49;
            this.OFMcs.Text = "Current Schedule";
            // 
            // OFMmordernotes
            // 
            this.OFMmordernotes.AutoSize = true;
            this.OFMmordernotes.Location = new System.Drawing.Point(3, 441);
            this.OFMmordernotes.Name = "OFMmordernotes";
            this.OFMmordernotes.Size = new System.Drawing.Size(115, 13);
            this.OFMmordernotes.TabIndex = 51;
            this.OFMmordernotes.Text = "Manager - Order Notes";
            // 
            // OFMmordernotesF
            // 
            this.OFMmordernotesF.Location = new System.Drawing.Point(138, 419);
            this.OFMmordernotesF.Name = "OFMmordernotesF";
            this.OFMmordernotesF.Size = new System.Drawing.Size(399, 48);
            this.OFMmordernotesF.TabIndex = 54;
            this.OFMmordernotesF.Text = "";
            // 
            // OFMcsF
            // 
            this.OFMcsF.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.OFMcsF.ColumnCount = 3;
            this.OFMcsF.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 49.79253F));
            this.OFMcsF.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.20747F));
            this.OFMcsF.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.OFMcsF.Location = new System.Drawing.Point(635, 323);
            this.OFMcsF.Name = "OFMcsF";
            this.OFMcsF.RowCount = 6;
            this.OFMcsF.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.84536F));
            this.OFMcsF.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 55.15464F));
            this.OFMcsF.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 86F));
            this.OFMcsF.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.OFMcsF.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.OFMcsF.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.OFMcsF.Size = new System.Drawing.Size(280, 403);
            this.OFMcsF.TabIndex = 57;
            // 
            // OFMcnF
            // 
            this.OFMcnF.Location = new System.Drawing.Point(635, 31);
            this.OFMcnF.Name = "OFMcnF";
            this.OFMcnF.Size = new System.Drawing.Size(280, 64);
            this.OFMcnF.TabIndex = 55;
            this.OFMcnF.Text = "";
            // 
            // OFMlabel
            // 
            this.OFMlabel.AutoSize = true;
            this.OFMlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OFMlabel.Location = new System.Drawing.Point(215, 0);
            this.OFMlabel.Name = "OFMlabel";
            this.OFMlabel.Size = new System.Drawing.Size(225, 25);
            this.OFMlabel.TabIndex = 58;
            this.OFMlabel.Text = "Order Form - Manager";
            this.OFMlabel.Click += new System.EventHandler(this.label18_Click);
            // 
            // OFMsubmit
            // 
            this.OFMsubmit.Location = new System.Drawing.Point(293, 472);
            this.OFMsubmit.Margin = new System.Windows.Forms.Padding(2);
            this.OFMsubmit.Name = "OFMsubmit";
            this.OFMsubmit.Size = new System.Drawing.Size(64, 24);
            this.OFMsubmit.TabIndex = 59;
            this.OFMsubmit.Text = "Submit";
            this.OFMsubmit.UseVisualStyleBackColor = true;
            this.OFMsubmit.Click += new System.EventHandler(this.OFMsubmit_Click);
            // 
            // OFMaddr2
            // 
            this.OFMaddr2.AutoSize = true;
            this.OFMaddr2.Location = new System.Drawing.Point(10, 185);
            this.OFMaddr2.Name = "OFMaddr2";
            this.OFMaddr2.Size = new System.Drawing.Size(83, 13);
            this.OFMaddr2.TabIndex = 60;
            this.OFMaddr2.Text = "Address - Line 2";
            // 
            // OFMaddr2F
            // 
            this.OFMaddr2F.Location = new System.Drawing.Point(138, 182);
            this.OFMaddr2F.Name = "OFMaddr2F";
            this.OFMaddr2F.Size = new System.Drawing.Size(402, 20);
            this.OFMaddr2F.TabIndex = 61;
            // 
            // OFMcountyF
            // 
            this.OFMcountyF.Location = new System.Drawing.Point(138, 214);
            this.OFMcountyF.Name = "OFMcountyF";
            this.OFMcountyF.Size = new System.Drawing.Size(402, 20);
            this.OFMcountyF.TabIndex = 62;
            // 
            // OFMcounty
            // 
            this.OFMcounty.AutoSize = true;
            this.OFMcounty.Location = new System.Drawing.Point(25, 217);
            this.OFMcounty.Name = "OFMcounty";
            this.OFMcounty.Size = new System.Drawing.Size(40, 13);
            this.OFMcounty.TabIndex = 63;
            this.OFMcounty.Text = "County";
            // 
            // txtCustomerType
            // 
            this.txtCustomerType.Location = new System.Drawing.Point(138, 245);
            this.txtCustomerType.Name = "txtCustomerType";
            this.txtCustomerType.Size = new System.Drawing.Size(402, 20);
            this.txtCustomerType.TabIndex = 64;
            // 
            // lblOFPrice
            // 
            this.lblOFPrice.AutoSize = true;
            this.lblOFPrice.Location = new System.Drawing.Point(25, 283);
            this.lblOFPrice.Name = "lblOFPrice";
            this.lblOFPrice.Size = new System.Drawing.Size(46, 13);
            this.lblOFPrice.TabIndex = 65;
            this.lblOFPrice.Text = "Price (£)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 279);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Time (in Hours)";
            // 
            // txtOFTime
            // 
            this.txtOFTime.Location = new System.Drawing.Point(409, 276);
            this.txtOFTime.Name = "txtOFTime";
            this.txtOFTime.Size = new System.Drawing.Size(131, 20);
            this.txtOFTime.TabIndex = 67;
            // 
            // txtPriceActual
            // 
            this.txtPriceActual.Location = new System.Drawing.Point(138, 276);
            this.txtPriceActual.Name = "txtPriceActual";
            this.txtPriceActual.Size = new System.Drawing.Size(157, 20);
            this.txtPriceActual.TabIndex = 68;
            // 
            // lblDeadline
            // 
            this.lblDeadline.AutoSize = true;
            this.lblDeadline.Location = new System.Drawing.Point(22, 312);
            this.lblDeadline.Name = "lblDeadline";
            this.lblDeadline.Size = new System.Drawing.Size(49, 13);
            this.lblDeadline.TabIndex = 69;
            this.lblDeadline.Text = "Deadline";
            // 
            // lstBoxItems
            // 
            this.lstBoxItems.FormattingEnabled = true;
            this.lstBoxItems.Location = new System.Drawing.Point(635, 153);
            this.lstBoxItems.Name = "lstBoxItems";
            this.lstBoxItems.Size = new System.Drawing.Size(280, 108);
            this.lstBoxItems.TabIndex = 70;
            // 
            // lblMStartDate
            // 
            this.lblMStartDate.AutoSize = true;
            this.lblMStartDate.Location = new System.Drawing.Point(16, 338);
            this.lblMStartDate.Name = "lblMStartDate";
            this.lblMStartDate.Size = new System.Drawing.Size(55, 13);
            this.lblMStartDate.TabIndex = 71;
            this.lblMStartDate.Text = "Start Date";
            // 
            // dtpMstartDate
            // 
            this.dtpMstartDate.Location = new System.Drawing.Point(136, 335);
            this.dtpMstartDate.Name = "dtpMstartDate";
            this.dtpMstartDate.Size = new System.Drawing.Size(399, 20);
            this.dtpMstartDate.TabIndex = 72;
            // 
            // OrderManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(950, 769);
            this.Controls.Add(this.dtpMstartDate);
            this.Controls.Add(this.lblMStartDate);
            this.Controls.Add(this.lstBoxItems);
            this.Controls.Add(this.lblDeadline);
            this.Controls.Add(this.txtPriceActual);
            this.Controls.Add(this.txtOFTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblOFPrice);
            this.Controls.Add(this.txtCustomerType);
            this.Controls.Add(this.OFMcounty);
            this.Controls.Add(this.OFMcountyF);
            this.Controls.Add(this.OFMaddr2F);
            this.Controls.Add(this.OFMaddr2);
            this.Controls.Add(this.OFMsubmit);
            this.Controls.Add(this.OFMlabel);
            this.Controls.Add(this.OFMcnF);
            this.Controls.Add(this.OFMcsF);
            this.Controls.Add(this.OFMmordernotesF);
            this.Controls.Add(this.OFMmordernotes);
            this.Controls.Add(this.OFMcs);
            this.Controls.Add(this.OFMco);
            this.Controls.Add(this.OFMcn);
            this.Controls.Add(this.OFMdateF);
            this.Controls.Add(this.txtOMOrderNumber);
            this.Controls.Add(this.OFMaoN);
            this.Controls.Add(this.OFMaoY);
            this.Controls.Add(this.OFMsystemrecF);
            this.Controls.Add(this.OFMrttcF);
            this.Controls.Add(this.OFMacceptorder);
            this.Controls.Add(this.OFMsystemrec);
            this.Controls.Add(this.lblCustomerType);
            this.Controls.Add(this.OFMphone);
            this.Controls.Add(this.OFMaddr1);
            this.Controls.Add(this.OFMname);
            this.Controls.Add(this.OFMphoneF);
            this.Controls.Add(this.OFMaddr1F);
            this.Controls.Add(this.OFNnameF);
            this.Controls.Add(this.OFMdate);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OrderManager";
            this.Text = "Order Form - Manager";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label OFMdate;
        private System.Windows.Forms.Label OFMphone;
        private System.Windows.Forms.Label OFMaddr1;
        private System.Windows.Forms.Label OFMname;
        private System.Windows.Forms.TextBox OFMphoneF;
        private System.Windows.Forms.TextBox OFMaddr1F;
        private System.Windows.Forms.TextBox OFNnameF;
        private System.Windows.Forms.Label lblCustomerType;
        private System.Windows.Forms.Label OFMsystemrec;
        private System.Windows.Forms.Label OFMacceptorder;
        private System.Windows.Forms.DateTimePicker OFMrttcF;
        private System.Windows.Forms.TextBox OFMsystemrecF;
        private System.Windows.Forms.RadioButton OFMaoY;
        private System.Windows.Forms.RadioButton OFMaoN;
        private System.Windows.Forms.TextBox txtOMOrderNumber;
        private System.Windows.Forms.DateTimePicker OFMdateF;
        private System.Windows.Forms.Label OFMcn;
        private System.Windows.Forms.Label OFMco;
        private System.Windows.Forms.Label OFMcs;
        private System.Windows.Forms.Label OFMmordernotes;
        private System.Windows.Forms.RichTextBox OFMmordernotesF;
        private System.Windows.Forms.TableLayoutPanel OFMcsF;
        private System.Windows.Forms.RichTextBox OFMcnF;
        private System.Windows.Forms.Label OFMlabel;
        private System.Windows.Forms.Button OFMsubmit;
        private System.Windows.Forms.Label OFMaddr2;
        private System.Windows.Forms.TextBox OFMaddr2F;
        private System.Windows.Forms.TextBox OFMcountyF;
        private System.Windows.Forms.Label OFMcounty;
        private System.Windows.Forms.TextBox txtCustomerType;
        private System.Windows.Forms.Label lblOFPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOFTime;
        private System.Windows.Forms.TextBox txtPriceActual;
        private System.Windows.Forms.Label lblDeadline;
        private System.Windows.Forms.ListBox lstBoxItems;
        private System.Windows.Forms.Label lblMStartDate;
        private System.Windows.Forms.DateTimePicker dtpMstartDate;
    }
}