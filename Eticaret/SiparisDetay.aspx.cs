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
    public partial class SiparisDetay : System.Web.UI.Page
    {
        Veritabani vt = new Veritabani();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    try
                    {
                        vt.cnn.Open();
                        int siparis_id = Convert.ToInt32(Request.QueryString["id"].ToString().Trim());
                        SqlCommand sorgula = new SqlCommand("select * from siparis_bilgileri where id=" + siparis_id, vt.cnn);
                        SqlDataReader oku = sorgula.ExecuteReader();
                        if (oku.Read())
                        {
                            lblKod.Text = oku["onayKodu"].ToString();
                            lblSiparisNo.Value = oku["id"].ToString();
                            lblUser.Value = oku["user_key"].ToString();
                            lblAdSoyad.Text = oku["adsoyad"].ToString();
                            lblTel.Text = oku["tel"].ToString();
                            lblEmail.Text = oku["email"].ToString();
                            lblAdres.Text = oku["adres"].ToString();

                            lblFirmaAdi.Text = oku["firmaAdi"].ToString();
                            lblFirmaAdresi.Text = oku["firmaAdresi"].ToString();
                            lblFirmaTel.Text = oku["firmaTel"].ToString();
                            lblVergiNo.Text = oku["vergiNo"].ToString();
                            oku.Close();
                            //sipariş listesini alma işlemleri
                            try
                            {
                                SqlDataAdapter adp = new SqlDataAdapter("select urunler.id,siparisler.id as siparisid,urunAdi,urunFiyati,urunTipi,urunler.urunOpKod,resimAdi,siparisler.onay from siparisler,urunler,urun_resimleri where urunler.id=siparisler.product and urunler.urunOpKod=urun_resimleri.urunOpKod and urun_resimleri.ana_resim=1 and siparisler.onay='1' and siparisler.user_key='" + lblUser.Value.ToString().Trim() + "'", vt.cnn);
                                DataTable tbl = new DataTable();
                                adp.Fill(tbl);
                                listSepetListesi.DataSource = tbl.DefaultView;
                                listSepetListesi.DataBind();
                                //toplam fiyatı hesaplat
                                SqlCommand toplam_fiyat = new SqlCommand("select urunFiyati from siparisler,urunler where urunler.id=siparisler.product and user_key='" + lblUser.Value.ToString().Trim() + "'", vt.cnn);
                                SqlDataReader fiyatlar = toplam_fiyat.ExecuteReader();
                                int toplam = 0;
                                while (fiyatlar.Read())
                                {
                                    toplam += Convert.ToInt32(fiyatlar["urunFiyati"].ToString().Trim());
                                }
                                txtToplam.Text = toplam.ToString() + " TL";
                                fiyatlar.Close();
                            }
                            catch (Exception ex)
                            {
                                Response.Write("Sistem Hatası ! " + ex);
                                //Response.Redirect("~/Default.aspx");
                            }
                           
                        }
                        else
                        {
                            message.InnerHtml = "<div class='alert alert-error'><i class='fa fa-warning'></i> Sipariş Bulunamadı.</div>";
                        }
                        SqlCommand siparis_durumu = new SqlCommand("select durum from siparis_durumlari where siparis_id=" + lblSiparisNo.Value.ToString().Trim(), vt.cnn);
                        SqlDataReader siparis_durumu_oku = siparis_durumu.ExecuteReader();
                        if (siparis_durumu_oku.Read())
                        {
                            durumu_goster.ForeColor = System.Drawing.Color.Green;
                            durumu_goster.Text = "Seçilen Durum : "+siparis_durumu_oku["durum"].ToString().Trim();
                        }else
                        {
                            durumu_goster.ForeColor = System.Drawing.Color.Orange;
                            durumu_goster.Text = "Henüz Sipariş Durumu Belirtilmedi!";
                        }
                    }
                    catch (FormatException ex)
                    {
                        message.InnerHtml = "<div class='alert alert-error'><i class='fa fa-warning'></i> Uygunsuz Formatta Değer Geldi Ve İşlem Yapılmadı.</div>";
                    }
                    catch (Exception ex)
                    {
                        Response.Write("hata:" + ex);
                    }
                    finally
                    {
                        vt.cnn.Close();
                    }
                    
                }
                else
                {
                    Response.Redirect("~/YonetimPaneli.aspx");
                }
            }
        }

        protected void btnDurumGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                vt.cnn.Open();
                SqlCommand sorgula = new SqlCommand("select siparis_id from siparis_durumlari where siparis_id="+lblSiparisNo.Value.ToString().Trim(),vt.cnn);
                SqlDataReader oku = sorgula.ExecuteReader();
                bool state = oku.Read() ;
                oku.Close();
                if(state==true)
                {
                    //güncelleme yap
                    Response.Write("var");
                    //oku.Close();
                    SqlCommand guncelle = new SqlCommand("update siparis_durumlari set durum='"+durum.SelectedItem.Value.ToString().Trim()+"' where siparis_id="+lblSiparisNo.Value.ToString().Trim(),vt.cnn);
                    guncelle.ExecuteNonQuery();

                }else
                {
                    Response.Write("yok");
                    //ekleme yap
                    SqlCommand ekle = new SqlCommand("insert into siparis_durumlari (siparis_id,durum) values ("+lblSiparisNo.Value.ToString().Trim()+",'"+ durum.SelectedItem.Value.ToString().Trim() + "')",vt.cnn);
                    ekle.ExecuteNonQuery();
                    
                }
            }catch(Exception ex)

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