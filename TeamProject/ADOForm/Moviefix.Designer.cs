namespace ADOForm
{
    partial class Moviefix
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
            this.선택한행업데이트ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.새로운데이터추가ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.선택한행삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.DBGrid)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DBGrid
            // 
            this.DBGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DBGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DBGrid.Location = new System.Drawing.Point(12, 67);
            this.DBGrid.Name = "DBGrid";
            this.DBGrid.RowTemplate.Height = 23;
            this.DBGrid.Size = new System.Drawing.Size(1332, 329);
            this.DBGrid.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.선택한행업데이트ToolStripMenuItem,
            this.새로운데이터추가ToolStripMenuItem,
            this.선택한행삭제ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(191, 70);
            // 
            // 선택한행업데이트ToolStripMenuItem
            // 
            this.선택한행업데이트ToolStripMenuItem.Name = "선택한행업데이트ToolStripMenuItem";
            this.선택한행업데이트ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.선택한행업데이트ToolStripMenuItem.Text = "선택한 영화 업데이트";
            this.선택한행업데이트ToolStripMenuItem.Click += new System.EventHandler(this.선택한행업데이트ToolStripMenuItem_Click);
            // 
            // 새로운데이터추가ToolStripMenuItem
            // 
            this.새로운데이터추가ToolStripMenuItem.Name = "새로운데이터추가ToolStripMenuItem";
            this.새로운데이터추가ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.새로운데이터추가ToolStripMenuItem.Text = "새로운 데이터 추가";
            this.새로운데이터추가ToolStripMenuItem.Click += new System.EventHandler(this.새로운데이터추가ToolStripMenuItem_Click);
            // 
            // 선택한행삭제ToolStripMenuItem
            // 
            this.선택한행삭제ToolStripMenuItem.Name = "선택한행삭제ToolStripMenuItem";
            this.선택한행삭제ToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.선택한행삭제ToolStripMenuItem.Text = "선택한 영화 삭제";
            this.선택한행삭제ToolStripMenuItem.Click += new System.EventHandler(this.선택한행삭제ToolStripMenuItem_Click);
            // 
            // Moviefix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 450);
            this.Controls.Add(this.DBGrid);
            this.Name = "Moviefix";
            this.Text = "Moviefix";
            this.Load += new System.EventHandler(this.Moviefix_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DBGrid)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DBGrid;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 선택한행업데이트ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 새로운데이터추가ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 선택한행삭제ToolStripMenuItem;
    }
}