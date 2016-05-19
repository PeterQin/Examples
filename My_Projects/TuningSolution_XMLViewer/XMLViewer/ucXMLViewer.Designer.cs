namespace XMLViewer
{
    partial class ucXMLViewer
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
            this.webViewer = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webViewer
            // 
            this.webViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webViewer.Location = new System.Drawing.Point(0, 3);
            this.webViewer.MinimumSize = new System.Drawing.Size(20, 20);
            this.webViewer.Name = "webViewer";
            this.webViewer.Size = new System.Drawing.Size(396, 310);
            this.webViewer.TabIndex = 0;
            // 
            // ucXMLViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.webViewer);
            this.Name = "ucXMLViewer";
            this.Padding = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.Size = new System.Drawing.Size(396, 316);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webViewer;
    }
}
