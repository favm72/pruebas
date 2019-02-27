using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebau.QueryBuilder
{
    public class Query
    {
                public List<QueryElement> PreSelect { get; set; }
        public List<QueryElement> Select { get; set; }
        public List<Query> From { get; set; }
        public QueryStatement Where { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string GetFrom()
        {
            if (Name != null)
                return $"({GetQuery()}) as {Alias}";
            else
                return $"{Name} as {Alias}";
        }
       public string GetQuery()
        {
            string result = "";         
            result = "select";
            result += string.Join(",\n", Select.Select(x => x.GetQuery()));
            result += $"\nfrom " + string.Join(",\n", From.Select(x => x.GetFrom()));
            result += string.Join(",\n", From.Select(x => $"{x.Name} as [{x.Alias}]"));
            if (Where != null)
                result += $"\n{Where.GetQuery()};";           
            return result;
        }

        internal void addFrom(Query table)
        {
            if (From == null)
                From = new List<Query>();
            if (From.Count == 0)
            {
                if (table.Name == null) // es query
                {
                    From.Add(table);
                }
                else // es tabla
                {
                    From = table.From;
                    PreSelect = table.PreSelect;
                }
            }
            else
            {
                From.Add(table);
            }
        }
    }
}
