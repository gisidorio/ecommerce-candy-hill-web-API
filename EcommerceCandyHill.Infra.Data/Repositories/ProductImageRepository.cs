using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Repositories;
using EcommerceCandyHill.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Infra.Data.Repositories
{
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ProductImageRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Deactivate(Guid id)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductImage_Deactivate";
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

        public List<ProductImage> GetAll()
        {
            var productImages = new List<ProductImage>();

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductImage_GetAll";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productImage = new ProductImage
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                ProductId = reader.GetGuid(reader.GetOrdinal("ProductId")),
                                ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl")),
                                IsMain = Convert.ToBoolean(reader["IsMain"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            };

                            productImages.Add(productImage);
                        }
                    }

                    connection.Close();
                }
            }

            return productImages;
        }

        public ProductImage? GetById(Guid id)
        {
            ProductImage? productImage = null;

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductImage_GetById";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id });

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            productImage = new ProductImage
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                ProductId = reader.GetGuid(reader.GetOrdinal("ProductId")),
                                ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl")),
                                IsMain = Convert.ToBoolean(reader["IsMain"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            };
                        }
                    }
                }
            }

            return productImage;
        }

        public Guid Save(ProductImage entity)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductImage_Insert";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                    {
                        Value = entity.Id
                    });

                    command.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.UniqueIdentifier)
                    {
                        Value = entity.ProductId
                    });

                    command.Parameters.Add(new SqlParameter("@ImageUrl", SqlDbType.VarChar)
                    {
                        Value = entity.ImageUrl
                    });

                    command.Parameters.Add(new SqlParameter("@IsMain", SqlDbType.Bit)
                    {
                        Value = entity.IsMain
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

        public void Update(ProductImage entity)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductImage_Update";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                    {
                        Value = entity.Id
                    });

                    command.Parameters.Add(new SqlParameter("@ProductId", SqlDbType.UniqueIdentifier)
                    {
                        Value = entity.ProductId
                    });

                    command.Parameters.Add(new SqlParameter("@ImageUrl", SqlDbType.VarChar)
                    {
                        Value = entity.ImageUrl
                    });

                    command.Parameters.Add(new SqlParameter("@IsMain", SqlDbType.Bit)
                    {
                        Value = entity.IsMain
                    });

                    command.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)
                    {
                        Value = entity.IsActive
                    });

                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
