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
    public partial class FormIlce : Form
    {
        public FormIlce()
        {
            InitializeComponent();
        }
        FaturaContext db = new FaturaContext();
        int secilenid;

        private void FormIlce_Load(object sender, EventArgs e)
        {
            ComboListele();
            Listele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Ilce ilce = new Ilce();
                ilce.Aciklama = txtIlceAdi.Text;
                ilce.IlId = Convert.ToInt32(comboSehir.SelectedValue);
                db.Ilceler.Add(ilce);
                db.SaveChanges();
                Listele();
            }
            catch
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            //try
            //{
            Ilce ilce = db.Ilceler.Find(secilenid);
            ilce.Aciklama = txtIlceAdi.Text;
            ilce.IlId = Convert.ToInt32(comboSehir.SelectedValue);
            db.SaveChanges();
            Listele();
            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Lütfen bir ilçe seçiniz.");
            //}
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                Ilce ilce = db.Ilceler.Find(secilenid);
                db.Ilceler.Remove(ilce);
                db.SaveChanges();
                Listele();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen bir ilçe seçiniz.");
            }
        }

        private void dgvSehirler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                secilenid = Convert.ToInt32(dgvSehirler.CurrentRow.Cells[2].Value);
                Ilce ilce = db.Ilceler.Find(secilenid);
                txtIlceAdi.Text = ilce.Aciklama;
                comboSehir.SelectedValue = ilce.il.IlId;
            }
            catch (Exception)
            {

                return;
            }
        }

        private void comboSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            try
            {
                var list = db.Ilceler.Select(x => new
                {
                    x.IlId,
                    sehirAdi = x.il.Aciklama,
                    x.IlceId,
                    ilceAdi = x.Aciklama
                }).Where(x => x.IlId == (int)comboSehir.SelectedValue).OrderBy(x => x.sehirAdi).ToList();
                dgvSehirler.DataSource = list;
                dgvSehirler.Columns[0].Visible = false;
                dgvSehirler.Columns[2].Visible = false;
                txtIlceAdi.Clear();
                txtIlceAdi.Focus();
            }
            catch (Exception)
            {
                return;
            }



        }
        private void ComboListele()
        {
            var list = db.Iller.Select(x => new
            {
                x.IlId,
                x.Aciklama
            }).OrderBy(x => x.Aciklama).ToList();

            comboSehir.DisplayMember = "Aciklama";
            comboSehir.ValueMember = "IlID";
            comboSehir.DataSource = list;
        }

    }
}
