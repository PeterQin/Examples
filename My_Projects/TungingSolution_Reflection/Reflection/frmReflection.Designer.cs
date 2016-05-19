namespace Reflection
{
    partial class frmReflection
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
            this.btnOk = new System.Windows.Forms.Button();
            this.rchMsg = new System.Windows.Forms.RichTextBox();
            this.cmbClass = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(188, 114);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // rchMsg
            // 
            this.rchMsg.Location = new System.Drawing.Point(12, 12);
            this.rchMsg.Name = "rchMsg";
            this.rchMsg.Size = new System.Drawing.Size(252, 96);
            this.rchMsg.TabIndex = 1;
            this.rchMsg.Text = "";
            // 
            // cmbClass
            // 
            this.cmbClass.FormattingEnabled = true;
            this.cmbClass.Items.AddRange(new object[] {
            "TDatabase",
            "MyClass"});
            this.cmbClass.Location = new System.Drawing.Point(12, 116);
            this.cmbClass.Name = "cmbClass";
            this.cmbClass.Size = new System.Drawing.Size(121, 21);
            this.cmbClass.TabIndex = 2;
            // 
            // frmReflection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 149);
            this.Controls.Add(this.cmbClass);
            this.Controls.Add(this.rchMsg);
            this.Controls.Add(this.btnOk);
            this.Name = "frmReflection";
            this.Text = "Reflection";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.RichTextBox rchMsg;
        private System.Windows.Forms.ComboBox cmbClass;
    }
}

