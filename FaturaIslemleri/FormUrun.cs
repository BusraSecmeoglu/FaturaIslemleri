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
    public partial class FormUrun : Form
    {
        FaturaContext db = new FaturaContext();
        int secilenID;

        public FormUrun()
        {
            InitializeComponent();
        }

        private void FormUrun_Load(object sender, EventArgs e)
        {
            BirimListele();
            Listele();
        }

        private void BirimListele()
        {
            var list = db.Birimler.Select(x => new
            {
                x.BirimId,
                x.BirimAdi
            }).OrderBy(x => x.BirimAdi).ToList();
            comboBirimAdi.DisplayMember = "BirimAdi";
            comboBirimAdi.ValueMember = "BirimId";
            comboBirimAdi.DataSource = list;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Urun urun = new Urun();
                urun.UrunAdi = txtUrunAdi.Text;
                urun.UrunKodu = txtUrunKodu.Text;
                urun.BirimFiyat = Convert.ToDecimal(txtBirimFiyati.Text);
                urun.BirimID = Convert.ToInt32(comboBirimAdi.SelectedValue);
                db.Urunler.Add(urun);
                db.SaveChanges();
                Listele();
            }
            catch
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }
        }

        private void Listele()
        {
            try
            {
                var list = db.Urunler.Select(x => new
                {
                    x.BirimID,
                    x.UrunID,
                    UrunAdi = x.UrunAdi,
                    BirimAdi = x.Birim.BirimAdi,
                    UrunFiyat = x.BirimFiyat,
                    UrunKodu = x.UrunKodu
                }).Where(x => x.BirimID == (int)comboBirimAdi.SelectedValue).OrderBy(x => x.UrunAdi).ToList();
                dataGridView1.DataSource = list;
                dataGridView1.Columns["BirimID"].Visible = false;
                dataGridView1.Columns["UrunID"].Visible = false;
                Temizle();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata oluştu");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                Urun urun = db.Urunler.Find(secilenID);
                urun.UrunAdi = txtUrunAdi.Text;
                urun.BirimFiyat = Convert.ToDecimal(txtBirimFiyati.Text);
                urun.UrunKodu = txtUrunKodu.Text;
                urun.BirimID = Convert.ToInt32(comboBirimAdi.SelectedValue);
                db.SaveChanges();
                Listele();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                Urun urun = db.Urunler.Find(secilenID);
                db.Urunler.Remove(urun);
                db.SaveChanges();
                Listele();
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu");
            }
        }

        private void Temizle()
        {
            txtBirimFiyati.Clear();
            txtUrunAdi.Clear();
            txtUrunKodu.Clear();
            comboBirimAdi.Focus();
        }

        private void comboBirimAdi_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                secilenID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[1].Value);
                Urun urun = db.Urunler.Find(secilenID);
                txtUrunAdi.Text = urun.UrunAdi;
                txtUrunKodu.Text = urun.UrunKodu;
                txtBirimFiyati.Text = urun.BirimFiyat.ToString();
                comboBirimAdi.SelectedItem = secilenID;
            }
            catch (Exception)
            {

                return;
            }
        }
    }
}
