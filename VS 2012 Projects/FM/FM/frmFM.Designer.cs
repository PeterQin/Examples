namespace FM
{
    partial class frmFM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFM));
            this.webBrowserFM = new System.Windows.Forms.WebBrowser();
            this.panelFM = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelHeader = new System.Windows.Forms.TableLayoutPanel();
            this.labelFM = new System.Windows.Forms.Label();
            this.labelClose = new System.Windows.Forms.Label();
            this.labelMini = new System.Windows.Forms.Label();
            this.panelFM.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowserFM
            // 
            this.webBrowserFM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserFM.Location = new System.Drawing.Point(6, 36);
            this.webBrowserFM.Margin = new System.Windows.Forms.Padding(6, 0, 6, 6);
            this.webBrowserFM.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserFM.Name = "webBrowserFM";
            this.webBrowserFM.Size = new System.Drawing.Size(420, 168);
            this.webBrowserFM.TabIndex = 0;
            // 
            // panelFM
            // 
            this.panelFM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(63)))), ((int)(((byte)(65)))), ((int)(((byte)(62)))));
            this.panelFM.Controls.Add(this.tableLayoutPanel1);
            this.panelFM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFM.Location = new System.Drawing.Point(0, 0);
            this.panelFM.Name = "panelFM";
            this.panelFM.Size = new System.Drawing.Size(432, 210);
            this.panelFM.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.webBrowserFM, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelHeader, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(432, 210);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanelHeader
            // 
            this.tableLayoutPanelHeader.AutoSize = true;
            this.tableLayoutPanelHeader.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelHeader.ColumnCount = 4;
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelHeader.Controls.Add(this.labelFM, 0, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.labelClose, 3, 0);
            this.tableLayoutPanelHeader.Controls.Add(this.labelMini, 2, 0);
            this.tableLayoutPanelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelHeader.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelHeader.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelHeader.Name = "tableLayoutPanelHeader";
            this.tableLayoutPanelHeader.RowCount = 1;
            this.tableLayoutPanelHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelHeader.Size = new System.Drawing.Size(432, 36);
            this.tableLayoutPanelHeader.TabIndex = 2;
            this.tableLayoutPanelHeader.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tableLayoutPanelHeader_MouseDown);
            // 
            // labelFM
            // 
            this.labelFM.AutoSize = true;
            this.labelFM.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.labelFM.Location = new System.Drawing.Point(3, 6);
            this.labelFM.Margin = new System.Windows.Forms.Padding(3, 6, 6, 6);
            this.labelFM.Name = "labelFM";
            this.labelFM.Size = new System.Drawing.Size(38, 24);
            this.labelFM.TabIndex = 1;
            this.labelFM.Text = "FM";
            // 
            // labelClose
            // 
            this.labelClose.AutoSize = true;
            this.labelClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelClose.ForeColor = System.Drawing.Color.Gray;
            this.labelClose.Location = new System.Drawing.Point(406, 3);
            this.labelClose.Margin = new System.Windows.Forms.Padding(3);
            this.labelClose.Name = "labelClose";
            this.labelClose.Padding = new System.Windows.Forms.Padding(1, 3, 1, 0);
            this.labelClose.Size = new System.Drawing.Size(23, 23);
            this.labelClose.TabIndex = 2;
            this.labelClose.Text = "X";
            this.labelClose.Click += new System.EventHandler(this.labelClose_Click);
            this.labelClose.MouseEnter += new System.EventHandler(this.TiltleControlLabel_MouseEnter);
            this.labelClose.MouseLeave += new System.EventHandler(this.TitleControlLabel_MouseLeave);
            // 
            // labelMini
            // 
            this.labelMini.AutoSize = true;
            this.labelMini.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMini.ForeColor = System.Drawing.Color.Gray;
            this.labelMini.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelMini.Location = new System.Drawing.Point(379, 3);
            this.labelMini.Margin = new System.Windows.Forms.Padding(3);
            this.labelMini.Name = "labelMini";
            this.labelMini.Padding = new System.Windows.Forms.Padding(1, 0, 1, 3);
            this.labelMini.Size = new System.Drawing.Size(21, 23);
            this.labelMini.TabIndex = 3;
            this.labelMini.Text = "_";
            this.labelMini.Click += new System.EventHandler(this.labelMini_Click);
            this.labelMini.MouseEnter += new System.EventHandler(this.TiltleControlLabel_MouseEnter);
            this.labelMini.MouseLeave += new System.EventHandler(this.TitleControlLabel_MouseLeave);
            // 
            // frmFM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 210);
            this.Controls.Add(this.panelFM);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmFM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FM";
            this.Load += new System.EventHandler(this.frmFM_Load);
            this.panelFM.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanelHeader.ResumeLayout(false);
            this.tableLayoutPanelHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowserFM;
        private System.Windows.Forms.Panel panelFM;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelHeader;
        private System.Windows.Forms.Label labelFM;
        private System.Windows.Forms.Label labelClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelMini;
    }
}

