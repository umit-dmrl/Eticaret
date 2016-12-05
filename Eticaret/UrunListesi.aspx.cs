using E_Ticaret_Projesi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eticaret
{
    public partial class UrunListesi : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                vt.cnn.Open();
                SqlDataAdapter adaptor = new SqlDataAdapter("select urunler.id,urunAdi,urunTipi,resimAdi,urunFiyati,kategoriAdi from urunler,urun_resimleri,kategoriler where urunler.urunOpKod=urun_resimleri.urunOpKod and ana_resim=1 and kategoriler.id=urunler.kategoriID", vt.cnn);
                DataTable tbl = new DataTable();
                adaptor.Fill(tbl);
                listUrunler.DataSource = tbl.DefaultView;
                listUrunler.DataBind();
            }
            catch(Exception ex)
            {
                Response.Write("Sistem Hatası! : <br>"+ex);
            }
            finally
            {
                vt.cnn.Close();
            }
        }
    }
}