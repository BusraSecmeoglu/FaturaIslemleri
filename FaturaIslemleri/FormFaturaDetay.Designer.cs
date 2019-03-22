namespace FaturaIslemleri
{
    partial class FormFaturaDetay
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
            this.dgvFaturaDetaylari = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaturaDetaylari)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFaturaDetaylari
            // 
            this.dgvFaturaDetaylari.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaturaDetaylari.Location = new System.Drawing.Point(37, 55);
            this.dgvFaturaDetaylari.Margin = new System.Windows.Forms.Padding(4);
            this.dgvFaturaDetaylari.Name = "dgvFaturaDetaylari";
            this.dgvFaturaDetaylari.Size = new System.Drawing.Size(681, 292);
            this.dgvFaturaDetaylari.TabIndex = 1;
            // 
            // FormFaturaDetay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvFaturaDetaylari);
            this.Name = "FormFaturaDetay";
            this.Text = "FormFaturaDetay";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaturaDetaylari)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFaturaDetaylari;
    }
}