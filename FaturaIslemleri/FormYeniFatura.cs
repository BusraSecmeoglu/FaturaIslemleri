using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaturaIslemleri
{
    public partial class FormYeniFatura : Form
    {
        private FaturaContext _db;
        private Musteri _secilenMusteri;
        private Urun _secilenUrun;
        private HashSet<FaturaDetay> _faturaDetaylari;
        private int _faturaID;
        private FaturaDetay _secilenFaturaDetay;

        public FormYeniFatura()
        {
            InitializeComponent();

            Initialize();
        }

        private void Initialize()
        {
            _db = new FaturaContext();
            _secilenMusteri = null;
            _secilenUrun = null;
            _faturaDetaylari = new HashSet<FaturaDetay>();
            _secilenFaturaDetay = null;

            dgvYeniFatura.DataSource = _faturaDetaylari;

            FaturaDetay fatura = _db.FaturaDetays.ToList().LastOrDefault();
            _faturaID = fatura == null ? 1 : fatura.FaturaID;
            lblFaturaID.Text = _faturaID.ToString();

            cbUrunAdi.DisplayMember = "UrunAdi";
            cbUrunAdi.ValueMember = "UrunID";
            cbUrunAdi.DataSource = _db.Urunler.ToList();

            cbMusteriSehir.DisplayMember = "Aciklama";
            cbMusteriSehir.ValueMember = "IlId";
            cbMusteriSehir.DataSource = _db.Iller.ToList();
            cbMusteriSehir.Enabled = false;

            cbMusteriIlce.DisplayMember = "Aciklama";
            cbMusteriIlce.ValueMember = "IlceId";
            cbMusteriIlce.DataSource = _db.Ilceler.ToList();
            cbMusteriIlce.Enabled = false;

            cbMusteri.DisplayMember = "MusteriUnvani";
            cbMusteri.ValueMember = "MusteriID";
            cbMusteri.DataSource = _db.Musteriler.ToList();
        }

        private void cbMusteriSehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMusteri.SelectedIndex == -1)
                return;

            _secilenMusteri = (Musteri)cbMusteri.SelectedItem;
            cbMusteriIlce.SelectedItem = _secilenMusteri.ilce;
            cbMusteriSehir.SelectedItem = _secilenMusteri.ilce.il;
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            if (!CheckUrunInputs())
                return;

            decimal kdv = Convert.ToDecimal(txtUrunKDV.Text);
            int adet = (int)nudUrunMiktar.Value;
            decimal toplam = (adet * _secilenUrun.BirimFiyat) + (adet * _secilenUrun.BirimFiyat * kdv / 100);

            FaturaDetay fatura = new FaturaDetay();
            fatura.FaturaID = _faturaID;
            fatura.urun = _secilenUrun;

            FaturaDetay urun = _faturaDetaylari.FirstOrDefault(f => f.UrunID == _secilenUrun.UrunID && f.FaturaID == _faturaID);
            if (urun == null)
            {
                fatura.UrunID = _secilenUrun.UrunID;
                fatura.Miktar = adet;
                /*fatura.ToplamFiyat = adet * _secilenUrun.BirimFiyat;
                fatura.KDV = kdv;
                fatura.KDVliFiyat = _secilenUrun.BirimFiyat + (adet * _secilenUrun.BirimFiyat * kdv / 100);
                fatura.GenelToplam = fatura.KDVliFiyat * fatura.Miktar;*/
            }
            else
            {
                fatura = urun;
                fatura.Miktar += adet;
                /*fatura.ToplamFiyat = fatura.Miktar * _secilenUrun.BirimFiyat;
                fatura.KDV = kdv;
                fatura.KDVliFiyat = _secilenUrun.BirimFiyat + (adet * _secilenUrun.BirimFiyat * kdv / 100);
                fatura.GenelToplam = fatura.KDVliFiyat * fatura.Miktar;*/
            }

            fatura.ToplamFiyat = fatura.Miktar * _secilenUrun.BirimFiyat;
            fatura.KDV = kdv;
            fatura.KDVliFiyat = _secilenUrun.BirimFiyat + (_secilenUrun.BirimFiyat * kdv / 100);
            fatura.GenelToplam = fatura.KDVliFiyat * fatura.Miktar;

            _faturaDetaylari.Add(fatura);
            ClearUrunInputs();
        }

        private void ClearUrunInputs()
        {
            _secilenFaturaDetay = null;
            nudUrunMiktar.Value = 1;
            txtUrunKDV.Text = "";
            dgvYeniFatura.DataSource = _faturaDetaylari.ToList();
            lblFaturaToplam.Text = _faturaDetaylari.Select(f => f.GenelToplam).Sum().ToString();
        }

        private bool CheckUrunInputs()
        {
            if (cbUrunAdi.SelectedItem == null)
                return false;

            if (_db.Urunler.ToList().FirstOrDefault(u => u.UrunID == (int)cbUrunAdi.SelectedValue) == null)
                return false;

            if (nudUrunMiktar.Value <= 0)
                return false;

            try
            {
                decimal kdv = Convert.ToDecimal(txtUrunKDV.Text);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void cbUrunAdi_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbUrunAdi.SelectedIndex == -1)
                return;

            _secilenUrun = (Urun)cbUrunAdi.SelectedItem;
            txtUrunBirimi.Text = _secilenUrun.Birim.BirimAdi;
            txtUrunFiyati.Text = _secilenUrun.BirimFiyat.ToString();
        }

        private void dgvYeniFatura_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1 || dgvYeniFatura.CurrentRow == null)
                return;

            _secilenFaturaDetay = (FaturaDetay)dgvYeniFatura.CurrentRow.DataBoundItem;
            cbUrunAdi.SelectedItem = _secilenFaturaDetay.urun;
            txtUrunKDV.Text = _secilenFaturaDetay.KDV.ToString();
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            if (_secilenFaturaDetay == null)
                return;

            DialogResult result = MessageBox.Show($"{_secilenFaturaDetay.urun.UrunAdi} adlı ürünü silmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                _faturaDetaylari.Remove(_secilenFaturaDetay);
                ClearUrunInputs();
            }
        }

        private void btnFaturaKaydet_Click(object sender, EventArgs e)
        {
            if (!CheckFaturaInputs())
                return;

            FaturaMaster faturaMaster = new FaturaMaster()
            {
                FaturaID = _faturaID,
                faturadetay = _faturaDetaylari,
                FaturaTarihi = DateTime.Now,
                IrsaliyeNo = Convert.ToInt32(txtIrsaliyeNo.Text),
                MusteriID = _secilenMusteri.MusteriID,
                OdemeTarihi = dtpOdemeTarihi.Value,
                FaturaToplam = _faturaDetaylari.Select(f => f.GenelToplam).Sum()
            };

            //Transaction işlemlerin hepsi başarılı olduğunda “Transaction” Commit (Onaylama)komutu çalışır ve değişiklikler veritabanında gerçekleşmiş olur. Eğer herhangi bir hata oluşursa bu işleyiş bozulur ve hepsi geri alınır o zamanda “transaction” Rollback (Geridönüş) komutu çalışır. Böylece tüm işlemler geri alınır ve en başa dönülür. Bunu yaparak veri kaybetme olasılığımız da sıfıra iner. 


            //Begin Transaction komutu yeni bir transaction başlatır. İşlemleri onaylamak için veya iptal etmek için Commit veya Rollback komutunu beklemeye koyuluyor.
            DbContextTransaction tran = _db.Database.BeginTransaction();

            try
            {
                _db.FaturaMasters.Add(faturaMaster);
                _db.SaveChanges();
                ClearFaturaInputs();
                
                //Commit Transaction komutu begin Transaction ile başlayan bütün işleri onaylar. Zaten bir transaction gerçekleşmişse ardından mutlaka Commit transaction gelmesi gerekir. 
                tran.Commit();
            }
            catch (Exception)
            {
                //Rollback Transaction komutu Begin ile başlatılan işlemlerin hepsini iptal eder.
                tran.Rollback();
                MessageBox.Show("Beklenmeyen bir hata meydana geldi");
            }

        }

        private void ClearFaturaInputs()
        {
            txtIrsaliyeNo.Text = "";
            ClearDgvYeniFatura();

            FaturaDetay fatura = _db.FaturaDetays.ToList().LastOrDefault();
            //fatura null'sa 1 değilse fatura.FaturaID'sini _faturaID'ye atar.
            _faturaID = fatura == null ? 1 : fatura.FaturaID;
            lblFaturaID.Text = _faturaID.ToString();

            ClearUrunInputs();
        }

        private void ClearDgvYeniFatura()
        {
            _faturaDetaylari = new HashSet<FaturaDetay>();
            dgvYeniFatura.DataSource = _faturaDetaylari;
        }

        private bool CheckFaturaInputs()
        {
            if (_secilenMusteri == null)
                return false;

            if (_faturaDetaylari.Count < 1)
                return false;

            if (string.IsNullOrWhiteSpace(txtIrsaliyeNo.Text))
                return false;

            if (dtpOdemeTarihi.Value == null)
                return false;

            try
            {
                Convert.ToInt32(txtIrsaliyeNo.Text);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void btnListeTemizle_Click(object sender, EventArgs e)
        {
            ClearDgvYeniFatura();
        }

        private void cbMusteri_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMusteri.SelectedIndex == -1)
                return;

            _secilenMusteri = (Musteri)cbMusteri.SelectedItem;
            cbMusteriIlce.SelectedItem = _secilenMusteri.ilce;
            cbMusteriSehir.SelectedItem = _secilenMusteri.ilce.il;
        }
    }
}
