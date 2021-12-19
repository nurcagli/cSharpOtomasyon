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
    public partial class FrmOgrenciler : Form
    {
        public FrmOgrenciler()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();

        void listele()
        {
            //5.SINIF
            DataTable dt1 = new DataTable(); 
            SqlDataAdapter da1 = new SqlDataAdapter("Execute Ogrenciveli5",bgl.baglanti()); // verıtabanında execute ettıgımız 5.sınıflar ıcın olan stored proceduru kullanılıyoruz.
            da1.Fill(dt1);
            GrdCtrl5.DataSource = dt1;

            //6.SINIF
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("Execute Ogrenciveli6", bgl.baglanti());// verıtabanında execute ettıgımız 6.sınıflar ıcın olan stored proceduru kullanılıyoruz.
            da2.Fill(dt2);
            GrdCtrl6.DataSource = dt2;

            //7.SINIF
            DataTable dt3 = new DataTable();
            SqlDataAdapter da3 = new SqlDataAdapter("Execute Ogrenciveli7", bgl.baglanti()); // verıtabanında execute ettıgımız 7.sınıflar ıcın olan stored proceduru kullanılıyoruz.
            da3.Fill(dt3);
            GrdCtrl7.DataSource = dt3;

            //8.SINIF
            DataTable dt4 = new DataTable();
            // SqlDataAdapter da4 = new SqlDataAdapter("Select * from TBL_OGRENCILER where OGRSINIF='8.SINIF'", bgl.baglanti()); // tabloları bırlestırmeden oncekı sorgu.
            SqlDataAdapter da4 = new SqlDataAdapter("Execute Ogrenciveli8", bgl.baglanti()); // verıtabanında execute ettıgımız 8.sınıflar ıcın olan stored proceduru kullanılıyoruz.
            da4.Fill(dt4);
            GrdCtrl8.DataSource = dt4;

        }
        void velilistesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select VELIID,(VELIANNE+' | '+VELIBABA) AS 'VELI ANNE BABA' from TBL_VELILER", bgl.baglanti());
            da.Fill(dt);

            lookUpEdit1.Properties.ValueMember = "VELIID";
            lookUpEdit1.Properties.DisplayMember = "VELI ANNE BABA";
            lookUpEdit1.Properties.DataSource = dt;
        }




        void sehirEkle()
        {
            SqlCommand komut = new SqlCommand(" Select * from TBL_ILLER",bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read()) // tum satırı okuyorken
            {
                cmbIl.Properties.Items.Add(dr[1]); // bu combobox devexpresın cmbsı oldugu ıcın propertıes kelımesını kullandık.
                //tablonun 1.sutununda ıller var 

            }
            bgl.baglanti().Close();
        }
        void temizle()
        {
            txtId.Text = "";
            txtAd.Text = "";
            txtSoyad.Text = "";
            mskOgrenciNo.Text = "";
            mskTc.Text = "";
            rdbErkek.Checked = false;
            rdbKadin.Checked = false;
            cmbSinif.Text = "";
            cmbIl.Text = "";
            cmbIlce.Text="";
            dateEdit1.Text = "";
            richAdres.Text = "";
            PcrOgrenci.Text = "";

        }
        
       

        private void FrmOgrenciler_Load_1(object sender, EventArgs e)
        {
            listele();
            sehirEkle();
            temizle();
            velilistesi();
        }

        private void cmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbIlce.Properties.Items.Clear();
            cmbIlce.Text = "";

            SqlCommand komut = new SqlCommand("Select * from TBL_ILCELER where sehir=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbIl.SelectedIndex + 1); // tabloda ıller bırden basladıgı ıcın ındex+1 dıyoruz cunku ındex 0 dan baslıyor.
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                cmbIlce.Properties.Items.Add(dr[1]); // ilce tablonun 1.sutununda oldugu ıcın.
                           }
            bgl.baglanti().Close();
        }

        private void gridView3_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        { // tablodakı verılerın ögrenci bilgi kısmına aktarılması ıcın gerektı kodlar
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);

            if(dr!=null)
            {
                txtId.Text = dr["OGRID"].ToString();
                txtAd.Text = dr["OGRAD"].ToString();
                txtSoyad.Text = dr["OGRSOYAD"].ToString();
                mskTc.Text = dr["OGRTC"].ToString();
                mskOgrenciNo.Text = dr["OGRNO"].ToString();
                cmbSinif.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCINSIYET"].ToString() == "E")
                {
                    rdbErkek.Checked = true;
                }
                else
                {
                    rdbKadin.Checked = true;
                }
                cmbIl.Text = dr["OGRIL"].ToString();
                cmbIlce.Text = dr["OGRILCE"].ToString();
                dateEdit1.Text = dr["OGRDOGTAR"].ToString();
                richAdres.Text = dr["OGRADRES"].ToString();
                yeniyol = "C:\\Users\\rabii\\OneDrive\\Masaüstü\\cSharpOtomasyon\\OkulOtomasyon\\OkulOtomasyon" + "\\Resimler\\" + dr["OGRFOTO"].ToString();
                PcrOgrenci.Image = Image.FromFile(yeniyol);
                lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();

            }
        }

        public string cinsiyet; 
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_OGRENCILER (OGRAD,OGRSOYAD,OGRNO,OGRSINIF,OGRDOGTAR,OGRCINSIYET,OGRTC,OGRIL,OGRILCE,OGRADRES,OGRFOTO,OGRVELIID) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12)",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3",mskOgrenciNo.Text);
            komut.Parameters.AddWithValue("@p4",cmbSinif.Text);
            komut.Parameters.AddWithValue("@p5",dateEdit1.Text);
            if (rdbErkek.Checked==true) {
                //radiobutton erkek secili olursa
                komut.Parameters.AddWithValue("@p6",cinsiyet="E");
            }
            else
            {
                komut.Parameters.AddWithValue("@p6", cinsiyet="K");

            }
            komut.Parameters.AddWithValue("@p7",mskTc.Text);
            komut.Parameters.AddWithValue("@p8",cmbIl.Text);
            komut.Parameters.AddWithValue("@p9",cmbIlce.Text);
            komut.Parameters.AddWithValue("@p10",richAdres.Text);
            komut.Parameters.AddWithValue("@p11", Path.GetFileName(yeniyol));
            komut.Parameters.AddWithValue("@p12", lookUpEdit1.EditValue);           
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci Eklendi.","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void gridView2_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            // tablodakı verılerın ögrenci bilgi kısmına aktarılması ıcın gerektı kodlar
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);

            if (dr != null)
            {
                txtId.Text = dr["OGRID"].ToString();
                txtAd.Text = dr["OGRAD"].ToString();
                txtSoyad.Text = dr["OGRSOYAD"].ToString();
                mskTc.Text = dr["OGRTC"].ToString();
                mskOgrenciNo.Text = dr["OGRNO"].ToString();
                cmbSinif.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCINSIYET"].ToString() == "E")
                {
                    rdbErkek.Checked = true;
                }
                else
                {
                    rdbKadin.Checked = true;
                }
                cmbIl.Text = dr["OGRIL"].ToString();
                cmbIlce.Text = dr["OGRILCE"].ToString();
                dateEdit1.Text = dr["OGRDOGTAR"].ToString();
                richAdres.Text = dr["OGRADRES"].ToString();
                yeniyol = "C:\\Users\\rabii\\OneDrive\\Masaüstü\\cSharpOtomasyon\\OkulOtomasyon\\OkulOtomasyon" + "\\Resimler\\" + dr["OGRFOTO"].ToString();
                PcrOgrenci.Image = Image.FromFile(yeniyol);
                lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();
            }
        }

        private void gridView4_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            // tablodakı verılerın ögrenci bilgi kısmına aktarılması ıcın gerektı kodlar
            DataRow dr = gridView4.GetDataRow(gridView4.FocusedRowHandle);

            if (dr != null)
            {
                txtId.Text = dr["OGRID"].ToString();
                txtAd.Text = dr["OGRAD"].ToString();
                txtSoyad.Text = dr["OGRSOYAD"].ToString();
                mskTc.Text = dr["OGRTC"].ToString();
                mskOgrenciNo.Text = dr["OGRNO"].ToString();
                cmbSinif.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCINSIYET"].ToString() == "E")
                {
                    rdbErkek.Checked = true;
                }
                else
                {
                    rdbKadin.Checked = true;
                }
                cmbIl.Text = dr["OGRIL"].ToString();
                cmbIlce.Text = dr["OGRILCE"].ToString();
                dateEdit1.Text = dr["OGRDOGTAR"].ToString();
                richAdres.Text = dr["OGRADRES"].ToString();
                yeniyol = "C:\\Users\\rabii\\OneDrive\\Masaüstü\\cSharpOtomasyon\\OkulOtomasyon\\OkulOtomasyon" + "\\Resimler\\" + dr["OGRFOTO"].ToString();
                PcrOgrenci.Image = Image.FromFile(yeniyol);
                lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();
            }
        }

       

        private void gridView5_FocusedRowObjectChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowObjectChangedEventArgs e)
        {
            // tablodakı verılerın ögrenci bilgi kısmına aktarılması ıcın gerektı kodlar
            DataRow dr = gridView5.GetDataRow(gridView5.FocusedRowHandle);

            if (dr != null)
            {
                txtId.Text = dr["OGRID"].ToString();
                txtAd.Text = dr["OGRAD"].ToString();
                txtSoyad.Text = dr["OGRSOYAD"].ToString();
                mskTc.Text = dr["OGRTC"].ToString();
                mskOgrenciNo.Text = dr["OGRNO"].ToString();
                cmbSinif.Text = dr["OGRSINIF"].ToString();
                if (dr["OGRCINSIYET"].ToString() == "E")
                {
                    rdbErkek.Checked = true;
                }
                else
                {
                    rdbKadin.Checked = true;
                }
                cmbIl.Text = dr["OGRIL"].ToString();
                cmbIlce.Text = dr["OGRILCE"].ToString();
                dateEdit1.Text = dr["OGRDOGTAR"].ToString();
                richAdres.Text = dr["OGRADRES"].ToString();
                yeniyol = "C:\\Users\\rabii\\OneDrive\\Masaüstü\\cSharpOtomasyon\\OkulOtomasyon\\OkulOtomasyon" + "\\Resimler\\" + dr["OGRFOTO"].ToString();
                PcrOgrenci.Image = Image.FromFile(yeniyol);
                lookUpEdit1.Text = dr["VELIANNEBABA"].ToString();
            }
        }

        private void groupControl2_Paint(object sender, PaintEventArgs e)
        {

        }
        public string yeniyol;//bırcok yerde kullanılacagından dolayı publıc tanımlandı.
        private void btnResimSec_Click(object sender, EventArgs e)
        {
            OpenFileDialog dosya = new OpenFileDialog();
            dosya.Filter = "Resim Dosyası |*.jpeg;*.png;*.nef| Tüm Dosyalar |*.*";
            dosya.ShowDialog(); //fşledşalogu actık
            string dosyayolu = dosya.FileName;
            yeniyol = "C:\\Users\\rabii\\OneDrive\\Masaüstü\\cSharpOtomasyon\\OkulOtomasyon\\OkulOtomasyon" + "\\Resimler\\" + Guid.NewGuid().ToString() + ".jpeg"; // benzersız olması ıcın wuıd kullanıldı.
            File.Copy(dosyayolu, yeniyol); // dosyayolundan yenı yola aktarıyoruz.
            PcrOgrenci.Image = Image.FromFile(yeniyol);


        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_OGRENCILER set OGRAD=@p1,OGRSOYAD=@p2,OGRNO=@p3,OGRSINIF=@p4,OGRDOGTAR=@p5,OGRCINSIYET=@p6,OGRTC=@p7,OGRIL=@p8,OGRILCE=@p9,OGRADRES=@p10,OGRFOTO=@p11,OGRVELIID=@p13 where OGRID=@p12",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskOgrenciNo.Text);
            komut.Parameters.AddWithValue("@p4", cmbSinif.Text);
            komut.Parameters.AddWithValue("@p5", dateEdit1.Text);
            if (rdbErkek.Checked == true)
            {
                //radiobutton erkek secili olursa
                komut.Parameters.AddWithValue("@p6", cinsiyet = "E");
            }
            else
            {
                komut.Parameters.AddWithValue("@p6", cinsiyet = "K");

            }
            komut.Parameters.AddWithValue("@p7", mskTc.Text);
            komut.Parameters.AddWithValue("@p8", cmbIl.Text);
            komut.Parameters.AddWithValue("@p9", cmbIlce.Text);
            komut.Parameters.AddWithValue("@p10", richAdres.Text);
            komut.Parameters.AddWithValue("@p11", Path.GetFileName(yeniyol));
            komut.Parameters.AddWithValue("@p12", txtId.Text);
            komut.Parameters.AddWithValue("@p13", lookUpEdit1.EditValue);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci Bilgileri Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            temizle();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand(" Delete from TBL_OGRENCILER where OGRID=@p1",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Öğrenci Bilgileri Silindi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView3_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            //nufuscuzdanı formuna ulasmamız lazım. frm nesnesı olusturuyoruz.
            FrmNufusCuzdani frm = new FrmNufusCuzdani();
            if (dr!= null)
            {

                frm.ad = dr["OGRAD"].ToString();
                frm.soyad = dr["OGRSOYAD"].ToString();
                frm.tc = dr["OGRTC"].ToString();
                frm.cinsiyet = dr["OGRCINSIYET"].ToString();
                frm.dogtarihi = dr["OGRDOGTAR"].ToString();
                frm.uzanti= "C:\\Users\\rabii\\OneDrive\\Masaüstü\\cSharpOtomasyon\\OkulOtomasyon\\OkulOtomasyon" + "\\Resimler\\" + dr["OGRFOTO"].ToString();
           
            }
            frm.Show();

        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            //nufuscuzdanı formuna ulasmamız lazım. frm nesnesı olusturuyoruz.
            FrmNufusCuzdani frm = new FrmNufusCuzdani();
            if (dr != null)
            {

                frm.ad = dr["OGRAD"].ToString();
                frm.soyad = dr["OGRSOYAD"].ToString();
                frm.tc = dr["OGRTC"].ToString();
                frm.cinsiyet = dr["OGRCINSIYET"].ToString();
                frm.dogtarihi = dr["OGRDOGTAR"].ToString();
                frm.uzanti = "C:\\Users\\rabii\\OneDrive\\Masaüstü\\cSharpOtomasyon\\OkulOtomasyon\\OkulOtomasyon" + "\\Resimler\\" + dr["OGRFOTO"].ToString();

            }
            frm.Show();
        }

        private void gridView4_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            //nufuscuzdanı formuna ulasmamız lazım. frm nesnesı olusturuyoruz.
            FrmNufusCuzdani frm = new FrmNufusCuzdani();
            if (dr != null)
            {

                frm.ad = dr["OGRAD"].ToString();
                frm.soyad = dr["OGRSOYAD"].ToString();
                frm.tc = dr["OGRTC"].ToString();
                frm.cinsiyet = dr["OGRCINSIYET"].ToString();
                frm.dogtarihi = dr["OGRDOGTAR"].ToString();
                frm.uzanti = "C:\\Users\\rabii\\OneDrive\\Masaüstü\\cSharpOtomasyon\\OkulOtomasyon\\OkulOtomasyon" + "\\Resimler\\" + dr["OGRFOTO"].ToString();

            }
            frm.Show();
        }

        private void gridView5_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = gridView3.GetDataRow(gridView3.FocusedRowHandle);
            //nufuscuzdanı formuna ulasmamız lazım. frm nesnesı olusturuyoruz.
            FrmNufusCuzdani frm = new FrmNufusCuzdani();
            if (dr != null)
            {

                frm.ad = dr["OGRAD"].ToString();
                frm.soyad = dr["OGRSOYAD"].ToString();
                frm.tc = dr["OGRTC"].ToString();
                frm.cinsiyet = dr["OGRCINSIYET"].ToString();
                frm.dogtarihi = dr["OGRDOGTAR"].ToString();
                frm.uzanti = "C:\\Users\\rabii\\OneDrive\\Masaüstü\\cSharpOtomasyon\\OkulOtomasyon\\OkulOtomasyon" + "\\Resimler\\" + dr["OGRFOTO"].ToString();

            }
            frm.Show();
        }

        
    }
}
