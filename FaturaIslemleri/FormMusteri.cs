using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaturaIslemleri
{
    public partial class FormMusteri : Form
    {
        FaturaContext db = new FaturaContext();
        int secilenID;
        public FormMusteri()
        {
            InitializeComponent();
        }

        private void FormMusteri_Load(object sender, EventArgs e)
        {
            ilDoldur();
            Listele();
        }

        private void ilDoldur()
        {
            var list = db.Iller.Select(x => new
            {
                x.IlId,
                x.Aciklama

            }).OrderBy(x => x.Aciklama).ToList();
            comboMusteriSehir.DisplayMember = "Aciklama";
            comboMusteriSehir.ValueMember = "IlId";
            comboMusteriSehir.DataSource = list;
        }

        private void ilceDoldur()
        {
            var list = db.Ilceler.Select(x => new
            {
                x.IlId,
                x.IlceId,
                x.Aciklama

            }).OrderBy(x => x.Aciklama).Where(x => x.IlId == (int)comboMusteriSehir.SelectedValue).ToList();
            comboMusteriIlce.DisplayMember = "Aciklama";
            comboMusteriIlce.ValueMember = "IlceId";
            comboMusteriIlce.DataSource = list;
        }

        private void Listele()
        {
            var mlist = db.Musteriler.Select(x => new
            {
                MusteriKodu = x.MusteriID,
                x.MusteriUnvani,
                SehirAdi = x.ilce.il.Aciklama,
                IlceAdi = x.ilce.Aciklama,
                x.MusteriAdresi

            }).ToList();
            dgvMusteriler.DataSource = mlist;


            txtMusteriUnvani.Clear();
            txtMusteriUnvani.Focus();
        }

        private void comboMusteriSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilceDoldur();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Musteri musteri = new Musteri();
            musteri.MusteriUnvani = txtMusteriUnvani.Text;
            musteri.MusteriAdresi = txtMusteriAdresi.Text;
            musteri.IlceID = (int)comboMusteriIlce.SelectedValue;
            db.Musteriler.Add(musteri);
            db.SaveChanges();
            Listele();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                Musteri musteri = db.Musteriler.Find(secilenID);
                musteri.MusteriUnvani = txtMusteriUnvani.Text;
                musteri.MusteriAdresi = txtMusteriAdresi.Text;
                musteri.IlceID = (int)comboMusteriIlce.SelectedValue;
                db.SaveChanges();
                Listele();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz");
            }

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                Musteri musteri = db.Musteriler.Find(secilenID);
                db.Musteriler.Remove(musteri);
                db.SaveChanges();
                Listele();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen bir müşteri seçiniz");
            }

        }

        private void dgvMusteriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                secilenID = (int)dgvMusteriler.CurrentRow.Cells[0].Value;
                Musteri musteri = db.Musteriler.Find(secilenID);
                txtMusteriUnvani.Text = musteri.MusteriUnvani;
                txtMusteriAdresi.Text = musteri.MusteriAdresi;
                comboMusteriSehir.SelectedValue = musteri.ilce.IlId;
                comboMusteriIlce.SelectedValue = musteri.IlceID;
            }
            catch
            {

            }
        }
    }
}
