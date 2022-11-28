using ShopnoirClothing.Models;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace ShopnoirClothing.Helpers
{
    public class SQLHelper
    {

        private SqlConnection sqlConnection;
        private string _ConnectionString;
        public SQLHelper(string ConnectionString)
        {
            sqlConnection = new SqlConnection(ConnectionString);
            _ConnectionString= ConnectionString;
        }

        public void RunProcedure(string procedure)
        {

        }

        public List<Item> RunProcedureWithReturn(string procedure)
        {
            try {
                Open();
                var command = new SqlCommand(procedure, sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader reader = command.ExecuteReader();
                Item item;
                List<Item> list = new List<Item>();
                while(reader.Read())
                {
                    item = new Item()
                    {
                        Id = int.Parse(reader["ID"].ToString()),
                        Title = reader["TITLE"].ToString(),
                        Description = reader["DESCR"].ToString(),
                        Price = double.Parse(reader["PRICE"].ToString())
                    };
                    list.Add(item);
                }

                Close();
                return list;
            }
            catch(Exception ex)
            {
                Close();
                throw ex;
            }
        }

        public void Open()
        {
            sqlConnection.Open(); 
        }

        public void Close()
        {
            sqlConnection.Close();
        }

    }

}
