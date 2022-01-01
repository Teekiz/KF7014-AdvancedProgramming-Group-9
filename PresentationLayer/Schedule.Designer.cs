
namespace PresentationLayer
{
    partial class Schedule
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Schedule));
            this.dgvSchedule = new System.Windows.Forms.DataGridView();
            this.dgvOrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvScheduleStartDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvScheduleDeadline = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOrderNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvNumberOfItems = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvProgress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvOnSchedule = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSchedule
            // 
            this.dgvSchedule.AllowUserToAddRows = false;
            this.dgvSchedule.AllowUserToDeleteRows = false;
            this.dgvSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvOrderID,
            this.dgvScheduleStartDate,
            this.dgvScheduleDeadline,
            this.dgvOrderNotes,
            this.dgvNumberOfItems,
            this.dgvProgress,
            this.dgvOnSchedule});
            this.dgvSchedule.Location = new System.Drawing.Point(27, 78);
            this.dgvSchedule.MultiSelect = false;
            this.dgvSchedule.Name = "dgvSchedule";
            this.dgvSchedule.ReadOnly = true;
            this.dgvSchedule.Size = new System.Drawing.Size(744, 360);
            this.dgvSchedule.TabIndex = 0;
            this.dgvSchedule.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSchedule_CellMouseDoubleClick);
            // 
            // dgvOrderID
            // 
            this.dgvOrderID.HeaderText = "OrderID";
            this.dgvOrderID.Name = "dgvOrderID";
            this.dgvOrderID.ReadOnly = true;
            // 
            // dgvScheduleStartDate
            // 
            this.dgvScheduleStartDate.HeaderText = "Start Date";
            this.dgvScheduleStartDate.Name = "dgvScheduleStartDate";
            this.dgvScheduleStartDate.ReadOnly = true;
            // 
            // dgvScheduleDeadline
            // 
            this.dgvScheduleDeadline.HeaderText = "Deadline";
            this.dgvScheduleDeadline.Name = "dgvScheduleDeadline";
            this.dgvScheduleDeadline.ReadOnly = true;
            // 
            // dgvOrderNotes
            // 
            this.dgvOrderNotes.HeaderText = "Order Notes";
            this.dgvOrderNotes.Name = "dgvOrderNotes";
            this.dgvOrderNotes.ReadOnly = true;
            // 
            // dgvNumberOfItems
            // 
            this.dgvNumberOfItems.HeaderText = "NumberOfItems";
            this.dgvNumberOfItems.Name = "dgvNumberOfItems";
            this.dgvNumberOfItems.ReadOnly = true;
            // 
            // dgvProgress
            // 
            this.dgvProgress.HeaderText = "Progress (%)";
            this.dgvProgress.Name = "dgvProgress";
            this.dgvProgress.ReadOnly = true;
            // 
            // dgvOnSchedule
            // 
            this.dgvOnSchedule.HeaderText = "On Schedule";
            this.dgvOnSchedule.Name = "dgvOnSchedule";
            this.dgvOnSchedule.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bookman Old Style", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(340, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Schedule";
            // 
            // Schedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvSchedule);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Schedule";
            this.Text = "Schedule";
            this.Load += new System.EventHandler(this.Schedule_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSchedule)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSchedule;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderID;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvScheduleStartDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvScheduleDeadline;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOrderNotes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvNumberOfItems;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvProgress;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvOnSchedule;
        private System.Windows.Forms.Label label1;
    }
}