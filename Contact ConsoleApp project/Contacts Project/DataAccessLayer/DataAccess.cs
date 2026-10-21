using System;
using System.Data;
using System.Data.SqlClient;
using ConnectionStringSitting;

namespace DataAccessLayer
{
    public class DataAccess
    {
        public static bool GetContactInfoById(int ID,ref string FirstName, ref string LastName,
            ref string Email, ref string Phone, ref string Address, ref DateTime DateOfBirth ,
            ref int CountryID, ref string ImagePath)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(ConnectionString.Connection);
            string query = "SELECT * FROM Contacts WHERE ContactID = @ContactID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                    CountryID = (int)reader["CountryID"];
                    if (reader["ImagePath"] != null)
                        ImagePath = (string)reader["ImagePath"];
                    else
                        ImagePath = "";

                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }
            return isFound;
        }
    }
}
