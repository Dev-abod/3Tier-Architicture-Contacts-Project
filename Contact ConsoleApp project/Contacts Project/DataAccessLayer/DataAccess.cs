using System;
using System.Data;
using System.Data.SqlClient;
using ConnectionStringSitting;

namespace DataAccessLayer
{
    public class DataAccess
    {
        public static bool GetContactInfoById(int ID, ref string FirstName, ref string LastName, ref string Email,
            ref string Phone, ref string Address, ref int CountryID, ref DateTime DateOfBirth,
            ref string ImagePath)
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

        public static int AddNewContact(string FirstName, string LastName, string Email,
             string Phone, string Address, int CountryID, DateTime DateOfBirth, string ImagePath)
        {
            int ContactID = -1;
            SqlConnection connection = new SqlConnection(ConnectionString.Connection);

            string query = "INSERT INTO Contacts(FirstName,LastName,Email," +
                "Phone,Address,CountryID,DateOfBirth,ImagePath)" +
                "VALUES(@FirstName,@LastName,@Email," +
                "@Phone,@Address,@CountryID,@DateOfBirth,@ImagePath);" +
                "SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);

            if(ImagePath != "")
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            else
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);

            try
            {
                connection.Open();

                object Result = command.ExecuteNonQuery();

                if (Result != null && int.TryParse(Result.ToString(),out int  insertedID))
                    ContactID = insertedID;
                

            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                connection.Close();
            }

            return ContactID;
        }
    }
}
