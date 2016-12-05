using E_Ticaret_Projesi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using System.Data;

namespace Eticaret
{
    public partial class UrunResimleriYukle : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    vt.cnn.Open();
                    SqlDataAdapter adp = new SqlDataAdapter("select * from yuklenen_urun_resimleri order by id desc",vt.cnn);
                    DataTable tbl = new DataTable();
                    adp.Fill(tbl);
                    listResimler.DataSource = tbl.DefaultView;
                    listResimler.DataBind();

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

        protected void btnTopluSil_Click(object sender, EventArgs e)
        {
            foreach(ListViewDataItem item in listResimler.Items)
            {
                CheckBox check = item.FindControl("secim") as CheckBox;
                if(check != null)
                {
                    if (check.Checked == true)
                    {
                        HiddenField hiden = item.FindControl("resimID") as HiddenField;
                        Response.Write(hiden.Value+",");
                    }
                }
            }
        }
    }
}