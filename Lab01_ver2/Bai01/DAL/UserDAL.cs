using Microsoft.Data.SqlClient;
using System.Data;
using Bai01.Models;

namespace Bai01.DAL
{
    public class UserDAL
    {
        private readonly string _connectionString;
        public UserDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        public List<UserModel> GetAllUsers()
        {
            var users = new List<UserModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "SELECT UserId, Username, Email, Password FROM Users";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new UserModel
                        {
                            UserId = reader.GetInt32(0),
                            Username = reader.GetString(1),
                            Email = reader.GetString(2),
                            Password = reader.GetString(3)
                        };
                        users.Add(user);
                    }
                }
            }
            return users;
        }
        public void CreateUser(UserModel user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void UpdateUser(UserModel user)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "UPDATE Users SET Username = @Username, Email = @Email, Password = @Password WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@Username", user.Username);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        public void DeleteUser(int userId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                string query = "DELETE FROM Users WHERE UserId = @UserId";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@UserId", userId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
