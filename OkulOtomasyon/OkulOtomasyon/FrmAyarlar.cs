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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }
        SqlBaglantisi bgl = new SqlBaglantisi();
        Entities db = new Entities(); // entity framework eklemek ıcın olusturdugumuz sınıftan db nesnesını olusturduk.

        //ADO.NET OGRETMEN SIFRE BILGILERI
        void listele()
        {
            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Execute AyarlarOgretmenler",bgl.baglanti()); // procedure yazıldı
            da1.Fill(dt1);
            gridControl1.DataSource = dt1;
        }

        //ENTITY FRAMEWORK ILE OGRENCI LISTELEME
        void ogrlistele() // ekledıgımız proceduru kullanıcaz.
        {
            gridControl2.DataSource = db.AyarlarOgrenciler(); // ayarlarOgrencıler verıtabanından yukledıgımız procedurdur.
            listele();
        }



        //ADO.NET ILE LOOKUPEDIT ARACINA VERI GETIRME
        void ogretmenListesi()
        {
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Select OGRTID,(OGRTAD+' '+OGRTSOYAD) as 'OGRTADSOYAD',OGRTBRANS from TBL_OGRETMENLER",bgl.baglanti());
            da2.Fill(dt2);
            lookUpEdit1.Properties.ValueMember = "OGRTID";
            lookUpEdit1.Properties.DisplayMember = "OGRTADSOYAD";
            lookUpEdit1.Properties.NullText = "Öğretmen Seçiniz";
            lookUpEdit1.Properties.DataSource = dt2;
        }

        // entity framework ıle lookupedıte ogrencı verılerını getırme
        void ogrencilistesi()
        {
            var deger = from item in db.TBL_OGRENCILER
                        select new
                        {
                            OGRID = item.OGRID,
                            OGRADSOYAD = item.OGRAD + " " + item.OGRSOYAD,
                            OGRSINIF = item.OGRSINIF,

                        };
            //lookupeditin arayuzunde gorunecek kısımlar
            lookUpEdit2.Properties.ValueMember = "OGRID";
            lookUpEdit2.Properties.DisplayMember = "OGRADSOYAD";
            lookUpEdit2.Properties.NullText = "Öğrenci Seçiniz";
            lookUpEdit2.Properties.DataSource = deger.ToList();


        }
        void temizle()
        {
            txtOgrtId.Text = "";
            txtOgrtBrans.Text = "";
            txtOgrtSifre.Text = "";
            mskOgrtTc.Text = "";
            pictureEdit1.Text = "";
            lookUpEdit1.Text = "";
            lookUpEdit1.Properties.NullText = "Öğretmen Seçiniz";


            txtOgrId.Text = "";
            txtOgrSinif.Text = "";
            txtOgrSifre.Text = "";
            txtOgrTc.Text = "";
            pictureEdit2.Text = "";
            lookUpEdit2.Text = "";
            lookUpEdit2.Properties.NullText = "Öğrenci Seçiniz";
        }

        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
            ogretmenListesi();
            ogrlistele();
            ogrencilistesi();

          
        }   
         
       
        //ADO.NET ILE GRIDCONTROL VERILERINI ARACLARA TASIMA
        public string yeniyol;

        private void gridView1_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if(dr!=null) //satırları null degılse getır
            {   //procedurun sutunları getırılıyor.prosedur yazmasaydık ogretmenın sutunlarını dıkkate alırdık.Suan grıdcontrole ıkı tablonun elemanları yuklenıyor.Inner joınle bırlestırdıgımız ıkı tablonun elemanları..
                txtOgrtId.Text = dr["AYARLARID"].ToString();
                lookUpEdit1.Text = dr["OGRTADSOYAD"].ToString();
                txtOgrtBrans.Text = dr["OGRTBRANS"].ToString();
                mskOgrtTc.Text = dr["OGRTTC"].ToString();
                txtOgrtSifre.Text = dr["OGRTSIFRE"].ToString();
                yeniyol = " C:\\Users\\rabii\\OneDrive\\Masaüstü\\cSharpOtomasyon\\OkulOtomasyon\\OkulOtomasyon" + "\\Resimler\\"+ dr["OGRTFOTO"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
            }
        }

        //ADONET ILE LOOKUP EDIT SECIMI SONRASI DEGİSİKLİK
        //ogretmen secımı sonrasında ona daır bılgılerın dıger araclara tasınması.
        private void lookUpEdit1_Properties_EditValueChanged(object sender, EventArgs e)
        {
            txtOgrtSifre.Text = "";
            SqlCommand komut = new SqlCommand("Select * from TBL_OGRETMENLER where OGRTID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1",lookUpEdit1.ItemIndex + 1); //ıtemındex 0 dan basladıgı ıcın +1 yapıyoruz.
            SqlDataReader dr3 = komut.ExecuteReader();
            while (dr3.Read()) // satır satır okurken satırları ıdye gore çek
            {
                txtOgrtId.Text = dr3["OGRTID"].ToString();
                txtOgrtBrans.Text = dr3["OGRTBRANS"].ToString();
                mskOgrtTc.Text = dr3["OGRTTC"].ToString();
                yeniyol = " C:\\Users\\rabii\\OneDrive\\Masaüstü\\cSharpOtomasyon\\OkulOtomasyon\\OkulOtomasyon" + "\\Resimler\\" + dr3["OGRTFOTO"].ToString();
                pictureEdit1.Image = Image.FromFile(yeniyol);
            }
            bgl.baglanti().Close();                     
        }

        // entity framework ıle lookupedıt secımı sonrası yenı kısnın bılgılerının araclara tasınması
        private void lookUpEdit2_Properties_EditValueChanged(object sender, EventArgs e)
        {
            txtOgrSifre.Text = "";
            using (Entities db = new Entities())
            {
                TBL_OGRENCILER sorgu = db.TBL_OGRENCILER.Find(lookUpEdit2.ItemIndex + 1);
                txtOgrId.Text = sorgu.OGRID.ToString();
                txtOgrSinif.Text = sorgu.OGRSINIF;
                txtOgrTc.Text = sorgu.OGRTC;
                yeniyol = " C:\\Users\\rabii\\OneDrive\\Masaüstü\\cSharpOtomasyon\\OkulOtomasyon\\OkulOtomasyon" + "\\Resimler\\" + sorgu.OGRFOTO;
                pictureEdit2.Image = Image.FromFile(yeniyol);
            }
        }

        //ADONET ILE OGRETMENLER ICIN SIFRE KAYDET
        private void btnOgrtKaydet_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("insert into TBL_AYARLAR (AYARLARID,OGRTSIFRE) values (@p1,@p2)", bgl.baglanti());
            komut2.Parameters.AddWithValue("@p1", txtOgrtId.Text);
            komut2.Parameters.AddWithValue("@p2", txtOgrtSifre.Text);
            komut2.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şifre oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        //adonet ıle ogretmen sıfre guncelleme
        private void btnOgrtGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut3 = new SqlCommand("update TBL_AYARLAR set OGRTSIFRE=@p1 where AYARLARID=@p2",bgl.baglanti());
            komut3.Parameters.AddWithValue("@p1",txtOgrtSifre.Text);
            komut3.Parameters.AddWithValue("@p2", txtOgrtId.Text);
            komut3.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şifre Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
            temizle();

        }


        //gridview içindekı verılerı ogrencı bılgılerı kısmındakı araclara tasıma ıslemi
        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
                                                          //gridviewdekı sutunlar ne ıse onları yazıyoruz.
            txtOgrId.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "AYARLAROGRID").ToString();
            lookUpEdit2.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRADSOYAD").ToString();
            txtOgrSinif.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRSINIF").ToString();
            txtOgrTc.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRTC").ToString();
            txtOgrSifre.Text = gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRSIFRE").ToString();
            string uzanti= gridView2.GetRowCellValue(gridView2.FocusedRowHandle, "OGRFOTO").ToString();
            yeniyol = " C:\\Users\\rabii\\OneDrive\\Masaüstü\\cSharpOtomasyon\\OkulOtomasyon\\OkulOtomasyon" + "\\Resimler\\" + uzanti;
            pictureEdit2.Image = Image.FromFile(yeniyol);
        }

        private void btnOgrKaydet_Click(object sender, EventArgs e)
        {
            TBL_OGRAYARLAR komut = new TBL_OGRAYARLAR();
            komut.AYARLAROGRID = Convert.ToInt32(txtOgrId.Text);
            komut.OGRSIFRE = txtOgrSifre.Text;
            db.TBL_OGRAYARLAR.Add(komut);
            db.SaveChanges();
            MessageBox.Show("Şifre Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ogrlistele();
            temizle();

        }

        private void btnOgrGuncelle_Click(object sender, EventArgs e)
        {

            // lookupeditten secim yapinca sifre guncellenmiyor
            //int id = Convert.ToInt32(gridView2.GetRowCellValue(gridView2.FocusedRowHandle,"AYARLAROGRID"));
            //var item = db.TBL_OGRAYARLAR.FirstOrDefault(x => x.AYARLAROGRID == id);
            //item.OGRSIFRE = txtOgrSifre.Text;
            //db.SaveChanges();
            //MessageBox.Show("Şifre Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            //ogrlistele();
            //temizle();

            SqlCommand komut4 = new SqlCommand("update TBL_OGRAYARLAR set OGRSIFRE=@p1 where AYARLAROGRID=@p2", bgl.baglanti());
            komut4.Parameters.AddWithValue("@p1", txtOgrSifre.Text);
            komut4.Parameters.AddWithValue("@p2", txtOgrId.Text);
            komut4.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Şifre Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ogrlistele();
            temizle();


        }

        private void btnOgrTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void btnOgrtTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
