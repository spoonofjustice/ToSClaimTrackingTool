namespace ToSClaimTrackingTool.UserControls
{
    partial class RoleSlotLabel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblRoleSlot = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblRoleShortName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblRoleSlot
            // 
            this.lblRoleSlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRoleSlot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoleSlot.Location = new System.Drawing.Point(0, 0);
            this.lblRoleSlot.Name = "lblRoleSlot";
            this.lblRoleSlot.Size = new System.Drawing.Size(125, 24);
            this.lblRoleSlot.TabIndex = 4;
            this.lblRoleSlot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(160, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(140, 24);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRoleShortName
            // 
            this.lblRoleShortName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRoleShortName.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRoleShortName.Location = new System.Drawing.Point(124, 0);
            this.lblRoleShortName.Name = "lblRoleShortName";
            this.lblRoleShortName.Size = new System.Drawing.Size(35, 24);
            this.lblRoleShortName.TabIndex = 6;
            this.lblRoleShortName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // RoleSlotLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRoleShortName);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblRoleSlot);
            this.Name = "RoleSlotLabel";
            this.Size = new System.Drawing.Size(300, 25);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRoleSlot;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblRoleShortName;
    }
}
