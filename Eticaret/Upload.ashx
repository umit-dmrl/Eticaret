<%@ WebHandler Language="C#" Class="Upload" %>

using System;
using System.Web;
using System.IO;
using System.Data.SqlClient;

public class Upload : IHttpHandler
{

    public void ProcessRequest(HttpContext context)
    {
        context.Response.ContentType = "text/plain";
        context.Response.Expires = -1;
        try
        {
            HttpPostedFile postedFile = context.Request.Files["Filedata"];
            string id = context.Request["id"];
            string savepath = "";
            string tempPath = "";

            tempPath = context.Request["folder"];


            savepath = context.Server.MapPath(tempPath);
            string filename = postedFile.FileName;
            if (!Directory.Exists(savepath))
                Directory.CreateDirectory(savepath);
            string ext = System.IO.Path.GetExtension(filename);
            string resimGuid = Guid.NewGuid().ToString();

            if (ext == ".BMP" || ext == ".jpeg" || ext==".JPEG" || ext == ".jpg" || ext==".JPG" || ext==".png" || ext==".PNG")
            {
                postedFile.SaveAs(savepath + @"\" + resimGuid  + ext);
            }



            SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings[0].ConnectionString);

            string url = context.Request.Path;

            
            try
            {
                SqlCommand command = new SqlCommand("Insert Into urun_resimleri (ResimAdi) values(@ResimAdi)", conn);
                command.Parameters.AddWithValue("@ResimAdi", resimGuid + ext);
                conn.Open();
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                context.Response.Write(ex.ToString()); 
            }
            finally
            {
                conn.Close();
                context.Response.Write("İşlem Bitti.");
                context.Response.StatusCode = 200;
            }
        }
        catch (Exception ex)
        {
            context.Response.Write("Error: " + ex.Message);
        }
    }

    public bool IsReusable
    {
        get
        {
            return false;
        }
    }
}