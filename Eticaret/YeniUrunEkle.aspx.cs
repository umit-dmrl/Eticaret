using E_Ticaret_Projesi;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eticaret
{
    public partial class YeniUrunEkle : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    vt.cnn.Open();
                    SqlDataAdapter adp = new SqlDataAdapter("select * from urun_resimleri order by id desc", vt.cnn);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    listAnaResimler.DataSource = tbl.DefaultView;
                    listAnaResimler.DataBind();

                }
                catch
                {
                    Response.Write("Sistem Hatası!");
                }
                finally
                {
                    vt.cnn.Close();
                }

            }
        }

        protected void btnUrunKaydet_Click(object sender, EventArgs e)
        {
            /*bool anaresimDurumu = false;
            if (anaResim.HasFile)
            {
                string resim_adi = anaResim.FileName.ToString();
                string uzanti = Path.GetExtension(anaResim.FileName.ToString());
                Random rnd = new Random();
                int rasgele = rnd.Next(9999999);
                Response.Write(uzanti);
                anaResim.SaveAs(Server.MapPath("~/uploads/"+rasgele.ToString()+uzanti));
                anaresimDurumu = true;
            }
            else
            {
                anaresimDurumu = false;
            }*/

        }
    }
}