using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebau.QueryBuilder
{
    public class QueryTable
    {
        public List<QueryElement> SelectClause { get; set; }
        public List<QueryTable> FromClause { get; set; }
        public QueryStatement WhereClause { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string GetQueryFrom()
        {
            string result = "";
            if (Name != null)
            {
                result = $" {Name} as {Alias} ";                
            }
            else
            {
                result = $"({GetQuery()}) as {Alias}";
            }
            return result;
        }
        public string GetQuery()
        {
            string result = "";
            if (Name != null)
            {
                result = "select ";
                result += string.Join(" , ", SelectClause.Select(x => x.GetQuery()));
                result += $" from {Name} as {Alias} ";
                result += string.Join(" , ", FromClause.Select(x => $"{x.Name} as [{x.Alias}]"));
                result += " " + WhereClause.GetQuery();
            }
            else
            {
                result = "select ";
                result += string.Join(" , ", SelectClause.Select(x => x.GetQuery()));
                result += $" from " + string.Join(" , ", FromClause.Select(x => x.GetQueryFrom())); ;
                result += string.Join(" , ", FromClause.Select(x => $"{x.Name} as [{x.Alias}]"));
                result += " " + WhereClause.GetQuery();
            }
            return result;
        } 
    }
}
