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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ilEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIl il = new FormIl();
            il.Show();
        }

        private void ilçeEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormIlce ilce = new FormIlce();
            ilce.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void birimEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBirim brm = new FormBirim();
            brm.Show();
        }

        private void urunEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormUrun urun = new FormUrun();
            urun.Show();
        }

        private void müşteriEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMusteri musteri = new FormMusteri();
            musteri.Show();
        }

        private void görüntüleSorgulaDüzenleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFaturaGoruntule formFaturaGoruntule = new FormFaturaGoruntule();
            formFaturaGoruntule.Show();
        }

        private void yeniFaturaOluşturToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormYeniFatura formYeniFatura = new FormYeniFatura();
            formYeniFatura.Show();
        }
    }
}
