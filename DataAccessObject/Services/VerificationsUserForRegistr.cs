using HotelSelect.Dao.repository;
using HotelSelect.DataAccessObject.Interfaces;
using HotelSelect.Entity;
using PhoneNumbers;
using System;
using System.Data.SqlClient;

namespace HotelSelect.Dao.service
{
    internal class VerificationsUserForRegistr : IServiceDAO
    {
        public static string CheckEmailUser(string emailUser)
        {
            if (string.IsNullOrEmpty(emailUser))
            {
                throw new Exception("Email is null of empty");
            }

            if (!emailUser.Contains("@"))
            {
                throw new Exception("Email not Contains @");
            }

            return emailUser;
        }

        public static string CheckPhoneNumberUser(string phoneNumber)
        {
            PhoneNumberUtil phoneNumberUtil = PhoneNumberUtil.GetInstance();

            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new ArgumentException("Phone number null or empty", nameof(phoneNumber));
            }

            if (!phoneNumber.StartsWith("+"))
            {
                phoneNumber = "+" + phoneNumber;
            }

            try
            {
                PhoneNumber number = phoneNumberUtil.Parse(phoneNumber, null);
                string formattednumber = phoneNumberUtil.Format(number, PhoneNumberFormat.INTERNATIONAL);

                if (!phoneNumberUtil.IsValidNumber(number))
                {
                    throw new ArgumentException("Phone number not valid", nameof(phoneNumber));
                }

                return formattednumber;
            }
            catch (NumberParseException e)
            {
                throw new ArgumentException("Error parsing phone number: " + e.Message);
            }
        }

        public bool CheckExistUser(User user)
        {
            SqlConnection sqlConnection = ConnectorDataBaseMicrosoftSQL.StartConnection().SqlConnection;

            return true;
            //try
            //{
            //    sqlConnection.Open();

            //    string sqlQueryCheckExistUser = "SELECT * FROM Users WHERE phone_number = @phoneNumber " +
            //                                    "OR email = @email OR login = @login";

            //    SqlCommand sqlCommandCheckExistUser = new SqlCommand(sqlQueryCheckExistUser, sqlConnection);

            //    sqlCommandCheckExistUser.Parameters.AddWithValue("@phoneNumber", user.PhoneNumber);
            //    sqlCommandCheckExistUser.Parameters.AddWithValue("@email", user.Email);
            //    sqlCommandCheckExistUser.Parameters.AddWithValue("@login", user.Login);

            //    int count = Convert.ToInt32(sqlCommandCheckExistUser.ExecuteScalar());

            //    return count == 0;
            //}
            //catch (SqlException e)
            //{
            //    throw new Exception("Произошла ошибка при работе с базой данных: " + e.Message);
            //}
            //catch (Exception ex)
            //{
            //    throw new Exception("Произошла ошибка: " + ex.Message);
            //}
            //finally { sqlConnection.Close(); }
        }
    }
}