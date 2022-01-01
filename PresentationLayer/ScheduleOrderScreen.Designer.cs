
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
            this.lblOrderNotes.Location = new System.Drawing.Point(229, 32);
            this.lblOrderNotes.Name = "lblOrderNotes";
            this.lblOrderNotes.Size = new System.Drawing.Size(64, 13);
            this.lblOrderNotes.TabIndex = 2;
            this.lblOrderNotes.Text = "Order Notes";
            // 
            // lblOrderItems
            // 
            this.lblOrderItems.AutoSize = true;
            this.lblOrderItems.Location = new System.Drawing.Point(203, 171);
            this.lblOrderItems.Name = "lblOrderItems";
            this.lblOrderItems.Size = new System.Drawing.Size(90, 13);
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
            this.lblPercentCompleted.Location = new System.Drawing.Point(218, 372);
            this.lblPercentCompleted.Name = "lblPercentCompleted";
            this.lblPercentCompleted.Size = new System.Drawing.Size(65, 13);
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
            this.ClientSize = new System.Drawing.Size(508, 519);
            this.Controls.Add(this.lstOrders);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblPercentCompleted);
            this.Controls.Add(this.txtPercentComplete);
            this.Controls.Add(this.lblOrderItems);
            this.Controls.Add(this.lblOrderNotes);
            this.Controls.Add(this.rtbOrderNotes);
            this.Name = "ScheduleOrderScreen";
            this.Text = "Form5";
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