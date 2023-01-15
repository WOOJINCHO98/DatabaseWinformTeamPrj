namespace ADOForm
{
    partial class userfix
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
            this.components = new System.ComponentModel.Container();
            this.DBGrid = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.정보수정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정보삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.정보등록ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DBGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DBGrid
            // 
            this.DBGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DBGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBGrid.Location = new System.Drawing.Point(12, 61);
            this.DBGrid.Name = "DBGrid";
            this.DBGrid.RowTemplate.Height = 23;
            this.DBGrid.Size = new System.Drawing.Size(1132, 329);
            this.DBGrid.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.정보수정ToolStripMenuItem,
            this.정보삭제ToolStripMenuItem,
            this.정보등록ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(155, 70);
            // 
            // 정보수정ToolStripMenuItem
            // 
            this.정보수정ToolStripMenuItem.Name = "정보수정ToolStripMenuItem";
            this.정보수정ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.정보수정ToolStripMenuItem.Text = "유저 정보 수정";
            this.정보수정ToolStripMenuItem.Click += new System.EventHandler(this.정보수정ToolStripMenuItem_Click);
            // 
            // 정보삭제ToolStripMenuItem
            // 
            this.정보삭제ToolStripMenuItem.Name = "정보삭제ToolStripMenuItem";
            this.정보삭제ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.정보삭제ToolStripMenuItem.Text = "유저 정보 삭제";
            this.정보삭제ToolStripMenuItem.Click += new System.EventHandler(this.정보삭제ToolStripMenuItem_Click);
            // 
            // 정보등록ToolStripMenuItem
            // 
            this.정보등록ToolStripMenuItem.Name = "정보등록ToolStripMenuItem";
            this.정보등록ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.정보등록ToolStripMenuItem.Text = "유저 정보 추가";
            this.정보등록ToolStripMenuItem.Click += new System.EventHandler(this.정보등록ToolStripMenuItem_Click);
            // 
            // userfix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1156, 450);
            this.Controls.Add(this.DBGrid);
            this.Name = "userfix";
            this.Text = "userfix";
            this.Load += new System.EventHandler(this.userfix_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DBGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DBGrid;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 정보수정ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 정보삭제ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 정보등록ToolStripMenuItem;
    }
}