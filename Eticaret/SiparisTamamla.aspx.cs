using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_Ticaret_Projesi;
using System.Data.SqlClient;

namespace Eticaret
{
    public partial class SiparisTamamla : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                vt.cnn.Open();
                SqlCommand komut = new SqlCommand("select count(siparisler.id) as sayac from siparisler,urunler where urunler.id=siparisler.product and user_key='" + Session["site_userid"].ToString().Trim() + "'", vt.cnn);
                SqlDataReader oku = komut.ExecuteReader();
                int sayac = 0;
                if(oku.Read())
                {
                    sayac = Convert.ToInt32(oku["sayac"].ToString());
                }else
                {
                    Response.Write("~/Default.aspx");
                }
                if(sayac==0)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }catch(Exception ex)
            {
                Response.Write(ex);
                Response.Redirect("~/Default.aspx");
            }
            finally
            {
                vt.cnn.Close();
            }
        }

        protected void btnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                vt.cnn.Open();
                Random rnd = new Random();
                int rasgele = rnd.Next(100,9999999); 
                //SqlCommand komut = new SqlCommand("insert into siparis_bilgileri (user_key,adsoyad,tel,email,adres,firmaAdi,firmaTel,vergiNo,firmaAdresi,onayKodu) values ('" + Session["site_userid"].ToString().Trim() + "','" + txtAdSoyad.Text.ToString().Trim() + "','" + txtTel.ToString().Trim() + "','" + txtEposta.ToString().Trim() + "','" + txtAdres.Text.ToString().Trim() +"','"+txtFirmaAdi.Text.ToString().Trim()+"','"+txtFirmaTel.Text.ToString().Trim()+"','"+txtVergiNo.Text.ToString().Trim()+"','"+txtFirmaAdresi.ToString().Trim()+"','"+rasgele.ToString()+"')", vt.cnn);
                SqlCommand komut = new SqlCommand("insert into siparis_bilgileri (user_key,adsoyad,tel,email,adres,firmaAdi,firmaTel,vergiNo,firmaAdresi,onayKodu) values ('" + Session["site_userid"].ToString().Trim() + "','" + txtAdSoyad.Text.ToString().Trim() + "','" + txtTel.Text.ToString().Trim() + "','" + txtEposta.Text.ToString().Trim() + "','" + txtAdres.Text.ToString().Trim() + "','" + txtFirmaAdi.Text.ToString().Trim() + "','" + txtFirmaTel.Text.ToString().Trim() + "','" + txtVergiNo.Text.ToString().Trim() + "','" + txtFirmaAdresi.Text.ToString().Trim() + "','" + rasgele.ToString() + "')", vt.cnn);
                komut.ExecuteNonQuery();
                //Sipariş tablosundaki ürünleri onaylama işlemi
                SqlCommand guncelle = new SqlCommand("update siparisler set onay='1' where user_key='"+ Session["site_userid"].ToString().Trim() + "'",vt.cnn);
                guncelle.ExecuteNonQuery();
                Response.Redirect("~/SiparisOnayMesaji.aspx?kod="+rasgele);
            }
            catch(Exception ex)
            {
                Response.Write("Sistem Hatası : "+ex);
            }
            finally
            {
                vt.cnn.Close();
            }
        }
    }
}