
namespace PresentationLayer
{
    partial class ScheduleOrderScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScheduleOrderScreen));
            this.rtbOrderNotes = new System.Windows.Forms.RichTextBox();
            this.lblOrderNotes = new System.Windows.Forms.Label();
            this.lblOrderItems = new System.Windows.Forms.Label();
            this.txtPercentComplete = new System.Windows.Forms.TextBox();
            this.lblPercentCompleted = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.lstOrders = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // rtbOrderNotes
            // 
            this.rtbOrderNotes.Location = new System.Drawing.Point(12, 48);
            this.rtbOrderNotes.Name = "rtbOrderNotes";
            this.rtbOrderNotes.ReadOnly = true;
            this.rtbOrderNotes.Size = new System.Drawing.Size(484, 96);
            this.rtbOrderNotes.TabIndex = 0;
            this.rtbOrderNotes.Text = "";
            // 
            // lblOrderNotes
            // 
            this.lblOrderNotes.AutoSize = true;
            this.lblOrderNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderNotes.ForeColor = System.Drawing.Color.White;
            this.lblOrderNotes.Location = new System.Drawing.Point(186, 9);
            this.lblOrderNotes.Name = "lblOrderNotes";
            this.lblOrderNotes.Size = new System.Drawing.Size(128, 25);
            this.lblOrderNotes.TabIndex = 2;
            this.lblOrderNotes.Text = "Order Notes";
            // 
            // lblOrderItems
            // 
            this.lblOrderItems.AutoSize = true;
            this.lblOrderItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOrderItems.ForeColor = System.Drawing.Color.White;
            this.lblOrderItems.Location = new System.Drawing.Point(151, 160);
            this.lblOrderItems.Name = "lblOrderItems";
            this.lblOrderItems.Size = new System.Drawing.Size(204, 29);
            this.lblOrderItems.TabIndex = 3;
            this.lblOrderItems.Text = "Items in the Order";
            // 
            // txtPercentComplete
            // 
            this.txtPercentComplete.Location = new System.Drawing.Point(206, 388);
            this.txtPercentComplete.Name = "txtPercentComplete";
            this.txtPercentComplete.Size = new System.Drawing.Size(87, 20);
            this.txtPercentComplete.TabIndex = 4;
            // 
            // lblPercentCompleted
            // 
            this.lblPercentCompleted.AutoSize = true;
            this.lblPercentCompleted.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPercentCompleted.ForeColor = System.Drawing.Color.White;
            this.lblPercentCompleted.Location = new System.Drawing.Point(171, 356);
            this.lblPercentCompleted.Name = "lblPercentCompleted";
            this.lblPercentCompleted.Size = new System.Drawing.Size(155, 29);
            this.lblPercentCompleted.TabIndex = 5;
            this.lblPercentCompleted.Text = "Progress (%)";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(206, 414);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(87, 49);
            this.btnUpdate.TabIndex = 6;
            this.btnUpdate.Text = "Update Progress";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // lstOrders
            // 
            this.lstOrders.FormattingEnabled = true;
            this.lstOrders.Location = new System.Drawing.Point(12, 206);
            this.lstOrders.Name = "lstOrders";
            this.lstOrders.Size = new System.Drawing.Size(484, 147);
            this.lstOrders.TabIndex = 7;
            // 
            // ScheduleOrderScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(508, 519);
            this.Controls.Add(this.lstOrders);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblPercentCompleted);
            this.Controls.Add(this.txtPercentComplete);
            this.Controls.Add(this.lblOrderItems);
            this.Controls.Add(this.lblOrderNotes);
            this.Controls.Add(this.rtbOrderNotes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ScheduleOrderScreen";
            this.Text = "Schedule Order Screen";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbOrderNotes;
        private System.Windows.Forms.Label lblOrderNotes;
        private System.Windows.Forms.Label lblOrderItems;
        private System.Windows.Forms.TextBox txtPercentComplete;
        private System.Windows.Forms.Label lblPercentCompleted;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ListBox lstOrders;
    }
}