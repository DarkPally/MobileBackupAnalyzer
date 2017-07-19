namespace MobileBackup.Demo.WinForm
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_config_addr = new System.Windows.Forms.TextBox();
            this.button_config_addr = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_backup_addr = new System.Windows.Forms.TextBox();
            this.button_backup_addr = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_output_addr = new System.Windows.Forms.TextBox();
            this.button_output_addr = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label_msg = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "手机厂商:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "魅族",
            "OPPO",
            "VIVO",
            "小米",
            "中兴"});
            this.comboBox1.Location = new System.Drawing.Point(139, 28);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(183, 20);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "配置文件地址:";
            // 
            // textBox_config_addr
            // 
            this.textBox_config_addr.Location = new System.Drawing.Point(139, 64);
            this.textBox_config_addr.Name = "textBox_config_addr";
            this.textBox_config_addr.Size = new System.Drawing.Size(302, 21);
            this.textBox_config_addr.TabIndex = 3;
            // 
            // button_config_addr
            // 
            this.button_config_addr.Location = new System.Drawing.Point(461, 63);
            this.button_config_addr.Name = "button_config_addr";
            this.button_config_addr.Size = new System.Drawing.Size(75, 23);
            this.button_config_addr.TabIndex = 4;
            this.button_config_addr.Text = "浏览...";
            this.button_config_addr.UseVisualStyleBackColor = true;
            this.button_config_addr.Click += new System.EventHandler(this.button_config_addr_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "备份文件目录:";
            // 
            // textBox_backup_addr
            // 
            this.textBox_backup_addr.Location = new System.Drawing.Point(139, 101);
            this.textBox_backup_addr.Name = "textBox_backup_addr";
            this.textBox_backup_addr.Size = new System.Drawing.Size(302, 21);
            this.textBox_backup_addr.TabIndex = 3;
            // 
            // button_backup_addr
            // 
            this.button_backup_addr.Location = new System.Drawing.Point(461, 100);
            this.button_backup_addr.Name = "button_backup_addr";
            this.button_backup_addr.Size = new System.Drawing.Size(75, 23);
            this.button_backup_addr.TabIndex = 4;
            this.button_backup_addr.Text = "浏览...";
            this.button_backup_addr.UseVisualStyleBackColor = true;
            this.button_backup_addr.Click += new System.EventHandler(this.button_backup_addr_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(50, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "文件输出目录:";
            // 
            // textBox_output_addr
            // 
            this.textBox_output_addr.Location = new System.Drawing.Point(139, 138);
            this.textBox_output_addr.Name = "textBox_output_addr";
            this.textBox_output_addr.Size = new System.Drawing.Size(302, 21);
            this.textBox_output_addr.TabIndex = 3;
            // 
            // button_output_addr
            // 
            this.button_output_addr.Location = new System.Drawing.Point(461, 137);
            this.button_output_addr.Name = "button_output_addr";
            this.button_output_addr.Size = new System.Drawing.Size(75, 23);
            this.button_output_addr.TabIndex = 4;
            this.button_output_addr.Text = "浏览...";
            this.button_output_addr.UseVisualStyleBackColor = true;
            this.button_output_addr.Click += new System.EventHandler(this.button_output_addr_Click);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(9, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(550, 2);
            this.label5.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 274);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(239, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "开始还原备份";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_msg
            // 
            this.label_msg.AutoSize = true;
            this.label_msg.Location = new System.Drawing.Point(50, 245);
            this.label_msg.Name = "label_msg";
            this.label_msg.Size = new System.Drawing.Size(65, 12);
            this.label_msg.TabIndex = 7;
            this.label_msg.Text = "等待命令中";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(52, 201);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(507, 23);
            this.progressBar1.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(320, 274);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(239, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "取消任务";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 315);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label_msg);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button_output_addr);
            this.Controls.Add(this.button_backup_addr);
            this.Controls.Add(this.button_config_addr);
            this.Controls.Add(this.textBox_output_addr);
            this.Controls.Add(this.textBox_backup_addr);
            this.Controls.Add(this.textBox_config_addr);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_config_addr;
        private System.Windows.Forms.Button button_config_addr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_backup_addr;
        private System.Windows.Forms.Button button_backup_addr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_output_addr;
        private System.Windows.Forms.Button button_output_addr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_msg;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button2;
    }
}

