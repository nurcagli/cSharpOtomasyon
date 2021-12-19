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
using System.Data.SqlClient;

namespace OkulOtomasyon
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        Entities db = new Entities();


        /* //ögrenci girisi icin
        private void btnOgrenci_Click(object sender, EventArgs e)
        {
            var sorgu = from d1 in db.TBL_OGRAYARLAR
                        join d2 in db.TBL_OGRENCILER
                        on d1.AYARLAROGRID equals d2.OGRID
                        where d2.OGRTC == MskTc.Text && d1.OGRSIFRE == txtSifre.Text
                        select new { }; // olusan verıyı kullanmayacagımız ıcın boyle ıcı bos süslü parantez kullanıldı.


            if (sorgu.Any()) //herhangı bır sonuc donerse
            {
                FrmOgrencilerAnaModul frm3 = new FrmOgrencilerAnaModul();
                frm3.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı veya Şifre");
                MskTc.Text = "";
                txtSifre.Text = "";
            }
            
        } 
        */

        private void btnOgretmen_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select OGRTTC,OGRTSIFRE from TBL_AYARLAR inner join TBL_OGRETMENLER on TBL_AYARLAR.AYARLARID=TBL_OGRETMENLER.OGRTID where OGRTTC=@p1 and OGRTSIFRE=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", MskTc.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read()) // dogru ıse anamodulu acar.
            {
                FrmAnaModul frm1 = new FrmAnaModul();
                frm1.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Kullanıcı veya Şifre");
                MskTc.Text = "";
                txtSifre.Text = "";
            }
            bgl.baglanti().Close();
        }

    

       
    }
}
