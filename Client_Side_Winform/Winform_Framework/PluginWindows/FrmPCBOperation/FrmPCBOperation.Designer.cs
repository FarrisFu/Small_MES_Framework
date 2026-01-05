namespace FrmPCBOperation
{
    partial class FrmPCBOperation
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
            this.label3 = new AntdUI.Label();
            this.input1 = new AntdUI.Input();
            this.lbTitle = new AntdUI.Label();
            this.panel2 = new AntdUI.Panel();
            this.label2 = new AntdUI.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new AntdUI.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.panel1.BorderWidth = 2F;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.input1);
            this.panel1.Controls.Add(this.lbTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(16, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(928, 150);
            this.panel1.TabIndex = 0;
            this.panel1.Text = "panel1";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(645, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "SN:";
            // 
            // input1
            // 
            this.input1.Location = new System.Drawing.Point(705, 76);
            this.input1.Name = "input1";
            this.input1.Size = new System.Drawing.Size(200, 45);
            this.input1.TabIndex = 2;
            this.input1.Text = "input1";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSizeMode = AntdUI.TAutoSize.Auto;
            this.lbTitle.Font = new System.Drawing.Font("微软雅黑", 16F);
            this.lbTitle.Location = new System.Drawing.Point(14, 14);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(107, 29);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "操作工序：";
            // 
            // panel2
            // 
            this.panel2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.panel2.BorderWidth = 2F;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(16, 182);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(928, 358);
            this.panel2.TabIndex = 1;
            this.panel2.Text = "panel2";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "操作记录：";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox1.Location = new System.Drawing.Point(2, 57);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(924, 299);
            this.textBox1.TabIndex = 0;
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
            // FrmPCBOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmPCBOperation";
            this.Padding = new System.Windows.Forms.Padding(16, 16, 16, 0);
            this.Text = "FrmPCBOperation";
            this.Load += new System.EventHandler(this.FrmPCBOperation_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.Panel panel2;
        private AntdUI.Label lbTitle;
        private AntdUI.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private AntdUI.Label label3;
        private AntdUI.Input input1;
        private AntdUI.Panel panel3;
    }
}