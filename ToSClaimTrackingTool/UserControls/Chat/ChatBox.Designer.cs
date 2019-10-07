namespace ToSClaimTrackingTool.UserControls.Chat
{
    partial class ChatBox
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
            this.timeSelector = new ToSClaimTrackingTool.UserControls.Chat.ChatTimeSelector();
            this.pChatLines = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // timeSelector
            // 
            this.timeSelector.Location = new System.Drawing.Point(0, 0);
            this.timeSelector.Name = "timeSelector";
            this.timeSelector.Size = new System.Drawing.Size(1325, 34);
            this.timeSelector.TabIndex = 0;
            // 
            // pChatLines
            // 
            this.pChatLines.AutoScroll = true;
            this.pChatLines.Location = new System.Drawing.Point(0, 35);
            this.pChatLines.Name = "pChatLines";
            this.pChatLines.Size = new System.Drawing.Size(1325, 324);
            this.pChatLines.TabIndex = 1;
            // 
            // ChatBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pChatLines);
            this.Controls.Add(this.timeSelector);
            this.Name = "ChatBox";
            this.Size = new System.Drawing.Size(1325, 359);
            this.ResumeLayout(false);

        }

        #endregion

        private ChatTimeSelector timeSelector;
        private System.Windows.Forms.Panel pChatLines;
    }
}
