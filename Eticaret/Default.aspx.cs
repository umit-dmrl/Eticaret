using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using E_Ticaret_Projesi;
using System.Data.SqlClient;
using System.Data;

namespace Eticaret
{
    public partial class Default : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
            string user_key = "";
            if (Session["site_userid"] != null)
            {
                user_key = Session["site_userid"].ToString();
            }else
            {
                //ziyaretçi için oturum aç
                Session["site_userid"] = System.Guid.NewGuid().ToString();
                user_key = Session["site_userid"].ToString();
            }

            try
            {
                vt.cnn.Open();
                SqlDataAdapter komut = new SqlDataAdapter("select urunler.id,urunAdi,urunFiyati,urunTipi,resimAdi from urunler,urun_resimleri where urunler.urunOpKod=urun_resimleri.urunOpKod and urun_resimleri.ana_resim=1 order by urunler.id desc", vt.cnn);
                DataTable tbl = new DataTable();
                komut.Fill(tbl);
                listSonUrunler.DataSource = tbl.DefaultView;
                listSonUrunler.DataBind();

                SqlDataAdapter kampanyali = new SqlDataAdapter("select urunler.id,urunAdi,urunFiyati,urunTipi,resimAdi from urunler,urun_resimleri where urunler.urunOpKod=urun_resimleri.urunOpKod and urun_resimleri.ana_resim=1 and urunler.urunTipi=3 order by urunler.id desc", vt.cnn);
                DataTable tblKampanyali = new DataTable();
                kampanyali.Fill(tblKampanyali);
                listKampanyaliUrunler.DataSource = tblKampanyali.DefaultView;
                listKampanyaliUrunler.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("Sistem Hatası !"+ex);
            }
            finally
            {
                vt.cnn.Close();
            }
        }
    }
}