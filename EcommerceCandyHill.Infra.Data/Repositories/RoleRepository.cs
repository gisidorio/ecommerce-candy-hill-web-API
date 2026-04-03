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
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public RoleRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Deactivate(Guid id)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_Role_Deactivate";
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

        public List<Role> GetAll()
        {
            var roles = new List<Role>();

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_Role_GetAll";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var role = new Role
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };

                            roles.Add(role);
                        }
                    }

                    connection.Close();
                }
            }

            return roles;
        }

        public Role? GetById(Guid id)
        {
            Role? role = null;

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_Role_GetById";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            role = new Role
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };
                        }
                    }
                }
            }

            return role;
        }

        public Guid Save(Role entity)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_Role_Insert";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                    {
                        Value = entity.Id
                    });

                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar)
                    {
                        Value = entity.Name
                    });

                    command.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)
                    {
                        Value = entity.IsActive
                    });

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            return entity.Id;
        }

        public void Update(Role entity)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "usp_PaymentMethod_Update";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                {
                    Value = entity.Id
                });

                command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar)
                {
                    Value = entity.Name ?? (object)DBNull.Value
                });

                command.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)
                {
                    Value = entity.IsActive
                });

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
