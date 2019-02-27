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
        public class Entity
        {
            public string Name { get; set; }
            public List<Field> props { get; set; }
            public Query AsQuery()
            {
                Query result = new Query();
                result.Select = new List<QueryElement>();
                result.PreSelect = new List<QueryElement>();
                result.Name = Name;
                if (props != null)             
                    foreach (Field item in props)
                        result.PreSelect.Add(new QueryElement() { Name = item.Name, Alias = item.Name });
                return result;
            }
        }
        public static Query AsQuery<T>()
        {
            Query result = new Query();
            result.Select = new List<QueryElement>();
            var tipo = typeof(T);
            result.Name = tipo.Name;
            result.Alias = tipo.Name;
            var props = tipo.GetProperties();
            if (props != null)
            {
                foreach (System.Reflection.PropertyInfo item in props)
                {
                    if (item.IsDefined(typeof(Member), true))
                        result.Select.Add(new QueryElement() { Name = item.Name, Alias = item.Name });                  
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
        public class ALUMNO : Entity
        {
            public ALUMNO()
            {
                Name = "ALUMNO";
                props.Add(new Field("ID", true, true));
                props.Add(new Field("NOMBRE"));
                props.Add(new Field("FECHA_NAC"));
                props.Add(new Field("EDAD"));
            }
            public Field ID { get { return props.FirstOrDefault(x => x.Name == "ID"); } }
            public Field NOMBRE { get { return props.FirstOrDefault(x => x.Name == "NOMBRE"); } }
            public Field FECHA_NAC { get { return props.FirstOrDefault(x => x.Name == "FECHA_NAC"); } }
            public Field EDAD { get { return props.FirstOrDefault(x => x.Name == "EDAD"); } }
            /*
            [Member(PrimaryKey: true, Nullable: false)]
            public int ID { get; set; }
            [Member]
            public string NOMBRE { get; set; }
            [Member]
            public DateTime FECHA_NAC { get; set; }
            [Member]
            public int EDAD { get; set; }

            public Field id
            {
                get
                {
                    return new Field("ID", true, true);
                }
            }*/
        }
    }

    public class Field
    {
        public bool PrimaryKey { get; set; }
        public bool Nullable { get; set; }
        public string Name { get; set; }
        public object Value { get; set; }

        public Field(string Name, bool PrimaryKey = false, bool Nullable = true)
        {
            this.Name = Name;
            this.PrimaryKey = PrimaryKey;
            this.Nullable = Nullable;
        }
    }
}
