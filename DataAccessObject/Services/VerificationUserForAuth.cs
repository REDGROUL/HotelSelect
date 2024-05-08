using HotelSelect.Dao.repository;
using HotelSelect.DataAccessObject.Interfaces;
using HotelSelect.Entity;
using System;
using System.Data.SqlClient;

namespace HotelSelect.DataAccessObject.Services
{
    internal class VerificationUserForAuth : IServiceDAO
    {
        public bool CheckExistUser(User user)
        {
            SqlConnection sqlConnection = ConnectorDataBaseMicrosoftSQL.StartConnection().SqlConnection;

            try
            {
                sqlConnection.Open();

                string sqlQueryCheckExistUser = "SELECT * FROM Users WHERE login = @login ";

                SqlCommand sqlCommandCheckExistUser = new SqlCommand(sqlQueryCheckExistUser, sqlConnection);

                sqlCommandCheckExistUser.Parameters.AddWithValue("@login", user.Login);
//                sqlCommandCheckExistUser.Parameters.AddWithValue("@password", user.Password);

                int count = Convert.ToInt32(sqlCommandCheckExistUser.ExecuteScalar());

                return count == 0;
            }
            catch (SqlException e)
            {
                throw new Exception("Произошла ошибка при работе с базой данных: " + e.Message);
            }
            catch (Exception e)
            {
                throw new Exception("Произошла ошибка: " + e.Message);
            }
            finally { sqlConnection.Close(); }
        }
    }
}
