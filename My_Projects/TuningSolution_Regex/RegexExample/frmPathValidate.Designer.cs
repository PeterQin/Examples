namespace RegexExample
{
    partial class frmValidataPath
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
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.btnValidate = new System.Windows.Forms.Button();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblMsgContain = new System.Windows.Forms.Label();
            this.rchIllagelCharacter = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(50, 6);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(291, 20);
            this.txtPath.TabIndex = 0;
            // 
            // lblPath
            // 
            this.lblPath.AutoSize = true;
            this.lblPath.Location = new System.Drawing.Point(12, 9);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(32, 13);
            this.lblPath.TabIndex = 1;
            this.lblPath.Text = "Path:";
            // 
            // btnValidate
            // 
            this.btnValidate.Location = new System.Drawing.Point(266, 32);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(75, 23);
            this.btnValidate.TabIndex = 2;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(12, 37);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(52, 13);
            this.lblMsg.TabIndex = 3;
            this.lblMsg.Text = "message:";
            // 
            // lblMsgContain
            // 
            this.lblMsgContain.AutoSize = true;
            this.lblMsgContain.Location = new System.Drawing.Point(70, 37);
            this.lblMsgContain.Name = "lblMsgContain";
            this.lblMsgContain.Size = new System.Drawing.Size(0, 13);
            this.lblMsgContain.TabIndex = 4;
            // 
            // rchIllagelCharacter
            // 
            this.rchIllagelCharacter.Location = new System.Drawing.Point(12, 98);
            this.rchIllagelCharacter.Name = "rchIllagelCharacter";
            this.rchIllagelCharacter.Size = new System.Drawing.Size(329, 91);
            this.rchIllagelCharacter.TabIndex = 5;
            this.rchIllagelCharacter.Text = "";
            // 
            // frmValidataPath
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 201);
            this.Controls.Add(this.rchIllagelCharacter);
            this.Controls.Add(this.lblMsgContain);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtPath);
            this.Name = "frmValidataPath";
            this.Text = "Path Validata";
            this.Load += new System.EventHandler(this.frmValidataPath_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblMsgContain;
        private System.Windows.Forms.RichTextBox rchIllagelCharacter;
    }
}

