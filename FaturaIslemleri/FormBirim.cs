using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FaturaIslemleri.FaturaContext;

namespace FaturaIslemleri
{
    public partial class FormBirim : Form
    {
        FaturaContext db = new FaturaContext();
        int secilenID;

        private void Listele()
        {
            var list = db.Birimler.Select(x => new
            {
                BirimKodu = x.BirimId,
                BirimAdi = x.BirimAdi
            }).ToList();
            dataGridView1.DataSource = list;
            txtBirimAdi.Clear();
            txtBirimAdi.Focus();

        }
        public FormBirim()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                Birim birim = db.Birimler.Find(secilenID);
                db.Birimler.Remove(birim);
                db.SaveChanges();
                Listele();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen tüm değerleri giriniz");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                Birim birim = db.Birimler.Find(secilenID);
                birim.BirimAdi = txtBirimAdi.Text;
                db.SaveChanges();
                Listele();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen tüm değerleri giriniz");
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Birim birim = new Birim();
                birim.BirimAdi = txtBirimAdi.Text;
                db.Birimler.Add(birim);
                db.SaveChanges();
                Listele();
            }
            catch
            {
                MessageBox.Show("Lütfen tüm değerleri giriniz");
            }

        }

        private void txtBirimAdi_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Birim birim = db.Birimler.Find(secilenID);
            txtBirimAdi.Text = birim.BirimAdi;
        }

        private void FormBirim_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
