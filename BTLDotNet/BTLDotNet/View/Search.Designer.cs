namespace BTLDotNet.View
{
    partial class Search
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
            this.lsSearch = new System.Windows.Forms.ListView();
            this.chuong = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.noiDung = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.doDai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lsSearch
            // 
            this.lsSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chuong,
            this.doDai,
            this.noiDung});
            this.lsSearch.Location = new System.Drawing.Point(12, 12);
            this.lsSearch.Name = "lsSearch";
            this.lsSearch.Size = new System.Drawing.Size(760, 457);
            this.lsSearch.TabIndex = 0;
            this.lsSearch.UseCompatibleStateImageBehavior = false;
            this.lsSearch.View = System.Windows.Forms.View.Details;
            // 
            // chuong
            // 
            this.chuong.Text = "Chương";
            // 
            // noiDung
            // 
            this.noiDung.Text = "Nội Dung";
            this.noiDung.Width = 628;
            // 
            // doDai
            // 
            this.doDai.Text = "Độ Dài";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 481);
            this.Controls.Add(this.lsSearch);
            this.MaximumSize = new System.Drawing.Size(800, 520);
            this.MinimumSize = new System.Drawing.Size(800, 520);
            this.Name = "Search";
            this.Text = "Search";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lsSearch;
        private System.Windows.Forms.ColumnHeader chuong;
        private System.Windows.Forms.ColumnHeader noiDung;
        private System.Windows.Forms.ColumnHeader doDai;
    }
}