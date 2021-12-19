/*
 SAKARYA ÜNİVERSİTESİ
 BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
 BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
 NESNEYE DAYALI PROGRAMLAMA DERSİ
 2021-2022 GÜZ DÖNEMİ

 ÖDEV NUMARASI..........: 4.Ödev
 ÖĞRENCİ ADI............:Rabia Nur Çağlı
 ÖĞRENCİ NUMARASI.......:B201210350
 DERSİN ALINDIĞI GRUP...: 1.ÖĞRETİM A GRUBU
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulOtomasyon
{
    public partial class FrmVeliler : Form
    {
        //entity framework ile yapılacak.
        public FrmVeliler()
        {
            InitializeComponent();
        }

        Entities db = new Entities();  // verileri entity framework ıle cekıcez. bundan dolayı sqldataclient kütüphanesini eklememize gerek yok.
       
        void listele()
        {
            // bu ıslemı gridwiew2 nin gorunurlugunu false yaparak da gerceklestırebılırdık.
            var query = from item in db.TBL_VELILER
                        select new { item.VELIID, item.VELIANNE, item.VELIBABA, item.VELITEL, item.VELITEL2, item.VELIMAIL };  // iliskili oldugu tablonun verısını almamak ıcın boyle bır sorgu tanımladık.
            gridControl2.DataSource = query.ToList(); // db nesnesı ıle velıler tablosuna ulasıyoruz tolıst ıle de bılgılerı lıstelıyoruz.
        }

        void temizle() 
        {
            txtId.Text = "";
            txtAnneAd.Text = "";
            txtBabaAd.Text = "";
            mskTel1.Text = "";
            mskTel2.Text = "";
            txtMail.Text = "";

        }
        private void FrmVeliler_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            TBL_VELILER veli = new TBL_VELILER();
            veli.VELIANNE = txtAnneAd.Text;
            veli.VELIBABA = txtBabaAd.Text;
            veli.VELITEL = mskTel1.Text;
            veli.VELITEL2 = mskTel2.Text;
            veli.VELIMAIL = txtMail.Text;
            db.TBL_VELILER.Add(veli);
            db.SaveChanges();
            listele();
            temizle();

        }

        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {//ilgili satırı focusladıgımızda textboxlara bılgıler tasınacak.Böylece guncelleme ıslemını yapmamız kolaylasacak.
            txtId.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "VELIID").ToString();
            txtAnneAd.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "VELIANNE").ToString();
            txtBabaAd.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "VELIBABA").ToString();
            mskTel1.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "VELITEL").ToString();
            mskTel2.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "VELITEL2").ToString();
            txtMail.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "VELIMAIL").ToString();

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "VELIID").ToString() ); //string olarak alınan ıd degerını ıntegera ceviriyoruz.
            var item = db.TBL_VELILER.Find(id);
            item.VELIANNE = txtAnneAd.Text;
            item.VELIBABA = txtBabaAd.Text;
            item.VELITEL = mskTel1.Text;
            item.VELITEL2 = mskTel2.Text;
            item.VELIMAIL = txtMail.Text;
            db.SaveChanges();
            listele();
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "VELIID").ToString()); //string olarak alınan ıd degerını ıntegera ceviriyoruz.
            var item = db.TBL_VELILER.Find(id);
            db.TBL_VELILER.Remove(item);
            db.SaveChanges();
            listele();
            temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();

        }
    }
}
