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
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }

        FrmOgretmenler frm1;
        FrmOgrenciler frm2;
        FrmVeliler frm3;
        FrmAyarlar frm4;
        FrmNotGiris frm5;

        private void btnOgretmen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm1 == null || frm1.IsDisposed)
            {  // form acıksa tekrar acma veya kapatınca tekrar ac
                frm1 = new FrmOgretmenler();
                frm1.MdiParent = this; // anaforma koydugumuz mdi paranti kullanarak bu forma aktarım saglıyoruz.
                frm1.Show();
            }
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm2 == null || frm2.IsDisposed)
            {  // form acıksa tekrar acma veya kapatınca tekrar ac
                frm2 = new FrmOgrenciler();
                frm2.MdiParent = this; // anaforma koydugumuz mdi paranti kullanarak bu forma aktarım saglıyoruz.
                frm2.Show();
            }
        }

        private void btnVeliler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm3 == null || frm3.IsDisposed)
            {  // form acıksa tekrar acma veya kapatınca tekrar ac
                frm3 = new FrmVeliler();
                frm3.MdiParent = this; // anaforma koydugumuz mdi paranti kullanarak bu forma aktarım saglıyoruz.
                frm3.Show();
            }
        }

        private void btnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm4 == null || frm4.IsDisposed)
            {  // form acıksa tekrar acma veya kapatınca tekrar ac
                frm4 = new FrmAyarlar();
                frm4.MdiParent = this; // anaforma koydugumuz mdi paranti kullanarak bu forma aktarım saglıyoruz.
                frm4.Show();
            }
        }

        private void btnNotGiris_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm5 == null || frm5.IsDisposed)
            {  // form acıksa tekrar acma veya kapatınca tekrar ac
                frm5 = new FrmNotGiris();
                frm5.MdiParent = this; // anaforma koydugumuz mdi paranti kullanarak bu forma aktarım saglıyoruz.
                frm5.Show();
            }
        }
    }
}
