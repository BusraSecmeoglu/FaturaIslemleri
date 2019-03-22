namespace FaturaIslemleri
{
    partial class FormMusteri
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
            this.txtMusteriAdresi = new System.Windows.Forms.TextBox();
            this.comboMusteriIlce = new System.Windows.Forms.ComboBox();
            this.comboMusteriSehir = new System.Windows.Forms.ComboBox();
            this.txtMusteriUnvani = new System.Windows.Forms.TextBox();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMusteriler = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriler)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMusteriAdresi
            // 
            this.txtMusteriAdresi.Location = new System.Drawing.Point(575, 24);
            this.txtMusteriAdresi.Margin = new System.Windows.Forms.Padding(4);
            this.txtMusteriAdresi.Multiline = true;
            this.txtMusteriAdresi.Name = "txtMusteriAdresi";
            this.txtMusteriAdresi.Size = new System.Drawing.Size(307, 79);
            this.txtMusteriAdresi.TabIndex = 18;
            // 
            // comboMusteriIlce
            // 
            this.comboMusteriIlce.FormattingEnabled = true;
            this.comboMusteriIlce.Location = new System.Drawing.Point(201, 121);
            this.comboMusteriIlce.Margin = new System.Windows.Forms.Padding(4);
            this.comboMusteriIlce.Name = "comboMusteriIlce";
            this.comboMusteriIlce.Size = new System.Drawing.Size(192, 24);
            this.comboMusteriIlce.TabIndex = 16;
            // 
            // comboMusteriSehir
            // 
            this.comboMusteriSehir.FormattingEnabled = true;
            this.comboMusteriSehir.Location = new System.Drawing.Point(201, 78);
            this.comboMusteriSehir.Margin = new System.Windows.Forms.Padding(4);
            this.comboMusteriSehir.Name = "comboMusteriSehir";
            this.comboMusteriSehir.Size = new System.Drawing.Size(192, 24);
            this.comboMusteriSehir.TabIndex = 17;
            this.comboMusteriSehir.SelectedIndexChanged += new System.EventHandler(this.comboMusteriSehir_SelectedIndexChanged);
            // 
            // txtMusteriUnvani
            // 
            this.txtMusteriUnvani.Location = new System.Drawing.Point(201, 32);
            this.txtMusteriUnvani.Margin = new System.Windows.Forms.Padding(4);
            this.txtMusteriUnvani.Name = "txtMusteriUnvani";
            this.txtMusteriUnvani.Size = new System.Drawing.Size(192, 22);
            this.txtMusteriUnvani.TabIndex = 15;
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(737, 125);
            this.btnSil.Margin = new System.Windows.Forms.Padding(4);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 28);
            this.btnSil.TabIndex = 12;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = true;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.Location = new System.Drawing.Point(588, 125);
            this.btnGuncelle.Margin = new System.Windows.Forms.Padding(4);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(100, 28);
            this.btnGuncelle.TabIndex = 13;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = true;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(435, 125);
            this.btnEkle.Margin = new System.Windows.Forms.Padding(4);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(100, 28);
            this.btnEkle.TabIndex = 14;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = true;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Müşteri İlçesi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(431, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Müşteri Adresi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Müşteri Şehri";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 35);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Müşteri Ünvanı";
            // 
            // dgvMusteriler
            // 
            this.dgvMusteriler.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMusteriler.Location = new System.Drawing.Point(36, 185);
            this.dgvMusteriler.Margin = new System.Windows.Forms.Padding(4);
            this.dgvMusteriler.Name = "dgvMusteriler";
            this.dgvMusteriler.Size = new System.Drawing.Size(868, 185);
            this.dgvMusteriler.TabIndex = 7;
            this.dgvMusteriler.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMusteriler_CellClick);
            // 
            // FormMusteri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 408);
            this.Controls.Add(this.txtMusteriAdresi);
            this.Controls.Add(this.comboMusteriIlce);
            this.Controls.Add(this.comboMusteriSehir);
            this.Controls.Add(this.txtMusteriUnvani);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvMusteriler);
            this.Name = "FormMusteri";
            this.Text = "FormMusteri";
            this.Load += new System.EventHandler(this.FormMusteri_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMusteriler)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtMusteriAdresi;
        private System.Windows.Forms.ComboBox comboMusteriIlce;
        private System.Windows.Forms.ComboBox comboMusteriSehir;
        private System.Windows.Forms.TextBox txtMusteriUnvani;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMusteriler;
    }
}