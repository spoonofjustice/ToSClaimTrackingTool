namespace ToSClaimTrackingTool.UserControls.Chat
{
    partial class ChatLineLabel
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
            this.lblPlayerNumber = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtChat = new System.Windows.Forms.TextBox();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblPlayerNumber
            // 
            this.lblPlayerNumber.BackColor = System.Drawing.Color.White;
            this.lblPlayerNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPlayerNumber.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerNumber.Location = new System.Drawing.Point(0, 0);
            this.lblPlayerNumber.Name = "lblPlayerNumber";
            this.lblPlayerNumber.Size = new System.Drawing.Size(30, 18);
            this.lblPlayerNumber.TabIndex = 0;
            this.lblPlayerNumber.Text = "15";
            this.lblPlayerNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRole
            // 
            this.lblRole.BackColor = System.Drawing.Color.White;
            this.lblRole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRole.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRole.Location = new System.Drawing.Point(29, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(35, 18);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "SHE";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtChat
            // 
            this.txtChat.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtChat.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChat.Location = new System.Drawing.Point(208, 0);
            this.txtChat.Multiline = true;
            this.txtChat.Name = "txtChat";
            this.txtChat.ShortcutsEnabled = false;
            this.txtChat.Size = new System.Drawing.Size(1091, 18);
            this.txtChat.TabIndex = 2;
            this.txtChat.Text = "e4ftgeg;kjeogijeoigjiojhoirjthiortjhiortjhitorjhiojthi4n5h0845hng40jg085j9 u%$T$%" +
    "GB%^$J%J%JK%JM%#JMN%^&J$%I&$YG$%H$^%KJ&^%$IKO$%KJ%&K%T%#BG#";
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.BackColor = System.Drawing.Color.White;
            this.lblPlayerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblPlayerName.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlayerName.Location = new System.Drawing.Point(63, 0);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(139, 18);
            this.lblPlayerName.TabIndex = 3;
            this.lblPlayerName.Text = "Don Pablo";
            this.lblPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChatLineLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.txtChat);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblPlayerNumber);
            this.Name = "ChatLineLabel";
            this.Size = new System.Drawing.Size(1300, 18);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblPlayerNumber;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtChat;
        private System.Windows.Forms.Label lblPlayerName;
    }
}
