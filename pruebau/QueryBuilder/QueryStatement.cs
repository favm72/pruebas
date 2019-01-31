using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebau.QueryBuilder
{
    public class QueryStatement
    {
        public string JoinOperator { get; set; }
        public List<QueryStatement> Statements { get; set; }
        public string ComparisonOperator { get; set; }
        public QueryElement LeftElement { get; set; }
        public QueryElement RightElement { get; set; }
        public string GetQuery()
        {
            string result = "";
            if (JoinOperator == null)
            {
                result = $"{LeftElement.GetQuery()} {ComparisonOperator} {RightElement.GetQuery()}";
            }
            else
            {
                result = string.Join($" {JoinOperator} ", Statements.Select(x => $"{x.GetQuery()}"));
            }
            return result;
        }
    }
    public class QueryComparisonStatement : QueryStatement
    {
        //public string ComparisonOperator { get; set; }
        //public QueryElement LeftElement { get; set; }
        //public QueryElement RightElement { get; set; }
        //public string GetQuery()
        //{
        //    return "";
        //}
    }
}
