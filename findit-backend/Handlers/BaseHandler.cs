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
            _connectionRoute = builder.Configuration.GetConnectionString("FindItDatabase");
            this._connection = new SqlConnection(_connectionRoute);
        }

        protected DataTable CreateQueryTable(string query, params SqlParameter[] parameters)
        {
            DataTable queryTableFormat = new DataTable();

            using (SqlCommand commandForQuery = new SqlCommand(query, this._connection))
            {
                if (parameters != null && parameters.Length > 0)
                {
                    commandForQuery.Parameters.AddRange(parameters);
                }
                using (SqlDataAdapter tableAdapter = new SqlDataAdapter(commandForQuery))
                {
                    this._connection.Open();
                    tableAdapter.Fill(queryTableFormat);
                    this._connection.Close();
                }
            }
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
