namespace MutiThreadRWDatabase
{
    partial class frmMutiThreadOnDB
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnWrite = new System.Windows.Forms.Button();
            this.btnRead = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnWDThread = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnReadThread = new System.Windows.Forms.Button();
            this.btnStopWD = new System.Windows.Forms.Button();
            this.btnStopRead = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDelThread = new System.Windows.Forms.Button();
            this.btnWriteThread = new System.Windows.Forms.Button();
            this.btnStopUpdate = new System.Windows.Forms.Button();
            this.btnUpdateThread = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnStopWrite = new System.Windows.Forms.Button();
            this.btnStopDel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnWrite
            // 
            this.btnWrite.Location = new System.Drawing.Point(23, 20);
            this.btnWrite.Name = "btnWrite";
            this.btnWrite.Size = new System.Drawing.Size(75, 23);
            this.btnWrite.TabIndex = 0;
            this.btnWrite.Text = "Add";
            this.btnWrite.UseVisualStyleBackColor = true;
            this.btnWrite.Click += new System.EventHandler(this.btnWrite_Click);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(266, 20);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(84, 23);
            this.btnRead.TabIndex = 1;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnRead_Click);
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(104, 20);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(75, 23);
            this.btnDel.TabIndex = 4;
            this.btnDel.Text = "Del";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnWDThread
            // 
            this.btnWDThread.Location = new System.Drawing.Point(23, 214);
            this.btnWDThread.Name = "btnWDThread";
            this.btnWDThread.Size = new System.Drawing.Size(237, 23);
            this.btnWDThread.TabIndex = 5;
            this.btnWDThread.Text = "Start write and then delete thread";
            this.btnWDThread.UseVisualStyleBackColor = true;
            this.btnWDThread.Click += new System.EventHandler(this.btnWDThread_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(56, 258);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 6;
            this.textBox3.Text = "100";
            // 
            // btnReadThread
            // 
            this.btnReadThread.Location = new System.Drawing.Point(23, 175);
            this.btnReadThread.Name = "btnReadThread";
            this.btnReadThread.Size = new System.Drawing.Size(237, 23);
            this.btnReadThread.TabIndex = 7;
            this.btnReadThread.Text = "Start read thread";
            this.btnReadThread.UseVisualStyleBackColor = true;
            this.btnReadThread.Click += new System.EventHandler(this.btnReadThread_Click);
            // 
            // btnStopWD
            // 
            this.btnStopWD.Location = new System.Drawing.Point(266, 214);
            this.btnStopWD.Name = "btnStopWD";
            this.btnStopWD.Size = new System.Drawing.Size(84, 23);
            this.btnStopWD.TabIndex = 8;
            this.btnStopWD.Text = "W D stop";
            this.btnStopWD.UseVisualStyleBackColor = true;
            this.btnStopWD.Click += new System.EventHandler(this.btnStopWD_Click);
            // 
            // btnStopRead
            // 
            this.btnStopRead.Location = new System.Drawing.Point(266, 175);
            this.btnStopRead.Name = "btnStopRead";
            this.btnStopRead.Size = new System.Drawing.Size(84, 23);
            this.btnStopRead.TabIndex = 9;
            this.btnStopRead.Text = "Read stop";
            this.btnStopRead.UseVisualStyleBackColor = true;
            this.btnStopRead.Click += new System.EventHandler(this.btnStopRead_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(185, 20);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(6, 291);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(0);
            this.groupBox1.Size = new System.Drawing.Size(394, 53);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Result";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(0, 14);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(394, 39);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnStopDel);
            this.groupBox2.Controls.Add(this.btnStopWrite);
            this.groupBox2.Controls.Add(this.btnDelThread);
            this.groupBox2.Controls.Add(this.btnWriteThread);
            this.groupBox2.Controls.Add(this.btnStopUpdate);
            this.groupBox2.Controls.Add(this.btnUpdateThread);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnWrite);
            this.groupBox2.Controls.Add(this.textBox3);
            this.groupBox2.Controls.Add(this.btnStopWD);
            this.groupBox2.Controls.Add(this.btnStopRead);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.btnDel);
            this.groupBox2.Controls.Add(this.btnRead);
            this.groupBox2.Controls.Add(this.btnReadThread);
            this.groupBox2.Controls.Add(this.btnWDThread);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(394, 285);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Action";
            // 
            // btnDelThread
            // 
            this.btnDelThread.Location = new System.Drawing.Point(23, 98);
            this.btnDelThread.Name = "btnDelThread";
            this.btnDelThread.Size = new System.Drawing.Size(235, 23);
            this.btnDelThread.TabIndex = 17;
            this.btnDelThread.Text = "Start del thread";
            this.btnDelThread.UseVisualStyleBackColor = true;
            this.btnDelThread.Click += new System.EventHandler(this.btnDelThread_Click);
            // 
            // btnWriteThread
            // 
            this.btnWriteThread.Location = new System.Drawing.Point(23, 60);
            this.btnWriteThread.Name = "btnWriteThread";
            this.btnWriteThread.Size = new System.Drawing.Size(237, 23);
            this.btnWriteThread.TabIndex = 16;
            this.btnWriteThread.Text = "Start write thread";
            this.btnWriteThread.UseVisualStyleBackColor = true;
            this.btnWriteThread.Click += new System.EventHandler(this.btnWriteThread_Click);
            // 
            // btnStopUpdate
            // 
            this.btnStopUpdate.Location = new System.Drawing.Point(266, 136);
            this.btnStopUpdate.Name = "btnStopUpdate";
            this.btnStopUpdate.Size = new System.Drawing.Size(85, 23);
            this.btnStopUpdate.TabIndex = 15;
            this.btnStopUpdate.Text = "Update stop";
            this.btnStopUpdate.UseVisualStyleBackColor = true;
            this.btnStopUpdate.Click += new System.EventHandler(this.btnStopUpdate_Click);
            // 
            // btnUpdateThread
            // 
            this.btnUpdateThread.Location = new System.Drawing.Point(23, 136);
            this.btnUpdateThread.Name = "btnUpdateThread";
            this.btnUpdateThread.Size = new System.Drawing.Size(237, 23);
            this.btnUpdateThread.TabIndex = 14;
            this.btnUpdateThread.Text = "Start update thread";
            this.btnUpdateThread.UseVisualStyleBackColor = true;
            this.btnUpdateThread.Click += new System.EventHandler(this.btnUpdateThread_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 261);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 13;
            this.label2.Text = "data:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(251, 258);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 12;
            this.textBox1.Text = "data100-Updated";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 261);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "ID:";
            // 
            // btnStopWrite
            // 
            this.btnStopWrite.Location = new System.Drawing.Point(266, 60);
            this.btnStopWrite.Name = "btnStopWrite";
            this.btnStopWrite.Size = new System.Drawing.Size(85, 23);
            this.btnStopWrite.TabIndex = 18;
            this.btnStopWrite.Text = "Write stop";
            this.btnStopWrite.UseVisualStyleBackColor = true;
            this.btnStopWrite.Click += new System.EventHandler(this.btnStopWrite_Click);
            // 
            // btnStopDel
            // 
            this.btnStopDel.Location = new System.Drawing.Point(266, 98);
            this.btnStopDel.Name = "btnStopDel";
            this.btnStopDel.Size = new System.Drawing.Size(85, 23);
            this.btnStopDel.TabIndex = 19;
            this.btnStopDel.Text = "Del stop";
            this.btnStopDel.UseVisualStyleBackColor = true;
            this.btnStopDel.Click += new System.EventHandler(this.btnStopDel_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 350);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Text = "Test Muti-Thread on DB";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWrite;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnWDThread;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnReadThread;
        private System.Windows.Forms.Button btnStopWD;
        private System.Windows.Forms.Button btnStopRead;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnStopUpdate;
        private System.Windows.Forms.Button btnUpdateThread;
        private System.Windows.Forms.Button btnWriteThread;
        private System.Windows.Forms.Button btnDelThread;
        private System.Windows.Forms.Button btnStopWrite;
        private System.Windows.Forms.Button btnStopDel;
    }
}

