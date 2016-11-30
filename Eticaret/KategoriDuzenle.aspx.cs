using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace E_Ticaret_Projesi
{
    public partial class KategoriDuzenle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"].ToString().Trim();
                    Veritabani vt = new Veritabani();
                    try
                    {
                        vt.cnn.Open();
                        SqlCommand komut = new SqlCommand("select * from kategoriler where id=" + id, vt.cnn);
                        SqlDataReader oku = komut.ExecuteReader();
                        if (oku.Read())
                        {
                            TextBox1.Text = oku["kategoriAdi"].ToString();
                            lblID.Text = oku["id"].ToString();
                            if (oku["onay"].ToString().Trim() == "1")
                            {
                                CheckBox1.Checked = true;
                            }
                            else
                            {
                                CheckBox1.Checked = false;
                            }
                        }
                        else
                        {
                            Response.Write("Kayıt Bulunamadı!");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Hata ! : " + ex);
                    }
                    finally
                    {
                        vt.cnn.Close();
                    }
                }
                else
                {
                    Response.Redirect("~/KategoriListesi.aspx");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Veritabani vt2 = new Veritabani();
            try
            {
                string durum = "1";
                if (CheckBox1.Checked == true)
                {
                    durum = "1";
                }
                else
                {
                    durum = "0";
                }
                SqlCommand komut = new SqlCommand("UPDATE kategoriler SET kategoriAdi='"+TextBox1.Text+"',onay='"+durum+"' where id="+lblID.Text, vt2.cnn);
                vt2.cnn.Open();
                komut.ExecuteNonQuery();
                Response.Redirect("~/KategoriListesi.aspx?mesaj=success");
            }
            catch (Exception ex)
            {
                Response.Write("Hata : "+ex);
            }
            finally
            {
                vt2.cnn.Close();
            }
            
        }
    }
}