using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using E_Ticaret_Projesi;

namespace E_Ticaret_Projesi
{
    public partial class YonetimPaneli : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                vt.cnn.Open();
                SqlCommand siparisler = new SqlCommand("select count(id) as toplam from siparis_bilgileri",vt.cnn);
                SqlDataReader siparis_oku = siparisler.ExecuteReader();
                if(siparis_oku.Read())
                {
                    lblToplamSiparis.Text = siparis_oku["toplam"].ToString();
                }
                siparis_oku.Close();
                SqlCommand kategoriler = new SqlCommand("select count(id) as toplam from kategoriler", vt.cnn);
                SqlDataReader kategoriler_oku = kategoriler.ExecuteReader();
                if(kategoriler_oku.Read())
                {
                    lblToplamKategori.Text = kategoriler_oku["toplam"].ToString();
                }
                kategoriler_oku.Close();
                SqlCommand urunler = new SqlCommand("select count(id) as toplam from urunler", vt.cnn);
                SqlDataReader urunler_oku = urunler.ExecuteReader();
                if (urunler_oku.Read())
                {
                    lblToplamUrunSayisi.Text = urunler_oku["toplam"].ToString();
                }
                urunler_oku.Close();
            }
            catch(Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                vt.cnn.Close();
            }
        }
    }
}