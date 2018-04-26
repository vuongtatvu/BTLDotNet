namespace BTLDotNet.View
{
    partial class ChinhTa
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
            this.lsChinhTa = new System.Windows.Forms.ListView();
            this.tu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sai = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lsChinhTa
            // 
            this.lsChinhTa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lsChinhTa.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tu,
            this.sai});
            this.lsChinhTa.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsChinhTa.Location = new System.Drawing.Point(12, 58);
            this.lsChinhTa.Name = "lsChinhTa";
            this.lsChinhTa.Size = new System.Drawing.Size(760, 411);
            this.lsChinhTa.TabIndex = 0;
            this.lsChinhTa.UseCompatibleStateImageBehavior = false;
            this.lsChinhTa.View = System.Windows.Forms.View.Details;
            // 
            // tu
            // 
            this.tu.Text = "Từ";
            this.tu.Width = 132;
            // 
            // sai
            // 
            this.sai.Text = "Sai";
            this.sai.Width = 602;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(301, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 24);
            this.label1.TabIndex = 1;
            this.label1.Text = "Danh Sách Sai Chính Tả";
            // 
            // ChinhTa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 481);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lsChinhTa);
            this.MaximumSize = new System.Drawing.Size(800, 520);
            this.MinimumSize = new System.Drawing.Size(800, 520);
            this.Name = "ChinhTa";
            this.Text = "ChinhTa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lsChinhTa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader tu;
        private System.Windows.Forms.ColumnHeader sai;
    }
}