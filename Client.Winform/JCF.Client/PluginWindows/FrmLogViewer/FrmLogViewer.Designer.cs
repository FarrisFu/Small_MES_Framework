namespace FrmLogViewer
{
    partial class FrmLogViewer
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
            this.btnOK = new AntdUI.Button();
            this.datePickerRange1 = new AntdUI.DatePickerRange();
            this.txtSearchKey = new AntdUI.Input();
            this.panel2 = new AntdUI.Panel();
            this.panel3 = new AntdUI.Panel();
            this.tabLogs = new AntdUI.Table();
            this.panel4 = new AntdUI.Panel();
            this.panel5 = new AntdUI.Panel();
            this.panFloat = new AntdUI.Panel();
            this.btnNext = new AntdUI.Button();
            this.btnBack = new AntdUI.Button();
            this.scintilla = new ScintillaNET.Scintilla();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panFloat.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.panel1.BorderWidth = 2F;
            this.panel1.Controls.Add(this.btnOK);
            this.panel1.Controls.Add(this.datePickerRange1);
            this.panel1.Controls.Add(this.txtSearchKey);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(16, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(928, 58);
            this.panel1.TabIndex = 0;
            this.panel1.Text = "panel1";
            // 
            // btnOK
            // 
            this.btnOK.BorderWidth = 1F;
            this.btnOK.DefaultBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.btnOK.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.btnOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(77)))), ((int)(((byte)(87)))));
            this.btnOK.Location = new System.Drawing.Point(759, 13);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(137, 36);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "文件列表";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // datePickerRange1
            // 
            this.datePickerRange1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.datePickerRange1.Location = new System.Drawing.Point(27, 13);
            this.datePickerRange1.Name = "datePickerRange1";
            this.datePickerRange1.PlaceholderEnd = "结束时间";
            this.datePickerRange1.PlaceholderStart = "开始时间";
            this.datePickerRange1.Presets.AddRange(new object[] {
            "今天",
            "昨天",
            "本月",
            "上月",
            "过去3天",
            "过去7天",
            "过去15天"});
            this.datePickerRange1.Size = new System.Drawing.Size(300, 36);
            this.datePickerRange1.TabIndex = 1;
            this.datePickerRange1.PresetsClickChanged += new AntdUI.ObjectNEventHandler(this.datePickerRange1_PresetsClickChanged);
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.txtSearchKey.Location = new System.Drawing.Point(424, 13);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.PlaceholderText = "模糊搜索条件";
            this.txtSearchKey.Size = new System.Drawing.Size(300, 36);
            this.txtSearchKey.TabIndex = 0;
            this.txtSearchKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchKey_KeyPress);
            // 
            // panel2
            // 
            this.panel2.Back = System.Drawing.SystemColors.Control;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(16, 74);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(928, 16);
            this.panel2.TabIndex = 0;
            this.panel2.Text = "panel1";
            // 
            // panel3
            // 
            this.panel3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.panel3.BorderWidth = 2F;
            this.panel3.Controls.Add(this.tabLogs);
            this.panel3.Location = new System.Drawing.Point(16, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(928, 292);
            this.panel3.TabIndex = 0;
            this.panel3.Text = "panel1";
            // 
            // tabLogs
            // 
            this.tabLogs.CellImpactHeight = false;
            this.tabLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLogs.Gap = 12;
            this.tabLogs.Location = new System.Drawing.Point(2, 2);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Radius = 6;
            this.tabLogs.Size = new System.Drawing.Size(924, 288);
            this.tabLogs.TabIndex = 0;
            this.tabLogs.Text = "table1";
            this.tabLogs.CellDoubleClick += new AntdUI.Table.ClickEventHandler(this.tabLogs_CellDoubleClick);
            // 
            // panel4
            // 
            this.panel4.Back = System.Drawing.SystemColors.Control;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(16, 90);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(928, 16);
            this.panel4.TabIndex = 0;
            this.panel4.Text = "panel1";
            // 
            // panel5
            // 
            this.panel5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(200)))), ((int)(((byte)(204)))));
            this.panel5.BorderWidth = 2F;
            this.panel5.Controls.Add(this.panFloat);
            this.panel5.Controls.Add(this.scintilla);
            this.panel5.Location = new System.Drawing.Point(16, 398);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(928, 281);
            this.panel5.TabIndex = 0;
            this.panel5.Text = "panel1";
            // 
            // panFloat
            // 
            this.panFloat.Controls.Add(this.btnNext);
            this.panFloat.Controls.Add(this.btnBack);
            this.panFloat.Location = new System.Drawing.Point(860, 18);
            this.panFloat.Name = "panFloat";
            this.panFloat.Size = new System.Drawing.Size(36, 108);
            this.panFloat.TabIndex = 1;
            // 
            // btnNext
            // 
            this.btnNext.IconRatio = 1.2F;
            this.btnNext.IconSvg = "DownCircleFilled";
            this.btnNext.Location = new System.Drawing.Point(0, 42);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(36, 36);
            this.btnNext.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.IconRatio = 1.2F;
            this.btnBack.IconSvg = "UpCircleFilled";
            this.btnBack.Location = new System.Drawing.Point(0, 0);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(36, 36);
            this.btnBack.TabIndex = 0;
            // 
            // scintilla
            // 
            this.scintilla.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.scintilla.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintilla.Location = new System.Drawing.Point(2, 2);
            this.scintilla.Name = "scintilla";
            this.scintilla.Size = new System.Drawing.Size(924, 277);
            this.scintilla.TabIndex = 0;
            // 
            // FrmLogViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 679);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "FrmLogViewer";
            this.Padding = new System.Windows.Forms.Padding(16, 16, 16, 0);
            this.Text = "FrmLogViewer";
            this.Load += new System.EventHandler(this.FrmLogViewer_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panFloat.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private AntdUI.Panel panel1;
        private AntdUI.Panel panel2;
        private AntdUI.Panel panel3;
        private AntdUI.Panel panel4;
        private AntdUI.Panel panel5;
        private AntdUI.Button btnOK;
        private AntdUI.DatePickerRange datePickerRange1;
        private AntdUI.Input txtSearchKey;
        private ScintillaNET.Scintilla scintilla;
        private AntdUI.Panel panFloat;
        private AntdUI.Button btnNext;
        private AntdUI.Button btnBack;
        private AntdUI.Table tabLogs;
    }
}