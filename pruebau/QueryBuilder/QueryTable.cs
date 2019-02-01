using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebau.QueryBuilder
{
    public class Query
    {
        public List<QueryElement> SelectClause { get; set; }
        public List<Query> FromClause { get; set; }
        public QueryStatement WhereClause { get; set; }
        public string Alias { get; set; }
        public string Name { get; set; }
        public string GetQueryFrom()
        {
            string result = "";
            if (Name != null)
            {
                result = $" {Name} as {Alias ?? Name} ";                
            }
            else
            {
                result = $"({GetQuery()}) as {Alias ?? Name}";
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
                if (FromClause != null)
                    result += string.Join(" , ", FromClause.Select(x => $"{x.Name} as [{x.Alias ?? x.Name}]"));
                if (WhereClause != null)
                    result += " " + WhereClause.GetQuery();
            }
            else
            {
                result = "select ";
                result += string.Join(" , ", SelectClause.Select(x => x.GetQuery()));
                result += $" from " + string.Join(" , ", FromClause.Select(x => x.GetQueryFrom())); ;
                result += string.Join(" , ", FromClause.Select(x => $"{x.Name} as [{x.Alias ?? x.Name}]"));
                if (WhereClause != null)
                    result += " " + WhereClause.GetQuery();
            }
            return result;
        } 
    }
}
