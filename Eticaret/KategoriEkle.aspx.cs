using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace E_Ticaret_Projesi
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        Veritabani db = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            string kategoriAdi = txtKategoriAdi.Text.Trim().ToString();
            int onay_durumu=0;
            if(onay.Checked==true)
            {
                onay_durumu=1;
            }else{
                onay_durumu=0;
            }
            string komut = "insert into kategoriler (kategoriAdi,onay) values ('"+kategoriAdi+"','"+onay_durumu+"')";
            bool durum = db.ekle(komut);
            if (durum == true)
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Kategori Kaydedildi...";
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Maroon;
                lblMessage.Text = "Hata! Bir Hata Nedeniyle İşlem Başarısız Oldu!";
            }
        }
    }
}