using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UserRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Deactivate(int id)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_User_Deactivate";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public List<User> GetAll()
        {
            var users = new List<User>();

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_User_GetAll";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var user = new User
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString() ?? string.Empty,
                                Email = reader["Email"].ToString() ?? string.Empty,
                                PasswordHash = reader["PasswordHash"].ToString() ?? string.Empty,
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            };

                            users.Add(user);
                        }
                    }

                    connection.Close();
                }
            }

            return users;
        }

        public User? GetById(int id)
        {
            User? user = null;

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_User_GetById";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString() ?? string.Empty,
                                Email = reader["Email"].ToString() ?? string.Empty,
                                PasswordHash = reader["PasswordHash"].ToString() ?? string.Empty,
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            };
                        }
                    }
                }
            }

            return user;
        }

        public int Save(User user)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_User_Insert";
                    command.CommandType = CommandType.StoredProcedure;

                    var NameParam = command.CreateParameter();
                    NameParam.ParameterName = "@Name";
                    NameParam.DbType = DbType.String;
                    NameParam.Value = user.Name;
                    command.Parameters.Add(NameParam);

                    var EmailParam = command.CreateParameter();
                    EmailParam.ParameterName = "@Email";
                    EmailParam.DbType = DbType.String;
                    EmailParam.Value = user.Email;
                    command.Parameters.Add(EmailParam);                    

                    var PasswordHash = command.CreateParameter();
                    PasswordHash.ParameterName = "@PasswordHash";
                    PasswordHash.DbType = DbType.String;
                    EmailParam.Value = user.PasswordHash;
                    command.Parameters.Add(PasswordHash);

                    var IsActiveParam = command.CreateParameter();
                    IsActiveParam.ParameterName = "@IsActive";
                    IsActiveParam.DbType = DbType.Boolean;
                    IsActiveParam.Value = user.IsActive;
                    command.Parameters.Add(IsActiveParam);

                    var outputIdParam = command.CreateParameter();
                    outputIdParam.ParameterName = "@Id";
                    outputIdParam.DbType = DbType.Int32;
                    outputIdParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputIdParam);

                    connection.Open();

                    command.ExecuteNonQuery();

                    user.Id = Convert.ToInt32(outputIdParam.Value);

                    connection.Close();
                }
            }

            return user.Id;
        }

        public void Update(User user)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_User_Update";
                    command.CommandType = CommandType.StoredProcedure;

                    var IdParameter = command.CreateParameter();
                    IdParameter.ParameterName = "@Id";
                    IdParameter.DbType = DbType.Int32;
                    IdParameter.Value = user.Id;
                    command.Parameters.Add(IdParameter);

                    var NameParam = command.CreateParameter();
                    NameParam.ParameterName = "@Name";
                    NameParam.DbType = DbType.String;
                    NameParam.Value = user.Name;
                    command.Parameters.Add(NameParam);

                    var EmailParam = command.CreateParameter();
                    EmailParam.ParameterName = "@Email";
                    EmailParam.DbType = DbType.String;
                    EmailParam.Value = user.Email;
                    command.Parameters.Add(EmailParam);

                    var PasswordHash = command.CreateParameter();
                    PasswordHash.ParameterName = "@PasswordHash";
                    PasswordHash.DbType = DbType.String;
                    EmailParam.Value = user.PasswordHash;
                    command.Parameters.Add(PasswordHash);

                    var IsActiveParam = command.CreateParameter();
                    IsActiveParam.ParameterName = "@IsActive";
                    IsActiveParam.DbType = DbType.Boolean;
                    IsActiveParam.Value = user.IsActive;
                    command.Parameters.Add(IsActiveParam);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
