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
using System.IO;

namespace OkulOtomasyon
{
    public partial class FrmOgretmenler : Form
    {
        public FrmOgretmenler()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi(); // baglanti sinifindan nesne olusturuyoruz.Sınıfın ıcerısınde baglantıyı actıgımız ıcın sureklı baglantı.open dememıze gerek kalmıyor.

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_OGRETMENLER",bgl.baglanti());
            da.Fill(dt); //tablodaki bilgilerle doldur
            gridControl2.DataSource = dt;
        }

        void ilEkle ()
        {
            SqlCommand komut = new SqlCommand("Select * from TBL_ILLER",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();  //her satırı tek tek okutuyoruz.
            while (dr.Read())
            {
                cmbIl.Properties.Items.Add(dr[1]); //sutun 1 sehrın ısım kısmı,comboboxa ısım getırecegımız ıcın. devexpresin comboboxı oldugu ıcın propertıes ıfadesı daha eklıyoruz.
            }
            bgl.baglanti().Close();
        }
        void bransGetir()
        {
            SqlCommand komut = new SqlCommand("Select * from TBL_BRANSLAR", bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();  //her satırı tek tek okutuyoruz.
            while (dr.Read())
            {
                cmbBrans.Properties.Items.Add(dr[1]); //sutun 1 sehrın ısım kısmı,comboboxa ısım getırecegımız ıcın. devexpresin comboboxı oldugu ıcın propertıes ıfadesı daha eklıyoruz.
            }
            bgl.baglanti().Close();

        }
        void Temizle()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskTc.Text = "";
            mskTelefon.Text = "";
            cmbIl.Text = "";
            cmbIlce.Text = "";
            cmbBrans.Text = "";
            txtMail.Text = "";
            richAdres.Text = "";
            yeniyol = "";
        }

        private void FrmOgretmenler_Load(object sender, EventArgs e)
        {
            listele();
            ilEkle();
            bransGetir();

        }

        private void mskTc_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Properties.Items.Clear();
            cmbIlce.Text = " ";
            SqlCommand komut = new SqlCommand("Select * from TBL_ILCELER where sehir=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbIl.SelectedIndex+1); // parametre belirtiliyor. selectedındex 0 dan ıllerımız ıse 1 den basladıgı ıcın +1 yazıyoruz.
            SqlDataReader dr = komut.ExecuteReader(); // ssatır satır okuyacagız.
            while (dr.Read())
            {
                cmbIlce.Properties.Items.Add(dr[1]);
            }
            bgl.baglanti().Close();

        }

        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e) // satırlara tıklanınca bılgılerı bılgı metın kutucuklarına tasır.böylece kokayca guncelleme yapılabılır.
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                txtId.Text = dr["OGRTID"].ToString();
                txtAd.Text = dr["OGRTAD"].ToString();
                txtSoyad.Text = dr["OGRTSOYAD"].ToString();
                mskTc.Text = dr["OGRTTC"].ToString();
                mskTelefon.Text = dr["OGRTTEL"].ToString();
                cmbIl.Text = dr["OGRTIL"].ToString();
                cmbIlce.Text = dr["OGRTILCE"].ToString();
                cmbBrans.Text = dr["OGRTBRANS"].ToString();
                txtMail.Text = dr["OGRTMAIL"].ToString();
                richAdres.Text = dr["OGRTADRES"].ToString();
                yeniyol = "C:\\Users\\rabii\\OneDrive\\Masaüstü\\cSharpOtomasyon\\OkulOtomasyon\\OkulOtomasyon" + "\\Resimler\\" + dr["OGRTFOTO"].ToString();
                pcrResim.Image = Image.FromFile(yeniyol);
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_OGRETMENLER (OGRTAD,OGRTSOYAD,OGRTTC,OGRTTEL,OGRTMAIL,OGRTIL,OGRTILCE,OGRTADRES,OGRTBRANS,OGRTFOTO) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTc.Text);
            komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmbIl.Text);
            komut.Parameters.AddWithValue("@p7", cmbIlce.Text);
            komut.Parameters.AddWithValue("@p8", richAdres.Text);
            komut.Parameters.AddWithValue("@p9", cmbBrans.Text);
            komut.Parameters.AddWithValue("@p10", Path.GetFileName(yeniyol));
            //komut.Parameters.AddWithValue("@p10", Path.GetFileName(yeniyol));
            komut.ExecuteNonQuery(); //ekleme,silme ve guncelleme islemlerinde degisiklikler yaptıgımız ıcın executenonquery metodunu cagırmamız gerekıyor.
            bgl.baglanti().Close();
            MessageBox.Show("Personel Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele(); // son halini listelemesi icin
        }

       

      
        public string yeniyol;

        private void btnResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpeg;*.png;*.nef| Tüm Dosyalar |*.*";
            dosya.ShowDialog(); //fşledşalogu actık
            string dosyayolu = dosya.FileName;
            yeniyol = "C:\\Users\\rabii\\OneDrive\\Masaüstü\\cSharpOtomasyon\\OkulOtomasyon\\OkulOtomasyon" + "\\Resimler\\" + Guid.NewGuid().ToString() + ".jpeg"; // benzersız olması ıcın wuıd kullanıldı.
            File.Copy(dosyayolu, yeniyol); // dosyayolundan yenı yola aktarıyoruz.
            pcrResim.Image = Image.FromFile(yeniyol);
            
        }

        private void pcrResim_Click(object sender, EventArgs e)
        {

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_OGRETMENLER set OGRTAD=@p1,OGRTSOYAD=@p2,OGRTTC=@p3 ,OGRTTEL=@p4,OGRTMAIL=@p5,OGRTIL=@p6,OGRTILCE=@p7,OGRTADRES=@p8,OGRTBRANS=@p9,OGRTFOTO=@p10 where OGRTID=@p11",bgl.baglanti()); // sql baglanti sınıfından baglantı metodu cagrılıyor.
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTc.Text);
            komut.Parameters.AddWithValue("@p4", mskTelefon.Text);
            komut.Parameters.AddWithValue("@p5", txtMail.Text);
            komut.Parameters.AddWithValue("@p6", cmbIl.Text);
            komut.Parameters.AddWithValue("@p7", cmbIlce.Text);
            komut.Parameters.AddWithValue("@p8", richAdres.Text);
            komut.Parameters.AddWithValue("@p9", cmbBrans.Text);
            komut.Parameters.AddWithValue("@p10", Path.GetFileName(yeniyol)); 
            komut.Parameters.AddWithValue("@p11", txtId.Text);
            komut.ExecuteNonQuery(); //ekleme,silme ve guncelleme islemlerinde degisiklikler yaptıgımız ıcın executenonquery metodunu cagırmamız gerekıyor.
            bgl.baglanti().Close();
            MessageBox.Show("Personel Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele(); // degisiklikleri görmek ıcın lıstele'yı tekrar cagırıyoruz.
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Delete from TBL_OGRETMENLER where OGRTID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Personel Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele(); // degisiklikleri görmek ıcın lıstele'yı tekrar cagırıyoruz.
       
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void gridControl2_Click(object sender, EventArgs e)
        {

        }
    }
}
