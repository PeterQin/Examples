namespace CompileCondition
{
    partial class frmCondition
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCondition));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbProduct = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEdition = new System.Windows.Forms.ComboBox();
            this.grpVersion = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numMajor = new System.Windows.Forms.NumericUpDown();
            this.numMinor = new System.Windows.Forms.NumericUpDown();
            this.numRelease = new System.Windows.Forms.NumericUpDown();
            this.numBuild = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewProject = new System.Windows.Forms.DataGridView();
            this.ColProject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColCondition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuProject = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.applyToLocalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnApply = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.grpVersion.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMajor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRelease)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBuild)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProject)).BeginInit();
            this.menuProject.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbProduct, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cmbEdition, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.grpVersion, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dataGridViewProject, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnApply, 2, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(12);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(835, 563);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Product:";
            // 
            // cmbProduct
            // 
            this.cmbProduct.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProduct.FormattingEnabled = true;
            this.cmbProduct.Location = new System.Drawing.Point(68, 15);
            this.cmbProduct.Name = "cmbProduct";
            this.cmbProduct.Size = new System.Drawing.Size(225, 21);
            this.cmbProduct.TabIndex = 1;
            this.cmbProduct.SelectedIndexChanged += new System.EventHandler(this.cmbProduct_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 42);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Edition:";
            // 
            // cmbEdition
            // 
            this.cmbEdition.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbEdition.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEdition.FormattingEnabled = true;
            this.cmbEdition.Location = new System.Drawing.Point(68, 42);
            this.cmbEdition.Name = "cmbEdition";
            this.cmbEdition.Size = new System.Drawing.Size(225, 21);
            this.cmbEdition.TabIndex = 3;
            this.cmbEdition.SelectedIndexChanged += new System.EventHandler(this.cmbEdition_SelectedIndexChanged);
            // 
            // grpVersion
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.grpVersion, 2);
            this.grpVersion.Controls.Add(this.tableLayoutPanel2);
            this.grpVersion.Location = new System.Drawing.Point(15, 69);
            this.grpVersion.Name = "grpVersion";
            this.grpVersion.Size = new System.Drawing.Size(278, 77);
            this.grpVersion.TabIndex = 4;
            this.grpVersion.TabStop = false;
            this.grpVersion.Text = "Version";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.numMajor, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.numMinor, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.numRelease, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.numBuild, 3, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 34.5679F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65.4321F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(272, 58);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Major";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(68, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Minor";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(133, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Release";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Build";
            // 
            // numMajor
            // 
            this.numMajor.Location = new System.Drawing.Point(3, 23);
            this.numMajor.Name = "numMajor";
            this.numMajor.Size = new System.Drawing.Size(59, 20);
            this.numMajor.TabIndex = 4;
            this.numMajor.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMajor.ValueChanged += new System.EventHandler(this.numVersion_ValueChanged);
            // 
            // numMinor
            // 
            this.numMinor.Location = new System.Drawing.Point(68, 23);
            this.numMinor.Name = "numMinor";
            this.numMinor.Size = new System.Drawing.Size(59, 20);
            this.numMinor.TabIndex = 5;
            this.numMinor.ValueChanged += new System.EventHandler(this.numVersion_ValueChanged);
            // 
            // numRelease
            // 
            this.numRelease.Location = new System.Drawing.Point(133, 23);
            this.numRelease.Name = "numRelease";
            this.numRelease.Size = new System.Drawing.Size(59, 20);
            this.numRelease.TabIndex = 6;
            this.numRelease.ValueChanged += new System.EventHandler(this.numVersion_ValueChanged);
            // 
            // numBuild
            // 
            this.numBuild.Location = new System.Drawing.Point(198, 23);
            this.numBuild.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numBuild.Name = "numBuild";
            this.numBuild.Size = new System.Drawing.Size(59, 20);
            this.numBuild.TabIndex = 7;
            this.numBuild.ValueChanged += new System.EventHandler(this.numVersion_ValueChanged);
            // 
            // dataGridViewProject
            // 
            this.dataGridViewProject.AllowUserToOrderColumns = true;
            this.dataGridViewProject.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewProject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewProject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColProject,
            this.ColCondition});
            this.tableLayoutPanel1.SetColumnSpan(this.dataGridViewProject, 3);
            this.dataGridViewProject.ContextMenuStrip = this.menuProject;
            this.dataGridViewProject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewProject.Location = new System.Drawing.Point(15, 152);
            this.dataGridViewProject.Name = "dataGridViewProject";
            this.dataGridViewProject.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewProject.Size = new System.Drawing.Size(805, 349);
            this.dataGridViewProject.TabIndex = 5;
            // 
            // ColProject
            // 
            this.ColProject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColProject.DataPropertyName = "Name";
            this.ColProject.HeaderText = "Project";
            this.ColProject.Name = "ColProject";
            this.ColProject.ReadOnly = true;
            this.ColProject.Width = 65;
            // 
            // ColCondition
            // 
            this.ColCondition.DataPropertyName = "DisplayCondition";
            this.ColCondition.HeaderText = "Condition";
            this.ColCondition.Name = "ColCondition";
            // 
            // menuProject
            // 
            this.menuProject.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applyToLocalToolStripMenuItem});
            this.menuProject.Name = "menuProject";
            this.menuProject.Size = new System.Drawing.Size(151, 26);
            // 
            // applyToLocalToolStripMenuItem
            // 
            this.applyToLocalToolStripMenuItem.Name = "applyToLocalToolStripMenuItem";
            this.applyToLocalToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.applyToLocalToolStripMenuItem.Text = "Apply to Local";
            this.applyToLocalToolStripMenuItem.Click += new System.EventHandler(this.applyToLocalToolStripMenuItem_Click);
            // 
            // btnApply
            // 
            this.btnApply.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnApply.Image = global::CompileCondition.rcCondition.qso_saveAll;
            this.btnApply.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnApply.Location = new System.Drawing.Point(695, 513);
            this.btnApply.Margin = new System.Windows.Forms.Padding(3, 9, 3, 3);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(125, 35);
            this.btnApply.TabIndex = 6;
            this.btnApply.Text = "&Apply to Local";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // frmCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(835, 563);
            this.Controls.Add(this.tableLayoutPanel1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(600, 450);
            this.Name = "frmCondition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Compile Condition Configuration";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.grpVersion.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMajor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRelease)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBuild)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewProject)).EndInit();
            this.menuProject.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbProduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEdition;
        private System.Windows.Forms.GroupBox grpVersion;
        private System.Windows.Forms.DataGridView dataGridViewProject;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numMajor;
        private System.Windows.Forms.NumericUpDown numMinor;
        private System.Windows.Forms.NumericUpDown numRelease;
        private System.Windows.Forms.NumericUpDown numBuild;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProject;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCondition;
        private System.Windows.Forms.ContextMenuStrip menuProject;
        private System.Windows.Forms.ToolStripMenuItem applyToLocalToolStripMenuItem;
    }
}

