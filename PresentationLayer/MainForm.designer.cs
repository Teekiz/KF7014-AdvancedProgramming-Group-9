
namespace PresentationLayer
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.MFb1 = new System.Windows.Forms.Button();
            this.MFb2 = new System.Windows.Forms.Button();
            this.MFb3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PresentationLayer.Properties.Resources.iron_helm_1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 133);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1200, 652);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictureBox2.Image = global::PresentationLayer.Properties.Resources.logo;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(186, 134);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // MFb1
            // 
            this.MFb1.Location = new System.Drawing.Point(288, 24);
            this.MFb1.Name = "MFb1";
            this.MFb1.Size = new System.Drawing.Size(157, 76);
            this.MFb1.TabIndex = 2;
            this.MFb1.Text = "Order";
            this.MFb1.UseVisualStyleBackColor = true;
            this.MFb1.Click += new System.EventHandler(this.MFb1_Click);
            // 
            // MFb2
            // 
            this.MFb2.Location = new System.Drawing.Point(603, 24);
            this.MFb2.Name = "MFb2";
            this.MFb2.Size = new System.Drawing.Size(163, 76);
            this.MFb2.TabIndex = 3;
            this.MFb2.Text = "Manager";
            this.MFb2.UseVisualStyleBackColor = true;
            this.MFb2.Click += new System.EventHandler(this.MFb2_Click);
            // 
            // MFb3
            // 
            this.MFb3.Location = new System.Drawing.Point(928, 24);
            this.MFb3.Name = "MFb3";
            this.MFb3.Size = new System.Drawing.Size(171, 76);
            this.MFb3.TabIndex = 4;
            this.MFb3.Text = "button3";
            this.MFb3.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1198, 781);
            this.Controls.Add(this.MFb3);
            this.Controls.Add(this.MFb2);
            this.Controls.Add(this.MFb1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Name = "MainForm";
            this.Text = "Home Page";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button MFb1;
        private System.Windows.Forms.Button MFb2;
        private System.Windows.Forms.Button MFb3;
    }
}