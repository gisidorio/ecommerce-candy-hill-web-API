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
    public class ProductFAQRepository : IProductFAQRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ProductFAQRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Deactivate(Guid id)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductFAQ_Deactivate";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id });

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<ProductFAQ> GetAll()
        {
            var productFAQs = new List<ProductFAQ>();

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductFAQ_GetAll";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productFAQ = new ProductFAQ
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Question = reader.GetString(reader.GetOrdinal("Question")),
                                Answer = reader.GetString(reader.GetOrdinal("Answer")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };

                            productFAQs.Add(productFAQ);
                        }
                    }

                    connection.Close();
                }
            }

            return productFAQs;
        }

        public ProductFAQ? GetById(Guid id)
        {
            ProductFAQ? productFAQ = null;

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductFAQ_GetById";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id });

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            productFAQ = new ProductFAQ
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Question = reader.GetString(reader.GetOrdinal("Question")),
                                Answer = reader.GetString(reader.GetOrdinal("Answer")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };
                        }
                    }
                }
            }

            return productFAQ;
        }

        public Guid Save(ProductFAQ entity)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductFAQ_Insert";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                    {
                        Value = entity.Id
                    });

                    command.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.UniqueIdentifier)
                    {
                        Value = entity.ProductId
                    });

                    command.Parameters.Add(new SqlParameter("@Question", SqlDbType.VarChar)
                    {
                        Value = entity.Question
                    });

                    command.Parameters.Add(new SqlParameter("@Answer", SqlDbType.VarChar)
                    {
                        Value = entity.Answer
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

        public void Update(ProductFAQ entity)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductFAQ_Update";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                    {
                        Value = entity.Id
                    });

                    command.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.UniqueIdentifier)
                    {
                        Value = entity.ProductId
                    });

                    command.Parameters.Add(new SqlParameter("@Question", SqlDbType.VarChar)
                    {
                        Value = entity.Question
                    });

                    command.Parameters.Add(new SqlParameter("@Answer", SqlDbType.VarChar)
                    {
                        Value = entity.Answer
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
}
