namespace ADOForm
{
    partial class UserMain
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
            this.SongManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LogoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.MypageBtn = new System.Windows.Forms.Button();
            this.BookingBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(28, 28);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SongManageToolStripMenuItem,
            this.ProInfoToolStripMenuItem,
            this.LogoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SongManageToolStripMenuItem
            // 
            this.SongManageToolStripMenuItem.Name = "SongManageToolStripMenuItem";
            this.SongManageToolStripMenuItem.Size = new System.Drawing.Size(71, 22);
            this.SongManageToolStripMenuItem.Text = "예매 관리";
            // 
            // ProInfoToolStripMenuItem
            // 
            this.ProInfoToolStripMenuItem.Name = "ProInfoToolStripMenuItem";
            this.ProInfoToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.ProInfoToolStripMenuItem.Text = "프로그램 정보";
            this.ProInfoToolStripMenuItem.Click += new System.EventHandler(this.ProInfoToolStripMenuItem_Click);
            // 
            // LogoutToolStripMenuItem
            // 
            this.LogoutToolStripMenuItem.Name = "LogoutToolStripMenuItem";
            this.LogoutToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            this.LogoutToolStripMenuItem.Text = "로그아웃";
            this.LogoutToolStripMenuItem.Click += new System.EventHandler(this.LogoutToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("휴먼모음T", 18.85714F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(301, 113);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 42);
            this.label4.TabIndex = 31;
            this.label4.Text = "CGV 메인 페이지";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(625, 44);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 12);
            this.label7.TabIndex = 30;
            this.label7.Text = "ID_line";
            // 
            // MypageBtn
            // 
            this.MypageBtn.Location = new System.Drawing.Point(456, 168);
            this.MypageBtn.Margin = new System.Windows.Forms.Padding(2);
            this.MypageBtn.Name = "MypageBtn";
            this.MypageBtn.Size = new System.Drawing.Size(172, 131);
            this.MypageBtn.TabIndex = 29;
            this.MypageBtn.Text = "마이 페이지";
            this.MypageBtn.UseVisualStyleBackColor = true;
            this.MypageBtn.Click += new System.EventHandler(this.MypageBtn_Click);
            // 
            // BookingBtn
            // 
            this.BookingBtn.Location = new System.Drawing.Point(207, 168);
            this.BookingBtn.Margin = new System.Windows.Forms.Padding(2);
            this.BookingBtn.Name = "BookingBtn";
            this.BookingBtn.Size = new System.Drawing.Size(172, 131);
            this.BookingBtn.TabIndex = 28;
            this.BookingBtn.Text = "영화 예매";
            this.BookingBtn.UseVisualStyleBackColor = true;
            this.BookingBtn.Click += new System.EventHandler(this.BookingBtn_Click);
            // 
            // UserMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.MypageBtn);
            this.Controls.Add(this.BookingBtn);
            this.Name = "UserMain";
            this.Text = "UserMain";
            this.Load += new System.EventHandler(this.UserMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SongManageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LogoutToolStripMenuItem;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button MypageBtn;
        private System.Windows.Forms.Button BookingBtn;
    }
}