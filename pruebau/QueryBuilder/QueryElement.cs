using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebau.QueryBuilder
{
    public class QueryElement
    {
        public string Name { get; set; }
        public string Alias { get; set; }
        public string GetQuery()
        {
            //if (this.GetType() == typeof(QueryTable))
            //{
            //    return $"{(QueryTable)this}"
            //}
            return $"{Name} as [{Alias}]";
        }
    }
}
