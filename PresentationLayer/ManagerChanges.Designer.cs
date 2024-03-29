﻿
namespace PresentationLayer
{
    partial class ManagerChanges
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManagerChanges));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CorderID = new System.Windows.Forms.TextBox();
            this.CstartDate = new System.Windows.Forms.DateTimePicker();
            this.CendDate = new System.Windows.Forms.DateTimePicker();
            this.EendDate = new System.Windows.Forms.DateTimePicker();
            this.EstartDate = new System.Windows.Forms.DateTimePicker();
            this.EorderID = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.pushChanges = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(73, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(668, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "It is possible to change this item due to low priority";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Order ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Deadline";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(33, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Start Date";
            // 
            // CorderID
            // 
            this.CorderID.Location = new System.Drawing.Point(128, 96);
            this.CorderID.Name = "CorderID";
            this.CorderID.Size = new System.Drawing.Size(613, 20);
            this.CorderID.TabIndex = 4;
            this.CorderID.TextChanged += new System.EventHandler(this.CorderID_TextChanged);
            // 
            // CstartDate
            // 
            this.CstartDate.Location = new System.Drawing.Point(128, 153);
            this.CstartDate.Name = "CstartDate";
            this.CstartDate.Size = new System.Drawing.Size(613, 20);
            this.CstartDate.TabIndex = 5;
            this.CstartDate.ValueChanged += new System.EventHandler(this.CstartDate_ValueChanged);
            // 
            // CendDate
            // 
            this.CendDate.Location = new System.Drawing.Point(128, 213);
            this.CendDate.Name = "CendDate";
            this.CendDate.Size = new System.Drawing.Size(613, 20);
            this.CendDate.TabIndex = 6;
            this.CendDate.ValueChanged += new System.EventHandler(this.CendDate_ValueChanged);
            // 
            // EendDate
            // 
            this.EendDate.Location = new System.Drawing.Point(128, 475);
            this.EendDate.Name = "EendDate";
            this.EendDate.Size = new System.Drawing.Size(613, 20);
            this.EendDate.TabIndex = 12;
            this.EendDate.ValueChanged += new System.EventHandler(this.EendDate_ValueChanged);
            // 
            // EstartDate
            // 
            this.EstartDate.Location = new System.Drawing.Point(128, 415);
            this.EstartDate.Name = "EstartDate";
            this.EstartDate.Size = new System.Drawing.Size(613, 20);
            this.EstartDate.TabIndex = 11;
            // 
            // EorderID
            // 
            this.EorderID.Location = new System.Drawing.Point(128, 358);
            this.EorderID.Name = "EorderID";
            this.EorderID.Size = new System.Drawing.Size(613, 20);
            this.EorderID.TabIndex = 10;
            this.EorderID.TextChanged += new System.EventHandler(this.EorderID_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 415);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Start Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 475);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "Deadline";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(31, 356);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.TabIndex = 7;
            this.label7.Text = "Order ID";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(338, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(124, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Conflicting order";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(338, 318);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 20);
            this.label9.TabIndex = 14;
            this.label9.Text = "Existing order";
            // 
            // pushChanges
            // 
            this.pushChanges.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pushChanges.Location = new System.Drawing.Point(262, 550);
            this.pushChanges.Name = "pushChanges";
            this.pushChanges.Size = new System.Drawing.Size(275, 115);
            this.pushChanges.TabIndex = 15;
            this.pushChanges.Text = "Push changes";
            this.pushChanges.UseVisualStyleBackColor = true;
            this.pushChanges.Click += new System.EventHandler(this.pushChanges_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.white5;
            this.pictureBox1.Location = new System.Drawing.Point(17, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(784, 647);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 81;
            this.pictureBox1.TabStop = false;
            // 
            // ManagerChanges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(818, 705);
            this.Controls.Add(this.pushChanges);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.EendDate);
            this.Controls.Add(this.EstartDate);
            this.Controls.Add(this.EorderID);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CendDate);
            this.Controls.Add(this.CstartDate);
            this.Controls.Add(this.CorderID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ManagerChanges";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.Form4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CorderID;
        private System.Windows.Forms.DateTimePicker CstartDate;
        private System.Windows.Forms.DateTimePicker CendDate;
        private System.Windows.Forms.DateTimePicker EendDate;
        private System.Windows.Forms.DateTimePicker EstartDate;
        private System.Windows.Forms.TextBox EorderID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button pushChanges;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}