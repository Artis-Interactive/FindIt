using findit_backend.Models;
using System.Data;
using System.Data.SqlClient;
namespace findit_backend.Handlers
{
    public class UserHandler
    {
        private SqlConnection _conexion;
        private string _rutaConexion;
        public UserHandler()
        {
            var builder = WebApplication.CreateBuilder();
            _rutaConexion = builder.Configuration.GetConnectionString("PIUsers");
            _conexion = new SqlConnection(_rutaConexion);
        }
        private DataTable CrearTablaConsulta(string consulta)
        {
            SqlCommand comandoParaConsulta = new
            SqlCommand(consulta, _conexion);
            SqlDataAdapter adaptadorParaTabla = new
            SqlDataAdapter(comandoParaConsulta);
            DataTable consultaFormatoTabla = new DataTable();
            _conexion.Open();
            adaptadorParaTabla.Fill(consultaFormatoTabla);
            _conexion.Close();
            return consultaFormatoTabla;
        }
        public List<UserModel> ObtenerUsuarios()
        {
            List<UserModel> usuarios = new List<UserModel>();
            string consulta = "SELECT * FROM dbo.Users ";
            DataTable tablaResultado =
            CrearTablaConsulta(consulta);
            foreach (DataRow columna in tablaResultado.Rows)
            {
                usuarios.Add(
                new UserModel
                {
                    LegalId = Convert.ToString(columna["LegalId"]),
                    Name = Convert.ToString(columna["Name"]),
                    LastNames = Convert.ToString(columna["LastNames"]),
                    Email = Convert.ToString(columna["Email"]),
                    BirthDate = Convert.ToString(columna["BirthDate"]),
                    PhoneNumber = Convert.ToString(columna["PhoneNumber"]),
                    Password = Convert.ToString(columna["PasswordHash"]),
                });
            }
            return usuarios;
        }

        public bool CreateUser(UserModel user)
        {
            var query = @"INSERT INTO [dbo].[Users] ([Name], [LastNames], [LegalID], [Email], [PasswordHash], 
                                                      [PhoneNumber], [BirthDate])
                        VALUES (@Name, @LastNames, @LegalID, @Email, @PasswordHash, @PhoneNumber, @BirthDate)";

            var queryCommand = new SqlCommand(query, _conexion);

            queryCommand.Parameters.AddWithValue("@Name", user.Name);
            queryCommand.Parameters.AddWithValue("@LastNames", user.LastNames);
            queryCommand.Parameters.AddWithValue("@LegalID", user.LegalId);
            queryCommand.Parameters.AddWithValue("@Email", user.Email);
            queryCommand.Parameters.AddWithValue("@PasswordHash", user.Password);
            queryCommand.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
            queryCommand.Parameters.AddWithValue("@Birthdate", user.BirthDate);

            _conexion.Open();
            bool success = queryCommand.ExecuteNonQuery() >= 1;
            _conexion.Close();

            return success;
        }


    }
}

