using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pruebau
{
    class Cliente
    {
        public EventHandler OnCommands;
        public SqlTransaction Transaction { get; set; }
        public SqlConnection Connection { get; set; }
        public Cliente()
        {
            Connection = new SqlConnection();
            Connection.ConnectionString = "Data Source=.;Initial Catalog=DataBaseName;User id=sa;Password=123;";
        }

        public void ExecuteTransaction()
        {
            try
            {
                Connection.Open();
                Transaction = Connection.BeginTransaction();
                OnCommands(this, new EventArgs());
                Transaction.Commit();
                Transaction.Dispose();
                Connection.Close();
            }
            catch (Exception ex)
            {
                if (Transaction != null) Transaction.Rollback();
                throw ex;
            }
        }
        public void Execute()
        {
            try
            {
                Connection.Open();
                OnCommands(this, new EventArgs());
                Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
