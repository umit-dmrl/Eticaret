using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using E_Ticaret_Projesi;

namespace Eticaret
{
    public partial class SepeteEkle : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();
        protected void Page_Load(object sender, EventArgs e)
        {
                if (Request.QueryString["product"] != null)
                {
                    try
                    {
                        vt.cnn.Open();
                        int product = Convert.ToInt32(Request.QueryString["product"].ToString());
                        SqlCommand urun_sorgula = new SqlCommand("select * from urunler where id=" + product, vt.cnn);
                        SqlDataReader urun_oku = urun_sorgula.ExecuteReader();
                        if (urun_oku.Read())
                        {
                            urun_oku.Close();
                            try
                            {
                                SqlCommand sepete_ekle = new SqlCommand("insert into siparisler (user_key,product,onay,tarih) values ('" + Session["site_userid"].ToString().Trim() + "'," + product + ",0,'" + Convert.ToDateTime(DateTime.Now.ToShortDateString()) + "')", vt.cnn);
                                sepete_ekle.ExecuteNonQuery();
                                Response.Redirect("~/SepetListesi.aspx?islem=success");
                            }
                            catch (Exception ex)
                            {
                                Response.Write("Sistem Hatası(2) !"+ex);
                                //Response.Redirect("~/SepetListesi.aspx?islem=error");
                            }

                        }
                        else
                        {
                            //Response.Write("ürün bulunamadı!");
                            Response.Redirect("~/Default.aspx");
                        }
                    }
                    catch (FormatException ex)
                    {
                        Response.Write("Format Hatası!"+ex);
                        //Response.Redirect("~/Default.aspx");
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Sistem Hatası! "+ ex);
                        //Response.Redirect("~/Default.aspx");
                    }
                    finally
                    {
                        vt.cnn.Close();
                    }
                }
                else
                {
                    Response.Write("ürün seçilmedi");
                    //Response.Redirect("~/Default.aspx");
                }
        }
    }
}