namespace FindRefAssembly
{
    partial class frmRefAssembly
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRefAssembly));
            this.txtProjectFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.rchMsg = new System.Windows.Forms.RichTextBox();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtInstallFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKeyWord = new System.Windows.Forms.TextBox();
            this.btnProj = new System.Windows.Forms.Button();
            this.btnInstallFolder = new System.Windows.Forms.Button();
            this.btnCopyFolder = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnClear = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtProjectFolder
            // 
            this.txtProjectFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtProjectFolder.Location = new System.Drawing.Point(125, 35);
            this.txtProjectFolder.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.txtProjectFolder.Name = "txtProjectFolder";
            this.txtProjectFolder.Size = new System.Drawing.Size(450, 20);
            this.txtProjectFolder.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(3, 29);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Project Folder:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDestination
            // 
            this.txtDestination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDestination.Location = new System.Drawing.Point(125, 394);
            this.txtDestination.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(450, 20);
            this.txtDestination.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(3, 388);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 26);
            this.label2.TabIndex = 3;
            this.label2.Text = "Copy Assembly To:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnSearch
            // 
            this.btnSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSearch.Location = new System.Drawing.Point(3, 3);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(94, 36);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "&Start Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // rchMsg
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.rchMsg, 3);
            this.rchMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchMsg.Location = new System.Drawing.Point(3, 121);
            this.rchMsg.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.rchMsg.Name = "rchMsg";
            this.rchMsg.Size = new System.Drawing.Size(605, 229);
            this.rchMsg.TabIndex = 6;
            this.rchMsg.Text = "";
            // 
            // btnCopy
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnCopy, 2);
            this.btnCopy.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCopy.Location = new System.Drawing.Point(491, 426);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(117, 36);
            this.btnCopy.TabIndex = 7;
            this.btnCopy.Text = "&Copy Assembly File";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtInstallFolder
            // 
            this.txtInstallFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtInstallFolder.Location = new System.Drawing.Point(125, 362);
            this.txtInstallFolder.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.txtInstallFolder.Name = "txtInstallFolder";
            this.txtInstallFolder.Size = new System.Drawing.Size(450, 20);
            this.txtInstallFolder.TabIndex = 8;
            this.txtInstallFolder.Text = "C:\\Program Files (x86)\\DevExpress 13.2\\Components\\Bin\\Framework";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(3, 356);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 26);
            this.label3.TabIndex = 10;
            this.label3.Text = "Assembly Install Folder:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnCopy, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtKeyWord, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtInstallFolder, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtDestination, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtProjectFolder, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.rchMsg, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnProj, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnInstallFolder, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCopyFolder, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(33, 33);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(611, 465);
            this.tableLayoutPanel1.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 0;
            this.label5.Text = "Key Word to Search:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtKeyWord
            // 
            this.txtKeyWord.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel1.SetColumnSpan(this.txtKeyWord, 2);
            this.txtKeyWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtKeyWord.Location = new System.Drawing.Point(125, 3);
            this.txtKeyWord.Name = "txtKeyWord";
            this.txtKeyWord.Size = new System.Drawing.Size(483, 20);
            this.txtKeyWord.TabIndex = 1;
            this.txtKeyWord.Text = "DevExpress";
            // 
            // btnProj
            // 
            this.btnProj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProj.Location = new System.Drawing.Point(581, 32);
            this.btnProj.Name = "btnProj";
            this.btnProj.Size = new System.Drawing.Size(27, 23);
            this.btnProj.TabIndex = 11;
            this.btnProj.Text = "...";
            this.btnProj.UseVisualStyleBackColor = true;
            this.btnProj.Click += new System.EventHandler(this.btnProj_Click);
            // 
            // btnInstallFolder
            // 
            this.btnInstallFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInstallFolder.Location = new System.Drawing.Point(581, 359);
            this.btnInstallFolder.Name = "btnInstallFolder";
            this.btnInstallFolder.Size = new System.Drawing.Size(27, 23);
            this.btnInstallFolder.TabIndex = 12;
            this.btnInstallFolder.Text = "...";
            this.btnInstallFolder.UseVisualStyleBackColor = true;
            this.btnInstallFolder.Click += new System.EventHandler(this.btnInstallFolder_Click);
            // 
            // btnCopyFolder
            // 
            this.btnCopyFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyFolder.Location = new System.Drawing.Point(581, 391);
            this.btnCopyFolder.Name = "btnCopyFolder";
            this.btnCopyFolder.Size = new System.Drawing.Size(27, 23);
            this.btnCopyFolder.TabIndex = 13;
            this.btnCopyFolder.Text = "...";
            this.btnCopyFolder.UseVisualStyleBackColor = true;
            this.btnCopyFolder.Click += new System.EventHandler(this.btnCopyFolder_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 2);
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnSearch, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnClear, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(408, 67);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 42);
            this.tableLayoutPanel2.TabIndex = 14;
            // 
            // btnClear
            // 
            this.btnClear.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClear.Location = new System.Drawing.Point(122, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 36);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmRefAssembly
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(677, 531);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRefAssembly";
            this.Padding = new System.Windows.Forms.Padding(33);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find Reference Assembly";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtProjectFolder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.RichTextBox rchMsg;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox txtInstallFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKeyWord;
        private System.Windows.Forms.Button btnProj;
        private System.Windows.Forms.Button btnInstallFolder;
        private System.Windows.Forms.Button btnCopyFolder;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnClear;
    }
}

