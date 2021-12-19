using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulOtomasyon
{
    public partial class FrmNotGiris : Form
    {
        public FrmNotGiris()
        {
            InitializeComponent();
        }

        SqlBaglantisi bgl = new SqlBaglantisi();
        Entities db = new Entities();

        void Temizle()
        {

        }
        
        /* void ogrgetir() // lookup edite ogrencı bilgilerini getırmek ıcın metod yazıldı.
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select NOTID, NOTADSOYAD, NOTTC from TBL_NOT", bgl.baglanti());
            da.Fill(dt);

            lookUpEdit1.Properties.ValueMember = "NOTID";
            lookUpEdit1.Properties.DisplayMember = "NOT AD SOYAD";
            lookUpEdit1.Properties.NullText = "Öğrenci Seçiniz";
            lookUpEdit1.Properties.DataSource = dt;


        }
        */
        void listele()
        {
          

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("Select * from TBL_NOT" , bgl.baglanti());
            da1.Fill(dt1); //tablodaki bilgilerle doldur
            GrdCtrl5.DataSource = dt1;
        }
            

        private void FrmNotGiris_Load(object sender, EventArgs e)
        {
            listele();
       
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_NOT (NOTSINIF,NOTADSOYAD,NOTTC,NOTBRANS,SINAV1,SINAV2,PROJE) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", cmbSinif.Text);
            komut.Parameters.AddWithValue("@p2", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@p3", mskTc.Text);
            komut.Parameters.AddWithValue("@p4", txtBrans.Text);
            komut.Parameters.AddWithValue("@p5", textSinav1.Text);
            komut.Parameters.AddWithValue("@p6", txtSinav2.Text);
            komut.Parameters.AddWithValue("@p7", txtProje.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
          
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update TBL_NOT set SINAV1=@p1,SINAV2=@p2,PROJE=@p3 where NOTID=@p4", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", textSinav1.Text);
            komut.Parameters.AddWithValue("@p2", txtSinav2.Text);
            komut.Parameters.AddWithValue("@p3", txtProje.Text);
            komut.Parameters.AddWithValue("@p4", txtId.Text);

            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Not Bilgileri Güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}
