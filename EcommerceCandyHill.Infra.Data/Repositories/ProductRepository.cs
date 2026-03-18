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

        public void Delete(int id)
        {
            using (var connection = _connectionFactory.CriarConexaoBaseDeDados())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_Product_Delete";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            using (var connection = _connectionFactory.CriarConexaoBaseDeDados())
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
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Nome"] as string ?? string.Empty,
                                Price = Convert.ToDecimal(reader["Price"]),
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            };

                            products.Add(product);
                        }
                    }

                    connection.Close();
                }
            }

            return products;
        }

        public Product? GetById(int id)
        {
            Product? product = null;

            using (var connection = _connectionFactory.CriarConexaoBaseDeDados())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "OBTER_PRODUTO_POR_ID";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"] as string ?? string.Empty,
                                Price = Convert.ToDecimal(reader["Price"]),
                                Description = reader["Description"] as string ?? string.Empty,
                                Quantity = Convert.ToInt32(reader["Quantity"]),
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            };
                        }
                    }
                }
            }

            return product;
        }

        public long Save(Product product)
        {
            using (var connection = _connectionFactory.CriarConexaoBaseDeDados())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "USP_INSERT_PRODUCT";
                    command.CommandType = CommandType.StoredProcedure;

                    var nameParam = command.CreateParameter();
                    nameParam.ParameterName = "@Name";
                    nameParam.DbType = DbType.String;
                    nameParam.Value = product.Name;
                    command.Parameters.Add(nameParam);

                    var priceParam = command.CreateParameter();
                    priceParam.ParameterName = "@Price";
                    priceParam.DbType = DbType.Decimal;
                    priceParam.Value = product.Price;
                    command.Parameters.Add(priceParam);

                    var QuantityParameter = command.CreateParameter();
                    priceParam.ParameterName = "@Quantity";
                    priceParam.DbType = DbType.Int32;
                    priceParam.Value = product.Quantity;
                    command.Parameters.Add(QuantityParameter);

                    var descParam = command.CreateParameter();
                    descParam.ParameterName = "@Description";
                    descParam.DbType = DbType.String;
                    descParam.Value = product.Description ?? string.Empty;
                    command.Parameters.Add(descParam);

                    var isActiveParam = command.CreateParameter();
                    descParam.ParameterName = "@IsActive";
                    descParam.DbType = DbType.Boolean;
                    descParam.Value = product.IsActive;
                    command.Parameters.Add(isActiveParam);

                    var outputIdParam = command.CreateParameter();
                    outputIdParam.ParameterName = "@Id";
                    outputIdParam.DbType = DbType.Int32;
                    outputIdParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputIdParam);

                    connection.Open();

                    command.ExecuteNonQuery();

                    product.Id = Convert.ToInt32(outputIdParam.Value);

                    connection.Close();
                }
            }

            return product.Id;
        }

        public void Update(Product product)
        {
            using (var connection = _connectionFactory.CriarConexaoBaseDeDados())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_Product_Update";
                    command.CommandType = CommandType.StoredProcedure;

                    var idParam = command.CreateParameter();
                    idParam.ParameterName = "@Id";
                    idParam.DbType = DbType.Int32;
                    idParam.Value = product.Id;
                    command.Parameters.Add(idParam);

                    var nameParam = command.CreateParameter();
                    nameParam.ParameterName = "@Name";
                    nameParam.DbType = DbType.String;
                    nameParam.Size = 100; 
                    nameParam.Value = product.Name;
                    command.Parameters.Add(nameParam);

                    var priceParam = command.CreateParameter();
                    priceParam.ParameterName = "@Price";
                    priceParam.DbType = DbType.Decimal;
                    priceParam.Value = product.Price;
                    command.Parameters.Add(priceParam);

                    var QuantityParameter = command.CreateParameter();
                    QuantityParameter.ParameterName = "@Quantity";
                    QuantityParameter.DbType = DbType.Int32;
                    QuantityParameter.Value = product.Quantity;
                    command.Parameters.Add(QuantityParameter);

                    var descParam = command.CreateParameter();
                    descParam.ParameterName = "@Description";
                    descParam.DbType = DbType.String;
                    descParam.Value = product.Description ?? string.Empty;
                    command.Parameters.Add(descParam);

                    var isActiveParam = command.CreateParameter();
                    isActiveParam.ParameterName = "@IsActive";
                    isActiveParam.DbType = DbType.Boolean;
                    isActiveParam.Value = product.IsActive;
                    command.Parameters.Add(isActiveParam);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
