namespace _Alpha_Luos_Launcher
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Notice_Button = new System.Windows.Forms.PictureBox();
            this.PatchNote_Button = new System.Windows.Forms.PictureBox();
            this.GameStart_Button = new System.Windows.Forms.PictureBox();
            this.Shutdown_Button = new System.Windows.Forms.PictureBox();
            this.Move_Sector = new System.Windows.Forms.PictureBox();
            this.Update_Button = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Notice_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatchNote_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameStart_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shutdown_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Move_Sector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Update_Button)).BeginInit();
            this.SuspendLayout();
            // 
            // Notice_Button
            // 
            this.Notice_Button.BackColor = System.Drawing.Color.Transparent;
            this.Notice_Button.Location = new System.Drawing.Point(36, 285);
            this.Notice_Button.Name = "Notice_Button";
            this.Notice_Button.Size = new System.Drawing.Size(107, 42);
            this.Notice_Button.TabIndex = 0;
            this.Notice_Button.TabStop = false;
            this.Notice_Button.Click += new System.EventHandler(this.Notice_Button_Click);
            // 
            // PatchNote_Button
            // 
            this.PatchNote_Button.BackColor = System.Drawing.Color.Transparent;
            this.PatchNote_Button.Location = new System.Drawing.Point(145, 285);
            this.PatchNote_Button.Name = "PatchNote_Button";
            this.PatchNote_Button.Size = new System.Drawing.Size(107, 42);
            this.PatchNote_Button.TabIndex = 1;
            this.PatchNote_Button.TabStop = false;
            this.PatchNote_Button.Click += new System.EventHandler(this.PatchNote_Button_Click);
            // 
            // GameStart_Button
            // 
            this.GameStart_Button.BackColor = System.Drawing.Color.Transparent;
            this.GameStart_Button.Location = new System.Drawing.Point(265, 285);
            this.GameStart_Button.Name = "GameStart_Button";
            this.GameStart_Button.Size = new System.Drawing.Size(158, 42);
            this.GameStart_Button.TabIndex = 2;
            this.GameStart_Button.TabStop = false;
            this.GameStart_Button.Click += new System.EventHandler(this.GameStart_Button_Click);
            // 
            // Shutdown_Button
            // 
            this.Shutdown_Button.BackColor = System.Drawing.Color.Transparent;
            this.Shutdown_Button.Location = new System.Drawing.Point(558, 285);
            this.Shutdown_Button.Name = "Shutdown_Button";
            this.Shutdown_Button.Size = new System.Drawing.Size(56, 42);
            this.Shutdown_Button.TabIndex = 5;
            this.Shutdown_Button.TabStop = false;
            this.Shutdown_Button.Click += new System.EventHandler(this.Shutdown_Button_Click);
            // 
            // Move_Sector
            // 
            this.Move_Sector.BackColor = System.Drawing.Color.Transparent;
            this.Move_Sector.Location = new System.Drawing.Point(-1, 0);
            this.Move_Sector.Name = "Move_Sector";
            this.Move_Sector.Size = new System.Drawing.Size(666, 23);
            this.Move_Sector.TabIndex = 6;
            this.Move_Sector.TabStop = false;
            this.Move_Sector.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_Sector_MouseDown);
            this.Move_Sector.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Move_Sector_MouseMove);
            this.Move_Sector.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Move_Sector_MouseUp);
            // 
            // Update_Button
            // 
            this.Update_Button.BackColor = System.Drawing.Color.Transparent;
            this.Update_Button.Location = new System.Drawing.Point(439, 285);
            this.Update_Button.Name = "Update_Button";
            this.Update_Button.Size = new System.Drawing.Size(105, 42);
            this.Update_Button.TabIndex = 7;
            this.Update_Button.TabStop = false;
            this.Update_Button.Click += new System.EventHandler(this.Update_Button_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(665, 389);
            this.Controls.Add(this.Update_Button);
            this.Controls.Add(this.Move_Sector);
            this.Controls.Add(this.Shutdown_Button);
            this.Controls.Add(this.GameStart_Button);
            this.Controls.Add(this.PatchNote_Button);
            this.Controls.Add(this.Notice_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.Notice_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PatchNote_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameStart_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Shutdown_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Move_Sector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Update_Button)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Notice_Button;
        private System.Windows.Forms.PictureBox PatchNote_Button;
        private System.Windows.Forms.PictureBox GameStart_Button;
        private System.Windows.Forms.PictureBox Shutdown_Button;
        private System.Windows.Forms.PictureBox Move_Sector;
        private System.Windows.Forms.PictureBox Update_Button;
    }
}

