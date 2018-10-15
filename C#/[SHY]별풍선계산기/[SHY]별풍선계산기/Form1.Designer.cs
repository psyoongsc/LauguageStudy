namespace _SHY_별풍선계산기
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.베스트BJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.일반BJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Item_Count_Text = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.세액_Label = new System.Windows.Forms.Label();
            this.수수료액_Label = new System.Windows.Forms.Label();
            this.수익금_Label = new System.Windows.Forms.Label();
            this.원금액_Label = new System.Windows.Forms.Label();
            this.수수료_Label = new System.Windows.Forms.Label();
            this.BJ수익_Label = new System.Windows.Forms.Label();
            this.세금_Label = new System.Windows.Forms.Label();
            this.원금_Label = new System.Windows.Forms.Label();
            this.받은별풍선개수_Label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.파트너BJToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(402, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.systemToolStripMenuItem.Text = "시스템(&S)";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.closeToolStripMenuItem.Text = "닫기(&C)";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.베스트BJToolStripMenuItem,
            this.파트너BJToolStripMenuItem,
            this.일반BJToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.optionsToolStripMenuItem.Text = "옵션(&O)";
            // 
            // 베스트BJToolStripMenuItem
            // 
            this.베스트BJToolStripMenuItem.Checked = true;
            this.베스트BJToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.베스트BJToolStripMenuItem.Name = "베스트BJToolStripMenuItem";
            this.베스트BJToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.베스트BJToolStripMenuItem.Text = "베스트BJ";
            this.베스트BJToolStripMenuItem.Click += new System.EventHandler(this.베스트BJToolStripMenuItem_Click);
            // 
            // 일반BJToolStripMenuItem
            // 
            this.일반BJToolStripMenuItem.Name = "일반BJToolStripMenuItem";
            this.일반BJToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.일반BJToolStripMenuItem.Text = "일반BJ";
            this.일반BJToolStripMenuItem.Click += new System.EventHandler(this.일반BJToolStripMenuItem_Click);
            // 
            // Item_Count_Text
            // 
            this.Item_Count_Text.Font = new System.Drawing.Font("함초롬바탕 확장", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Item_Count_Text.ForeColor = System.Drawing.Color.Black;
            this.Item_Count_Text.Location = new System.Drawing.Point(214, 45);
            this.Item_Count_Text.Name = "Item_Count_Text";
            this.Item_Count_Text.Size = new System.Drawing.Size(176, 23);
            this.Item_Count_Text.TabIndex = 1;
            this.Item_Count_Text.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Item_Count_Text_PreviewKeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.세액_Label);
            this.groupBox1.Controls.Add(this.수수료액_Label);
            this.groupBox1.Controls.Add(this.수익금_Label);
            this.groupBox1.Controls.Add(this.원금액_Label);
            this.groupBox1.Controls.Add(this.수수료_Label);
            this.groupBox1.Controls.Add(this.BJ수익_Label);
            this.groupBox1.Controls.Add(this.세금_Label);
            this.groupBox1.Controls.Add(this.원금_Label);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(12, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(378, 151);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "계산결과";
            // 
            // 세액_Label
            // 
            this.세액_Label.AutoSize = true;
            this.세액_Label.Location = new System.Drawing.Point(186, 124);
            this.세액_Label.Name = "세액_Label";
            this.세액_Label.Size = new System.Drawing.Size(14, 15);
            this.세액_Label.TabIndex = 6;
            this.세액_Label.Text = "0";
            // 
            // 수수료액_Label
            // 
            this.수수료액_Label.AutoSize = true;
            this.수수료액_Label.Location = new System.Drawing.Point(186, 93);
            this.수수료액_Label.Name = "수수료액_Label";
            this.수수료액_Label.Size = new System.Drawing.Size(14, 15);
            this.수수료액_Label.TabIndex = 5;
            this.수수료액_Label.Text = "0";
            // 
            // 수익금_Label
            // 
            this.수익금_Label.AutoSize = true;
            this.수익금_Label.Location = new System.Drawing.Point(186, 62);
            this.수익금_Label.Name = "수익금_Label";
            this.수익금_Label.Size = new System.Drawing.Size(14, 15);
            this.수익금_Label.TabIndex = 4;
            this.수익금_Label.Text = "0";
            // 
            // 원금액_Label
            // 
            this.원금액_Label.AutoSize = true;
            this.원금액_Label.Location = new System.Drawing.Point(186, 31);
            this.원금액_Label.Name = "원금액_Label";
            this.원금액_Label.Size = new System.Drawing.Size(14, 15);
            this.원금액_Label.TabIndex = 3;
            this.원금액_Label.Text = "0";
            // 
            // 수수료_Label
            // 
            this.수수료_Label.AutoSize = true;
            this.수수료_Label.Font = new System.Drawing.Font("함초롬바탕 확장B", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.수수료_Label.ForeColor = System.Drawing.Color.Gray;
            this.수수료_Label.Location = new System.Drawing.Point(20, 93);
            this.수수료_Label.Name = "수수료_Label";
            this.수수료_Label.Size = new System.Drawing.Size(126, 16);
            this.수수료_Label.TabIndex = 2;
            this.수수료_Label.Text = "아프리카TV 수수료로";
            // 
            // BJ수익_Label
            // 
            this.BJ수익_Label.AutoSize = true;
            this.BJ수익_Label.Font = new System.Drawing.Font("함초롬바탕 확장B", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.BJ수익_Label.ForeColor = System.Drawing.Color.Red;
            this.BJ수익_Label.Location = new System.Drawing.Point(20, 62);
            this.BJ수익_Label.Name = "BJ수익_Label";
            this.BJ수익_Label.Size = new System.Drawing.Size(108, 16);
            this.BJ수익_Label.TabIndex = 1;
            this.BJ수익_Label.Text = "BJ가 받는 금액은";
            // 
            // 세금_Label
            // 
            this.세금_Label.AutoSize = true;
            this.세금_Label.Font = new System.Drawing.Font("함초롬바탕 확장B", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.세금_Label.ForeColor = System.Drawing.Color.DarkViolet;
            this.세금_Label.Location = new System.Drawing.Point(20, 124);
            this.세금_Label.Name = "세금_Label";
            this.세금_Label.Size = new System.Drawing.Size(116, 16);
            this.세금_Label.TabIndex = 1;
            this.세금_Label.Text = "나라에 내신 금액은";
            // 
            // 원금_Label
            // 
            this.원금_Label.AutoSize = true;
            this.원금_Label.Font = new System.Drawing.Font("함초롬바탕 확장B", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.원금_Label.ForeColor = System.Drawing.Color.Fuchsia;
            this.원금_Label.Location = new System.Drawing.Point(20, 31);
            this.원금_Label.Name = "원금_Label";
            this.원금_Label.Size = new System.Drawing.Size(128, 16);
            this.원금_Label.TabIndex = 0;
            this.원금_Label.Text = "시청자가 주신 금액은";
            // 
            // 받은별풍선개수_Label
            // 
            this.받은별풍선개수_Label.AutoSize = true;
            this.받은별풍선개수_Label.Font = new System.Drawing.Font("함초롬바탕 확장B", 8.999999F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.받은별풍선개수_Label.ForeColor = System.Drawing.Color.Blue;
            this.받은별풍선개수_Label.Location = new System.Drawing.Point(109, 48);
            this.받은별풍선개수_Label.Name = "받은별풍선개수_Label";
            this.받은별풍선개수_Label.Size = new System.Drawing.Size(104, 16);
            this.받은별풍선개수_Label.TabIndex = 3;
            this.받은별풍선개수_Label.Text = "받은별풍선개수는";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SlateGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 243);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(402, 17);
            this.panel1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(88, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 11);
            this.label1.TabIndex = 0;
            this.label1.Text = "Copyright 2015. SHY all rights reserved.";
            // 
            // 파트너BJToolStripMenuItem
            // 
            this.파트너BJToolStripMenuItem.Name = "파트너BJToolStripMenuItem";
            this.파트너BJToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.파트너BJToolStripMenuItem.Text = "파트너BJ";
            this.파트너BJToolStripMenuItem.Click += new System.EventHandler(this.파트너BJToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 259);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.받은별풍선개수_Label);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Item_Count_Text);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "[SHY]별풍선계산기";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 베스트BJToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 일반BJToolStripMenuItem;
        private System.Windows.Forms.TextBox Item_Count_Text;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label 세액_Label;
        private System.Windows.Forms.Label 수수료액_Label;
        private System.Windows.Forms.Label 수익금_Label;
        private System.Windows.Forms.Label 원금액_Label;
        private System.Windows.Forms.Label 수수료_Label;
        private System.Windows.Forms.Label BJ수익_Label;
        private System.Windows.Forms.Label 세금_Label;
        private System.Windows.Forms.Label 원금_Label;
        private System.Windows.Forms.Label 받은별풍선개수_Label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem 파트너BJToolStripMenuItem;

    }
}

