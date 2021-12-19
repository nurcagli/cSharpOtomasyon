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
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OkulOtomasyon
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmGiris());
        }
    }
}
