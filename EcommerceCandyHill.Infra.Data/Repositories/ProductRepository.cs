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
        private readonly string _connectionString;

        public ProductRepository(DatabaseSettings databaseSettings)
        {
            _connectionString = databaseSettings.ConnectionString;
        }


        public void DeleteById(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_DeleteProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_GetAllProducts", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                Product product = new Product
                                {
                                    Id = Convert.ToInt32(reader["ProductId"]),
                                    Name = reader["Name"] as string ?? string.Empty,
                                    Price = Convert.ToDecimal(reader["Price"]),
                                    RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"])
                                };

                                products.Add(product);
                            }
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

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_GetProductById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = id;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                Id = Convert.ToInt32(reader["ProductId"]),
                                Name = reader["Name"] as string ?? string.Empty,
                                Price = Convert.ToDecimal(reader["Price"]),
                                RegistrationDate = Convert.ToDateTime(reader["RegistrationDate"])
                            };
                        }
                    }
                }
            }

            return product;
        }

        public int Save(Product product)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("USP_INSERT_PRODUCT", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@NAME", product.Name);
                    command.Parameters.AddWithValue("@PRICE", product.Price);
                    command.Parameters.AddWithValue("@EXPIRATION_DATE", product.ExpirationDate);
                    command.Parameters.AddWithValue("@DESCRIPTION", product.Description);

                    SqlParameter outputIdParam = new SqlParameter
                    {
                        ParameterName = "@ID",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    };

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
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand("usp_UpdateProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int)).Value = product.Id;
                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.NVarChar, 100)).Value = product.Name;
                    command.Parameters.Add(new SqlParameter("@Price", SqlDbType.Decimal)).Value = product.Price;

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
