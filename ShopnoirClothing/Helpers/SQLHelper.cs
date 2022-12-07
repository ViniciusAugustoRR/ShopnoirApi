using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using ShopnoirClothing.Models;
using System.Data;
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

        public string RunProcedureWithReturn(string procedure)
        {
            try {
                Open();
                var command = new SqlCommand(procedure, sqlConnection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds);
               
                var jsonObject = JsonConvert.SerializeObject(ds.Tables[0]);
                
                Close();
                return jsonObject.ToString();
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
