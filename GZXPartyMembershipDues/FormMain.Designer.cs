namespace GZXPartyMembershipDues
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.数据入库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清理数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清理应缴数据表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.清理已缴在职数据表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.在职ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退休数据表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据入库ToolStripMenuItem,
            this.清理数据ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(425, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 数据入库ToolStripMenuItem
            // 
            this.数据入库ToolStripMenuItem.Name = "数据入库ToolStripMenuItem";
            this.数据入库ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.数据入库ToolStripMenuItem.Text = "数据入库";
            this.数据入库ToolStripMenuItem.Click += new System.EventHandler(this.数据入库ToolStripMenuItem_Click);
            // 
            // 清理数据ToolStripMenuItem
            // 
            this.清理数据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.清理应缴数据表ToolStripMenuItem,
            this.清理已缴在职数据表ToolStripMenuItem});
            this.清理数据ToolStripMenuItem.Name = "清理数据ToolStripMenuItem";
            this.清理数据ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.清理数据ToolStripMenuItem.Text = "清理数据";
            // 
            // 清理应缴数据表ToolStripMenuItem
            // 
            this.清理应缴数据表ToolStripMenuItem.Name = "清理应缴数据表ToolStripMenuItem";
            this.清理应缴数据表ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.清理应缴数据表ToolStripMenuItem.Text = "清理应缴数据表";
            this.清理应缴数据表ToolStripMenuItem.Click += new System.EventHandler(this.清理应缴数据表ToolStripMenuItem_Click);
            // 
            // 清理已缴在职数据表ToolStripMenuItem
            // 
            this.清理已缴在职数据表ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.在职ToolStripMenuItem,
            this.退休数据表ToolStripMenuItem});
            this.清理已缴在职数据表ToolStripMenuItem.Name = "清理已缴在职数据表ToolStripMenuItem";
            this.清理已缴在职数据表ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.清理已缴在职数据表ToolStripMenuItem.Text = "清理已缴数据表";
            // 
            // 在职ToolStripMenuItem
            // 
            this.在职ToolStripMenuItem.Name = "在职ToolStripMenuItem";
            this.在职ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.在职ToolStripMenuItem.Text = "在职数据表";
            this.在职ToolStripMenuItem.Click += new System.EventHandler(this.在职ToolStripMenuItem_Click);
            // 
            // 退休数据表ToolStripMenuItem
            // 
            this.退休数据表ToolStripMenuItem.Name = "退休数据表ToolStripMenuItem";
            this.退休数据表ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.退休数据表ToolStripMenuItem.Text = "退休数据表";
            this.退休数据表ToolStripMenuItem.Click += new System.EventHandler(this.退休数据表ToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "导出结果存储位置";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 28);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(413, 89);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "计算在职人员补缴额";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(113, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(250, 21);
            this.textBox1.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(369, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "…";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(113, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "开始计算";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(425, 326);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "国职校党费管理";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 数据入库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清理数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清理应缴数据表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 清理已缴在职数据表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 在职ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退休数据表ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
    }
}