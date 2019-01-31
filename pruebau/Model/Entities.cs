using pruebau.QueryBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebau.Model
{
    public class Entities
    {
        public static QueryTable AsQueryTable<T>()
        {
            QueryTable result = new QueryTable();
            result.SelectClause = new List<QueryElement>(); 
            var tipo = typeof(T);
            result.Name = tipo.Name;
            result.Alias = tipo.Name;
            var props = tipo.GetProperties();
            if (props != null)
            {
                foreach (System.Reflection.PropertyInfo item in props)
                {
                    if (item.IsDefined(typeof(Member), true))
                        result.SelectClause.Add(new QueryElement() { Name = item.Name, Alias = item.Name });                    
                }
            }
            return result;        
        }
        public class Member : Attribute
        {            
            public bool PrimaryKey { get; set; }
            public bool Nullable { get; set; }
            public Member(bool PrimaryKey = false, bool Nullable = true)
            {
                this.PrimaryKey = PrimaryKey;
                this.Nullable = Nullable;
            }            
        }
        public class ALUMNO
        {
            [Member(PrimaryKey: true, Nullable: false)]
            public int ID { get; set; }
            [Member]
            public string NOMBRE { get; set; }
            [Member]
            public DateTime FECHA_NAC { get; set; }
            [Member]
            public int EDAD { get; set; }
        }
    }
}
