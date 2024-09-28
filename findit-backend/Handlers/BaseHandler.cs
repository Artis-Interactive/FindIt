using System.Data;
using System.Data.SqlClient;

namespace findit_backend.Handlers
{
    public class BaseHandler
    {
        protected SqlConnection _connection;
        protected string _connectionRoute;

        public BaseHandler()
        {
            var builder = WebApplication.CreateBuilder();
            _connectionRoute = builder.Configuration.GetConnectionString("PIUsers");
            _connection = new SqlConnection(_connectionRoute);
        }

        protected DataTable CreateQueryTable(string query)
        {
            SqlCommand commandForQuery = new SqlCommand(query, _connection);
            SqlDataAdapter tableAdapter = new SqlDataAdapter(commandForQuery);
            DataTable queryTableFormat = new DataTable();
            _connection.Open();
            tableAdapter.Fill(queryTableFormat);
            _connection.Close();
            return queryTableFormat;
        }

        protected bool ExecuteNonQuery(SqlCommand command)
        {
            _connection.Open();
            bool success = command.ExecuteNonQuery() >= 1;
            _connection.Close();
            return success;
        }
    }
}
