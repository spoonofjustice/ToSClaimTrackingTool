namespace ToSClaimTrackingTool.UserControls
{
    partial class RosterBox
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
            this.pTown = new System.Windows.Forms.Panel();
            this.pEvil = new System.Windows.Forms.Panel();
            this.pRandomTown = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pTown
            // 
            this.pTown.Location = new System.Drawing.Point(0, 0);
            this.pTown.Name = "pTown";
            this.pTown.Size = new System.Drawing.Size(300, 160);
            this.pTown.TabIndex = 0;
            // 
            // pEvil
            // 
            this.pEvil.Location = new System.Drawing.Point(3, 190);
            this.pEvil.Name = "pEvil";
            this.pEvil.Size = new System.Drawing.Size(300, 160);
            this.pEvil.TabIndex = 1;
            // 
            // pRandomTown
            // 
            this.pRandomTown.Location = new System.Drawing.Point(305, 0);
            this.pRandomTown.Name = "pRandomTown";
            this.pRandomTown.Size = new System.Drawing.Size(300, 350);
            this.pRandomTown.TabIndex = 1;
            // 
            // RosterBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pRandomTown);
            this.Controls.Add(this.pEvil);
            this.Controls.Add(this.pTown);
            this.Name = "RosterBox";
            this.Size = new System.Drawing.Size(605, 350);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pTown;
        private System.Windows.Forms.Panel pEvil;
        private System.Windows.Forms.Panel pRandomTown;
    }
}
