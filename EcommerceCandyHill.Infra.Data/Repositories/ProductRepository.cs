using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public ProductRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void AddTagsToProduct(Guid productId, IEnumerable<Guid> tagIds)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "usp_ProductTag_InsertBatch";
                command.CommandType = CommandType.StoredProcedure;

                var ProductIdParam = command.CreateParameter();
                ProductIdParam.ParameterName = "@productId";
                ProductIdParam.DbType = DbType.Guid;
                ProductIdParam.Value = productId;
                command.Parameters.Add(ProductIdParam);

                var table = new DataTable();
                table.Columns.Add("TagId", typeof(Guid));

                foreach (var roleId in tagIds)
                {
                    table.Rows.Add(roleId);
                }

                var tvpParam = command.CreateParameter();
                tvpParam.ParameterName = "@tagIds";
                tvpParam.Value = table;

                if (tvpParam is SqlParameter sqlParam)
                {
                    sqlParam.SqlDbType = SqlDbType.Structured;
                    sqlParam.TypeName = "dbo.TagIdList";
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
                    command.CommandText = "usp_Product_Deactivate";
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

        public List<Product> GetAll()
        {
            var products = new List<Product>();

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "USP_OBTER_TODOS_PRODUTOS";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };

                            products.Add(product);
                        }
                    }

                    connection.Close();
                }
            }

            return products;
        }

        public Product? GetById(Guid id)
        {
            Product? product = null;

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "OBTER_PRODUTO_POR_ID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier) { Value = id });

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                Price = reader.GetDecimal(reader.GetOrdinal("Price")),
                                Quantity = reader.GetInt32(reader.GetOrdinal("Quantity")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };
                        }
                    }
                }
            }

            return product;
        }

        public Guid Save(Product product)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_Product_Insert";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                    {
                        Value = product.Id
                    });

                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar)
                    {
                        Value = product.Name
                    });

                    command.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal)
                    {
                        Value = product.Price
                    });

                    command.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int)
                    {
                        Value = product.Quantity
                    });

                    command.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)
                    {
                        Value = product.IsActive
                    });

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            return product.Id;
        }

        public void Update(Product product)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "usp_Product_Update";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                {
                    Value = product.Id
                });

                command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar)
                {
                    Value = product.Name
                });

                command.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal)
                {
                    Value = product.Price
                });

                command.Parameters.Add(new SqlParameter("@Quantity", SqlDbType.Int)
                {
                    Value = product.Quantity
                });

                command.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)
                {
                    Value = product.IsActive
                });

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
