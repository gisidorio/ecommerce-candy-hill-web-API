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

        public void Deactivate(int id)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_Role_Deactivate";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
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
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString() ?? string.Empty,
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            };

                            roles.Add(role);
                        }
                    }

                    connection.Close();
                }
            }

            return roles;
        }

        public Role? GetById(int id)
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
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString() ?? string.Empty,
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            };
                        }
                    }
                }
            }

            return role;
        }

        public int Save(Role entity)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_Role_Insert";
                    command.CommandType = CommandType.StoredProcedure;

                    var NameParameter = command.CreateParameter();
                    NameParameter.ParameterName = "@Name";
                    NameParameter.DbType = DbType.String;
                    NameParameter.Value = entity.Name;
                    command.Parameters.Add(NameParameter);

                    var IsActiveParam = command.CreateParameter();
                    IsActiveParam.ParameterName = "@IsActive";
                    IsActiveParam.DbType = DbType.Boolean;
                    IsActiveParam.Value = entity.IsActive;
                    command.Parameters.Add(IsActiveParam);

                    var outputIdParam = command.CreateParameter();
                    outputIdParam.ParameterName = "@Id";
                    outputIdParam.DbType = DbType.Int32;
                    outputIdParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputIdParam);

                    connection.Open();

                    command.ExecuteNonQuery();

                    entity.Id = Convert.ToInt32(outputIdParam.Value);

                    connection.Close();
                }
            }

            return entity.Id;
        }

        public void Update(Role entity)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_Role_Update";
                    command.CommandType = CommandType.StoredProcedure;

                    var IdParameter = command.CreateParameter();
                    IdParameter.ParameterName = "@Id";
                    IdParameter.DbType = DbType.Int32;
                    IdParameter.Value = entity.Id;
                    command.Parameters.Add(IdParameter);

                    var NameParameter = command.CreateParameter();
                    NameParameter.ParameterName = "@Name";
                    NameParameter.DbType = DbType.String;
                    NameParameter.Value = entity.Name;
                    command.Parameters.Add(NameParameter);

                    var IsActiveParam = command.CreateParameter();
                    IsActiveParam.ParameterName = "@IsActive";
                    IsActiveParam.DbType = DbType.Boolean;
                    IsActiveParam.Value = entity.IsActive;
                    command.Parameters.Add(IsActiveParam);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
