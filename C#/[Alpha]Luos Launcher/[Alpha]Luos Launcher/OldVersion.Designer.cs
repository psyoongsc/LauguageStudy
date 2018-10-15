namespace _Alpha_Luos_Launcher
{
    partial class OldVersion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OldVersion));
            this.Close_Button = new System.Windows.Forms.PictureBox();
            this.Move_Sector = new System.Windows.Forms.PictureBox();
            this.Install_Button = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Move_Sector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Install_Button)).BeginInit();
            this.SuspendLayout();
            // 
            // Close_Button
            // 
            this.Close_Button.BackColor = System.Drawing.Color.Transparent;
            this.Close_Button.Location = new System.Drawing.Point(241, 0);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(21, 23);
            this.Close_Button.TabIndex = 2;
            this.Close_Button.TabStop = false;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // Move_Sector
            // 
            this.Move_Sector.BackColor = System.Drawing.Color.Transparent;
            this.Move_Sector.Location = new System.Drawing.Point(1, 0);
            this.Move_Sector.Name = "Move_Sector";
            this.Move_Sector.Size = new System.Drawing.Size(261, 24);
            this.Move_Sector.TabIndex = 3;
            this.Move_Sector.TabStop = false;
            this.Move_Sector.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_Sector_MouseDown);
            this.Move_Sector.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Move_Sector_MouseMove);
            this.Move_Sector.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Move_Sector_MouseUp);
            // 
            // Install_Button
            // 
            this.Install_Button.BackColor = System.Drawing.Color.Transparent;
            this.Install_Button.Location = new System.Drawing.Point(75, 102);
            this.Install_Button.Name = "Install_Button";
            this.Install_Button.Size = new System.Drawing.Size(97, 29);
            this.Install_Button.TabIndex = 4;
            this.Install_Button.TabStop = false;
            this.Install_Button.Click += new System.EventHandler(this.Install_Button_Click);
            this.Install_Button.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_Sector_MouseDown);
            this.Install_Button.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Move_Sector_MouseMove);
            this.Install_Button.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Move_Sector_MouseUp);
            // 
            // OldVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::_Alpha_Luos_Launcher.Properties.Resources.KakaoTalk_20160612_093846251;
            this.ClientSize = new System.Drawing.Size(262, 135);
            this.Controls.Add(this.Install_Button);
            this.Controls.Add(this.Close_Button);
            this.Controls.Add(this.Move_Sector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OldVersion";
            this.Text = "OldVersion";
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Move_Sector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Install_Button)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Close_Button;
        private System.Windows.Forms.PictureBox Move_Sector;
        private System.Windows.Forms.PictureBox Install_Button;
    }
}