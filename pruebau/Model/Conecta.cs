using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using static pruebau.Model.Entities;

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
        public static List<T> Obtener<T>(QueryBuilder.Query query) where T : new()
        {
            List<T> result = new List<T>();
            Conectar(con => {               
                var cmd = new SqlCommand(query.GetQuery(), con);
                cmd.CommandType = System.Data.CommandType.Text;
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.HasRows && dr.Read())
                    {
                        T obj = Mapper<T>(dr, query.Select);
                        result.Add(obj);
                    }
                }                
            });
            return result;
        }

        public static T Mapper<T>(SqlDataReader dr, List<QueryBuilder.QueryElement> stmnt) where T : new()
        {          
            T result = new T();
            Type tipo = typeof(T);
            PropertyInfo[] props = tipo.GetProperties();
            if (props != null)
            {
                foreach (PropertyInfo item in props)
                {
                    if (item.IsDefined(typeof(Member), true))
                    {
                        object[] attrs = item.GetCustomAttributes(true);
                        var mbr = attrs.Where(x => typeof(Member) == x.GetType()).FirstOrDefault() as Member;
                        string alias = stmnt.Where(x => x.Name == item.Name).Select(x => x.Alias).FirstOrDefault();
                        
                        item.SetValue(result, dr[alias]);                        
                    }
                }
            }
            return result;
        }
    }
}
