namespace FrmOperationLogView
{
    partial class FrmOperationLogView
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
            this.panel1 = new AntdUI.Panel();
            this.label2 = new AntdUI.Label();
            this.label1 = new AntdUI.Label();
            this.input1 = new AntdUI.Input();
            this.panel2 = new AntdUI.Panel();
            this.tabOperationLog = new AntdUI.Table();
            this.panel3 = new AntdUI.Panel();
            this.button1 = new AntdUI.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.panel1.BorderWidth = 2F;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.input1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(16, 16);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(928, 150);
            this.panel1.TabIndex = 0;
            this.panel1.Text = "panel1";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label2.Location = new System.Drawing.Point(640, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "SN:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "操作记录查询";
            // 
            // input1
            // 
            this.input1.Location = new System.Drawing.Point(700, 49);
            this.input1.Name = "input1";
            this.input1.Size = new System.Drawing.Size(200, 45);
            this.input1.TabIndex = 0;
            this.input1.Text = "input1";
            // 
            // panel2
            // 
            this.panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.panel2.BorderWidth = 2F;
            this.panel2.Controls.Add(this.tabOperationLog);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(16, 182);
            this.panel2.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(928, 354);
            this.panel2.TabIndex = 1;
            this.panel2.Text = "panel2";
            // 
            // tabOperationLog
            // 
            this.tabOperationLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabOperationLog.Gap = 12;
            this.tabOperationLog.Location = new System.Drawing.Point(2, 2);
            this.tabOperationLog.Name = "tabOperationLog";
            this.tabOperationLog.Size = new System.Drawing.Size(924, 350);
            this.tabOperationLog.TabIndex = 0;
            this.tabOperationLog.Text = "table1";
            // 
            // panel3
            // 
            this.panel3.Back = System.Drawing.SystemColors.Control;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(16, 166);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(928, 16);
            this.panel3.TabIndex = 2;
            this.panel3.Text = "panel3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "测试查询所有";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FrmOperationLogView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 536);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmOperationLogView";
            this.Padding = new System.Windows.Forms.Padding(16, 16, 16, 0);
            this.Text = "FrmOperationLogView";
            this.Load += new System.EventHandler(this.FrmOperationLogView_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.Panel panel2;
        private AntdUI.Input input1;
        private AntdUI.Label label1;
        private AntdUI.Label label2;
        private AntdUI.Panel panel3;
        private AntdUI.Table tabOperationLog;
        private AntdUI.Button button1;
    }
}