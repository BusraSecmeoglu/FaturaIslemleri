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
    public partial class FormIl : Form
    {
        public FormIl()
        {
            InitializeComponent();
        }

        FaturaContext db = new FaturaContext();
        int secilenID;

        private void FormIl_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void Listele()
        {
            var list = db.Iller.Select(x => new
            {
                SehirKodu = x.IlId,
                SehirAdi = x.Aciklama
            }).ToList();
            dataGridView1.DataSource = list;
            txtilAdi.Clear();
            txtilAdi.Focus();

        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            secilenID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            Il il = db.Iller.Find(secilenID);
            txtilAdi.Text = il.Aciklama;
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                Il il = new Il();
                il.Aciklama = txtilAdi.Text;
                db.Iller.Add(il);
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
                Il i = db.Iller.Find(secilenID);
                i.Aciklama = txtilAdi.Text;
                db.SaveChanges();
                Listele();
            }
            catch (Exception)
            {

                MessageBox.Show("Lütfen tüm değerleri giriniz");
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

                if (dataGridView1.CurrentRow == null)
                    return;
                Il i = db.Iller.Find(secilenID);
                db.Iller.Remove(i);
                db.SaveChanges();
                Listele();


        }


    }
}
