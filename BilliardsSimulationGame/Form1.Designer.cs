namespace WindowsFormsApplication1
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.hScrollBar2 = new System.Windows.Forms.HScrollBar();
            this.button3 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.說明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.規則ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.作者ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.重新開始ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.載入預設球局ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.載入球局ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.編輯ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新球局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.載入球局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.載入預設球局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.儲存球局ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.button4 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "label4";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 27);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(508, 254);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(5, 86);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // hScrollBar2
            // 
            this.hScrollBar2.Location = new System.Drawing.Point(3, 60);
            this.hScrollBar2.Name = "hScrollBar2";
            this.hScrollBar2.Size = new System.Drawing.Size(270, 17);
            this.hScrollBar2.TabIndex = 9;
            this.hScrollBar2.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar2_Scroll);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(5, 93);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.hScrollBar2);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 297);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(285, 123);
            this.panel1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "label5";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 12);
            this.label6.TabIndex = 13;
            this.label6.Text = "label6";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "label7";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(431, 297);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(89, 123);
            this.panel2.TabIndex = 17;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.說明ToolStripMenuItem,
            this.開始ToolStripMenuItem,
            this.編輯ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(536, 24);
            this.menuStrip1.TabIndex = 20;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 說明ToolStripMenuItem
            // 
            this.說明ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作ToolStripMenuItem,
            this.規則ToolStripMenuItem,
            this.作者ToolStripMenuItem});
            this.說明ToolStripMenuItem.Name = "說明ToolStripMenuItem";
            this.說明ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.說明ToolStripMenuItem.Text = "說明";
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.操作ToolStripMenuItem.Text = "操作";
            this.操作ToolStripMenuItem.Click += new System.EventHandler(this.操作ToolStripMenuItem_Click);
            // 
            // 規則ToolStripMenuItem
            // 
            this.規則ToolStripMenuItem.Name = "規則ToolStripMenuItem";
            this.規則ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.規則ToolStripMenuItem.Text = "規則";
            this.規則ToolStripMenuItem.Click += new System.EventHandler(this.規則ToolStripMenuItem_Click);
            // 
            // 作者ToolStripMenuItem
            // 
            this.作者ToolStripMenuItem.Name = "作者ToolStripMenuItem";
            this.作者ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.作者ToolStripMenuItem.Text = "作者";
            this.作者ToolStripMenuItem.Click += new System.EventHandler(this.作者ToolStripMenuItem_Click);
            // 
            // 開始ToolStripMenuItem
            // 
            this.開始ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重新開始ToolStripMenuItem1,
            this.載入預設球局ToolStripMenuItem1,
            this.載入球局ToolStripMenuItem1});
            this.開始ToolStripMenuItem.Name = "開始ToolStripMenuItem";
            this.開始ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.開始ToolStripMenuItem.Text = "開始";
            // 
            // 重新開始ToolStripMenuItem1
            // 
            this.重新開始ToolStripMenuItem1.Name = "重新開始ToolStripMenuItem1";
            this.重新開始ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.重新開始ToolStripMenuItem1.Text = "重新開始";
            this.重新開始ToolStripMenuItem1.Click += new System.EventHandler(this.重新開始ToolStripMenuItem1_Click);
            // 
            // 載入預設球局ToolStripMenuItem1
            // 
            this.載入預設球局ToolStripMenuItem1.Name = "載入預設球局ToolStripMenuItem1";
            this.載入預設球局ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.載入預設球局ToolStripMenuItem1.Text = "載入預設球局";
            this.載入預設球局ToolStripMenuItem1.Click += new System.EventHandler(this.載入預設球局ToolStripMenuItem1_Click);
            // 
            // 載入球局ToolStripMenuItem1
            // 
            this.載入球局ToolStripMenuItem1.Name = "載入球局ToolStripMenuItem1";
            this.載入球局ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
            this.載入球局ToolStripMenuItem1.Text = "載入球局";
            this.載入球局ToolStripMenuItem1.Click += new System.EventHandler(this.載入球局ToolStripMenuItem1_Click);
            // 
            // 編輯ToolStripMenuItem
            // 
            this.編輯ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新球局ToolStripMenuItem,
            this.載入球局ToolStripMenuItem,
            this.載入預設球局ToolStripMenuItem,
            this.儲存球局ToolStripMenuItem});
            this.編輯ToolStripMenuItem.Name = "編輯ToolStripMenuItem";
            this.編輯ToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.編輯ToolStripMenuItem.Text = "編輯";
            // 
            // 新球局ToolStripMenuItem
            // 
            this.新球局ToolStripMenuItem.Name = "新球局ToolStripMenuItem";
            this.新球局ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.新球局ToolStripMenuItem.Text = "新球局";
            this.新球局ToolStripMenuItem.Click += new System.EventHandler(this.新球局ToolStripMenuItem_Click);
            // 
            // 載入球局ToolStripMenuItem
            // 
            this.載入球局ToolStripMenuItem.Name = "載入球局ToolStripMenuItem";
            this.載入球局ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.載入球局ToolStripMenuItem.Text = "載入球局";
            this.載入球局ToolStripMenuItem.Click += new System.EventHandler(this.載入球局ToolStripMenuItem_Click);
            // 
            // 載入預設球局ToolStripMenuItem
            // 
            this.載入預設球局ToolStripMenuItem.Name = "載入預設球局ToolStripMenuItem";
            this.載入預設球局ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.載入預設球局ToolStripMenuItem.Text = "載入預設球局";
            this.載入預設球局ToolStripMenuItem.Click += new System.EventHandler(this.載入預設球局ToolStripMenuItem_Click);
            // 
            // 儲存球局ToolStripMenuItem
            // 
            this.儲存球局ToolStripMenuItem.Name = "儲存球局ToolStripMenuItem";
            this.儲存球局ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.儲存球局ToolStripMenuItem.Text = "儲存球局";
            this.儲存球局ToolStripMenuItem.Click += new System.EventHandler(this.儲存球局ToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 432);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(536, 22);
            this.statusStrip1.TabIndex = 21;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(32, 17);
            this.toolStripStatusLabel1.Text = "開始";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 103);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 22;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Location = new System.Drawing.Point(3, 287);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(521, 133);
            this.panel3.TabIndex = 23;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(188, 103);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 24;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(97, 103);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 23;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 454);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.HScrollBar hScrollBar2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 說明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 規則ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 作者ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 重新開始ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 編輯ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新球局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 載入球局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 儲存球局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 載入預設球局ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 載入預設球局ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 載入球局ToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

