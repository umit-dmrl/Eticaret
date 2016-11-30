using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace E_Ticaret_Projesi
{
    public class Veritabani
    {
        public SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings[0].ConnectionString);
        public bool ekle(string sql)
        {
            try
            {
                cnn.Open();
                SqlCommand komut = new SqlCommand(sql, cnn);
                komut.ExecuteNonQuery();
                cnn.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public SqlDataReader kategoriler(string sql)
        {
            SqlCommand komut = new SqlCommand(sql,cnn);
            SqlDataReader dr = komut.ExecuteReader();
            return dr;
        }
        public int sil(string table, string kosul)
        {
            
            SqlCommand komut = new SqlCommand("select * from " + table + " where " + kosul,cnn);
            SqlDataReader oku = komut.ExecuteReader();
            if (oku.Read())
            {
                try
                {
                    SqlCommand komut_sil = new SqlCommand("delete from " + table + " where id=" , cnn);
                    komut_sil.ExecuteNonQuery();
                    return 1;
                }
                catch
                {
                    return 2;
                }
            }
            else
            {
                return 0;
            }
            
        }
    }
}