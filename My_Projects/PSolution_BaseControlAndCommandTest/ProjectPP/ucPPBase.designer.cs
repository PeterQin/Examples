namespace PSolution.ProjectPP
{
    partial class ucPPBase
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
            this.ucPPMainMidUI1 = new PSolution.ProjectPP.ucPPMainMidUI();
            this.SuspendLayout();
            // 
            // ucPPMainMidUI1
            // 
            this.ucPPMainMidUI1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucPPMainMidUI1.Location = new System.Drawing.Point(0, 0);
            this.ucPPMainMidUI1.Name = "ucPPMainMidUI1";
            this.ucPPMainMidUI1.Size = new System.Drawing.Size(246, 189);
            this.ucPPMainMidUI1.TabIndex = 0;
            // 
            // ucPPBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ucPPMainMidUI1);
            this.Name = "ucPPBase";
            this.Size = new System.Drawing.Size(246, 189);
            this.ResumeLayout(false);

        }

        #endregion

        private ucPPMainMidUI ucPPMainMidUI1;
    }
}
