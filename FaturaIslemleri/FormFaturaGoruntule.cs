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
    public partial class FormFaturaGoruntule : Form
    {
        private FaturaContext _db;
        private Musteri _secilenMusteri;
        private List<FaturaMaster> _faturaMasters;

        public FormFaturaGoruntule()
        {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            _db = new FaturaContext();
            _secilenMusteri = null;
            _faturaMasters = new List<FaturaMaster>();

            cbMusteriSehir.DisplayMember = "Aciklama";
            cbMusteriSehir.ValueMember = "IlId";
            //database'den illei çekip listeliyoruz.
            cbMusteriSehir.DataSource = _db.Iller.ToList();
        }

        private void cbMusteriSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMusteriSehir.SelectedIndex == -1)
                return;

            //seçilen ilin ıd'sini İlID'ye atıyoruz.
            int ilID = Convert.ToInt32(cbMusteriSehir.SelectedValue);
            cbMusteriIlce.DisplayMember = "Aciklama";
            cbMusteriIlce.ValueMember = "IlceId";
            //İlID ile ilçeler arasında o ilçenin il ıd'si eşlesen ilçeleri listeliyoruz.
            cbMusteriIlce.DataSource = _db.Ilceler.Where(ilce => ilce.IlId == ilID).ToList();
        }

        private void cbMusteriIlce_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMusteriIlce.SelectedIndex == -1)
                return;
            //seçilen müşteri ilçesinin ıd'sini İlceID'ye atıyoruz.
            int ilceID = Convert.ToInt32(cbMusteriIlce.SelectedValue);
            cbMusteri.DisplayMember = "MusteriUnvani";
            cbMusteri.ValueMember = "MusteriID";
            //İlceID ile müşteriler arasında o müşterinin ilçe ıd'si eşlesen müşterileri listeliyoruz.
            cbMusteri.DataSource = _db.Musteriler.Where(musteri => musteri.IlceID == ilceID).ToList();
        }

        private void cbMusteri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMusteri.SelectedIndex == -1)
                return;

            _secilenMusteri = (Musteri)cbMusteri.SelectedItem;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(tbFaturaID.Text))
            {
                if (_secilenMusteri == null)
                    _faturaMasters = _db.FaturaMasters.ToList();
                else
                    _faturaMasters = _db.FaturaMasters.Where(fatura => fatura.MusteriID == _secilenMusteri.MusteriID).ToList();
            }
            else
            {
                if (!CheckFaturaID())
                    return;

                int faturaID = Convert.ToInt32(tbFaturaID.Text);

                if (_secilenMusteri == null)
                    _faturaMasters = _db.FaturaMasters.Where(fatura => fatura.FaturaID == faturaID).ToList();
                else
                    _faturaMasters = _db.FaturaMasters.Where(fatura => fatura.FaturaID == faturaID && fatura.MusteriID == _secilenMusteri.MusteriID).ToList();
            }

            dgvFaturalar.DataSource = _faturaMasters;
        }

        private bool CheckFaturaID()
        {
            if (string.IsNullOrWhiteSpace(tbFaturaID.Text))
                return false;

            try
            {
                Convert.ToInt32(tbFaturaID.Text);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {

            _secilenMusteri = null;
            cbMusteri.SelectedItem = null;
            tbFaturaID.Text = "";
        }

        private void dgvFaturalar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || dgvFaturalar.CurrentRow == null)
                return;

            //Satırı dolduran veriye bağlı nesneyi alır
            FaturaMaster faturaMaster = (FaturaMaster)dgvFaturalar.CurrentRow.DataBoundItem;
            FormFaturaDetay faturaDetayForm = new FormFaturaDetay(faturaMaster.faturadetay);
            faturaDetayForm.ShowDialog();
        }

        private void FormFaturaGoruntule_Load(object sender, EventArgs e)
        {

        }
    }
}
