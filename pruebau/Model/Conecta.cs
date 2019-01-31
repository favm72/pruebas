using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebau.Model
{
    public class Conecta
    {
        public static void Conectar(Action<SqlConnection> accion)
        {
            string con_str = ConfigurationManager.ConnectionStrings["mydata"].ConnectionString;
            con_str = "data source=(LocalDB)\\MSSQLLocalDB;attachdbfilename=C:\\Users\\usrprdsolnegmo\\Desktop\\RepoPruebas\\pruebau\\Data\\mydata.mdf;integrated security=True;connect timeout=30;MultipleActiveResultSets=True;";
            using (var con = new SqlConnection(con_str))
            {
                con.Open();
                accion(con);
                con.Close();
            }
        }
        public static void Ejecutar(string query)
        {
            Conectar(con => {
                var tran = con.BeginTransaction();
                try
                {                    
                    var cmd = new SqlCommand(query, con, tran);
                    cmd.CommandType = System.Data.CommandType.Text;                    
                    cmd.ExecuteNonQuery();
                    tran.Commit();
                }
                catch (Exception)
                {
                    tran.Rollback();
                    throw;
                }
            });
        }
        public static List<T> Obtener<T>(string query, Func<SqlDataReader,T> mapper)
        {
            List<T> result = new List<T>();
            Conectar(con => {               
                var cmd = new SqlCommand(query, con);
                cmd.CommandType = System.Data.CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.HasRows && dr.Read())
                    {
                        T obj = mapper(dr);
                        result.Add(obj);
                    }
                }                
            });
            return result;
        }
    }
}
