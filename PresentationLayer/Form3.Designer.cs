
namespace PresentationLayer
{
    partial class AccessPage
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
            this.APbutton1 = new System.Windows.Forms.Button();
            this.APlabel = new System.Windows.Forms.Label();
            this.APbutton2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // APbutton1
            // 
            this.APbutton1.Location = new System.Drawing.Point(56, 133);
            this.APbutton1.Name = "APbutton1";
            this.APbutton1.Size = new System.Drawing.Size(227, 124);
            this.APbutton1.TabIndex = 0;
            this.APbutton1.Text = "Schedule";
            this.APbutton1.UseVisualStyleBackColor = true;
            this.APbutton1.Click += new System.EventHandler(this.APbutton1_Click);
            // 
            // APlabel
            // 
            this.APlabel.AutoSize = true;
            this.APlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.APlabel.Location = new System.Drawing.Point(296, 26);
            this.APlabel.Name = "APlabel";
            this.APlabel.Size = new System.Drawing.Size(173, 31);
            this.APlabel.TabIndex = 2;
            this.APlabel.Text = "Access Page";
            // 
            // APbutton2
            // 
            this.APbutton2.Location = new System.Drawing.Point(481, 133);
            this.APbutton2.Name = "APbutton2";
            this.APbutton2.Size = new System.Drawing.Size(227, 124);
            this.APbutton2.TabIndex = 3;
            this.APbutton2.Text = "Manager Form";
            this.APbutton2.UseVisualStyleBackColor = true;
            this.APbutton2.Click += new System.EventHandler(this.APbutton2_Click);
            // 
            // AccessPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(783, 400);
            this.Controls.Add(this.APbutton2);
            this.Controls.Add(this.APlabel);
            this.Controls.Add(this.APbutton1);
            this.Name = "AccessPage";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button APbutton1;
        private System.Windows.Forms.Label APlabel;
        private System.Windows.Forms.Button APbutton2;
    }
}