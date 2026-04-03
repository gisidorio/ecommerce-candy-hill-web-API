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

        public void AddRolesToUser(Guid userId, IEnumerable<Guid> roleIds)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "usp_UserRole_InsertBatch";
                command.CommandType = CommandType.StoredProcedure;

                var userIdParam = command.CreateParameter();
                userIdParam.ParameterName = "@UserId";
                userIdParam.DbType = DbType.Guid;
                userIdParam.Value = userId;
                command.Parameters.Add(userIdParam);

                var table = new DataTable();
                table.Columns.Add("RoleId", typeof(Guid));

                foreach (var roleId in roleIds)
                {
                    table.Rows.Add(roleId);
                }

                var tvpParam = command.CreateParameter();
                tvpParam.ParameterName = "@RoleIds";
                tvpParam.Value = table;

                if (tvpParam is SqlParameter sqlParam)
                {
                    sqlParam.SqlDbType = SqlDbType.Structured;
                    sqlParam.TypeName = "dbo.RoleIdList";
                }

                command.Parameters.Add(tvpParam);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void Deactivate(Guid id)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_User_Deactivate";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(
                        new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                        {
                            Value = id
                        });

                    connection.Open();
                    command.ExecuteNonQuery();
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
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };

                            users.Add(user);
                        }
                    }

                    connection.Close();
                }
            }

            return users;
        }

        public User? GetById(Guid id)
        {
            User? user = null;

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_User_GetById";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(
                        new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                        {
                            Value = id
                        });

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Email = reader.GetString(reader.GetOrdinal("Email")),
                                PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };
                        }
                    }
                }
            }

            return user;
        }

        public Guid Save(User user)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_User_Insert";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                    {
                        Value = user.Id
                    });

                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar)
                    {
                        Value = user.Name
                    });

                    command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar)
                    {
                        Value = user.Email
                    });

                    command.Parameters.Add(new SqlParameter("@PasswordHash", SqlDbType.VarChar)
                    {
                        Value = user.PasswordHash
                    });

                    command.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)
                    {
                        Value = user.IsActive
                    });

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            return user.Id;
        }

        public void Update(User user)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "usp_User_Update";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                {
                    Value = user.Id
                });

                command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar)
                {
                    Value = user.Name ?? (object)DBNull.Value
                });

                command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar)
                {
                    Value = user.Email ?? (object)DBNull.Value
                });

                command.Parameters.Add(new SqlParameter("@PasswordHash", SqlDbType.VarChar)
                {
                    Value = user.PasswordHash ?? (object)DBNull.Value
                });

                command.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)
                {
                    Value = user.IsActive
                });

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateRolesToUser(Guid userId, IEnumerable<Guid> roleIds)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "usp_UserRole_UpdateBatch";
                command.CommandType = CommandType.StoredProcedure;

                var userIdParam = command.CreateParameter();
                userIdParam.ParameterName = "@UserId";
                userIdParam.DbType = DbType.Guid;
                userIdParam.Value = userId;
                command.Parameters.Add(userIdParam);

                var table = new DataTable();
                table.Columns.Add("RoleId", typeof(Guid));

                foreach (var roleId in roleIds)
                {
                    table.Rows.Add(roleId);
                }

                var tvpParam = command.CreateParameter();
                tvpParam.ParameterName = "@RoleIds";
                tvpParam.Value = table;

                if (tvpParam is SqlParameter sqlParam)
                {
                    sqlParam.SqlDbType = SqlDbType.Structured;
                    sqlParam.TypeName = "dbo.RoleIdList";
                }

                command.Parameters.Add(tvpParam);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
