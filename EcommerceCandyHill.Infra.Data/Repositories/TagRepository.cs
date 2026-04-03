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
    public class TagRepository : ITagRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public TagRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Deactivate(Guid id)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_Tag_Deactivate";
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

        public List<Tag> GetAll()
        {
            var tags = new List<Tag>();

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_Tag_GetAll";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var tag = new Tag
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };

                            tags.Add(tag);
                        }
                    }

                    connection.Close();
                }
            }

            return tags;
        }

        public Tag? GetById(Guid id)
        {
            Tag? tag = null;

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_Tag_GetById";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id });

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tag = new Tag
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

            return tag;
        }

        public Guid Save(Tag entity)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_Tag_Insert";
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

        public void Update(Tag entity)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_Tag_Update";
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
                    connection.Close();
                }
            }
        }
    }
}
