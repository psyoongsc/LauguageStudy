namespace _Alpha_Luos_Launcher
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.Move_Sector = new System.Windows.Forms.PictureBox();
            this.GameStart_Button = new System.Windows.Forms.PictureBox();
            this.Close_Button = new System.Windows.Forms.PictureBox();
            this.ID = new System.Windows.Forms.TextBox();
            this.PW = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Move_Sector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameStart_Button)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).BeginInit();
            this.SuspendLayout();
            // 
            // Move_Sector
            // 
            this.Move_Sector.BackColor = System.Drawing.Color.Transparent;
            this.Move_Sector.Location = new System.Drawing.Point(0, 0);
            this.Move_Sector.Name = "Move_Sector";
            this.Move_Sector.Size = new System.Drawing.Size(455, 16);
            this.Move_Sector.TabIndex = 0;
            this.Move_Sector.TabStop = false;
            this.Move_Sector.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Move_Sector_MouseDown);
            this.Move_Sector.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Move_Sector_MouseMove);
            this.Move_Sector.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Move_Sector_MouseUp);
            // 
            // GameStart_Button
            // 
            this.GameStart_Button.BackColor = System.Drawing.Color.Transparent;
            this.GameStart_Button.Location = new System.Drawing.Point(254, 155);
            this.GameStart_Button.Name = "GameStart_Button";
            this.GameStart_Button.Size = new System.Drawing.Size(118, 35);
            this.GameStart_Button.TabIndex = 1;
            this.GameStart_Button.TabStop = false;
            this.GameStart_Button.Click += new System.EventHandler(this.GameStart_Button_Click);
            // 
            // Close_Button
            // 
            this.Close_Button.BackColor = System.Drawing.Color.Transparent;
            this.Close_Button.Location = new System.Drawing.Point(316, 191);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(56, 28);
            this.Close_Button.TabIndex = 2;
            this.Close_Button.TabStop = false;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // ID
            // 
            this.ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ID.Location = new System.Drawing.Point(91, 165);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(149, 14);
            this.ID.TabIndex = 3;
            // 
            // PW
            // 
            this.PW.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PW.Location = new System.Drawing.Point(90, 193);
            this.PW.Name = "PW";
            this.PW.PasswordChar = '●';
            this.PW.Size = new System.Drawing.Size(149, 14);
            this.PW.TabIndex = 4;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(117, 279);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(390, 252);
            this.textBox1.TabIndex = 5;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(455, 258);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.PW);
            this.Controls.Add(this.ID);
            this.Controls.Add(this.Close_Button);
            this.Controls.Add(this.GameStart_Button);
            this.Controls.Add(this.Move_Sector);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.Move_Sector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GameStart_Button)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Close_Button)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Move_Sector;
        private System.Windows.Forms.PictureBox GameStart_Button;
        private System.Windows.Forms.PictureBox Close_Button;
        private System.Windows.Forms.TextBox ID;
        private System.Windows.Forms.TextBox PW;
        private System.Windows.Forms.TextBox textBox1;
    }
}