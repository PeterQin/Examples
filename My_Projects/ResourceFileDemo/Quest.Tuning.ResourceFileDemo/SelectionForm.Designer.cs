namespace Quest.Tuning.ResourceFileDemo
{
    partial class SelectionForm
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
            this.cmbUICultrue = new System.Windows.Forms.ComboBox();
            this.cmbCultrue = new System.Windows.Forms.ComboBox();
            this.lblUICultrue = new System.Windows.Forms.Label();
            this.lblCultrue = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbUICultrue
            // 
            this.cmbUICultrue.FormattingEnabled = true;
            this.cmbUICultrue.Items.AddRange(new object[] {
            "zh-CHS",
            "zh-HK",
            "en-US",
            "ja-JP"});
            this.cmbUICultrue.Location = new System.Drawing.Point(72, 36);
            this.cmbUICultrue.Name = "cmbUICultrue";
            this.cmbUICultrue.Size = new System.Drawing.Size(100, 21);
            this.cmbUICultrue.TabIndex = 25;
            // 
            // cmbCultrue
            // 
            this.cmbCultrue.FormattingEnabled = true;
            this.cmbCultrue.Items.AddRange(new object[] {
            "zh-CN",
            "zh-HK",
            "en-US",
            "ja-JP"});
            this.cmbCultrue.Location = new System.Drawing.Point(72, 6);
            this.cmbCultrue.Name = "cmbCultrue";
            this.cmbCultrue.Size = new System.Drawing.Size(100, 21);
            this.cmbCultrue.TabIndex = 24;
            // 
            // lblUICultrue
            // 
            this.lblUICultrue.AutoSize = true;
            this.lblUICultrue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblUICultrue.Location = new System.Drawing.Point(12, 39);
            this.lblUICultrue.Name = "lblUICultrue";
            this.lblUICultrue.Size = new System.Drawing.Size(54, 13);
            this.lblUICultrue.TabIndex = 23;
            this.lblUICultrue.Text = "UICultrue:";
            // 
            // lblCultrue
            // 
            this.lblCultrue.AutoSize = true;
            this.lblCultrue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblCultrue.Location = new System.Drawing.Point(12, 9);
            this.lblCultrue.Name = "lblCultrue";
            this.lblCultrue.Size = new System.Drawing.Size(43, 13);
            this.lblCultrue.TabIndex = 22;
            this.lblCultrue.Text = "Cultrue:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(178, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = "New";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 78);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbUICultrue);
            this.Controls.Add(this.cmbCultrue);
            this.Controls.Add(this.lblUICultrue);
            this.Controls.Add(this.lblCultrue);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SelectionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbUICultrue;
        private System.Windows.Forms.ComboBox cmbCultrue;
        private System.Windows.Forms.Label lblUICultrue;
        private System.Windows.Forms.Label lblCultrue;
        private System.Windows.Forms.Button button1;
    }
}