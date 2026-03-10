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
        //private readonly string _connectionString;
        private readonly IDbConnectionFactory _connectionFactory;

        public ProductRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }


        public void DeleteById(int id)
        {
            using (var connection = _connectionFactory.CriarConexaoBaseDeDados())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_deletete";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public List<Produto> GetAll()
        {
            List<Produto> products = new List<Produto>();

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
                            Produto product = new Produto
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Nome = reader["Nome"] as string ?? string.Empty,
                                Preco = Convert.ToDecimal(reader["Preco"]),
                                Descricao = reader["Descricao"] as string ?? string.Empty,
                                Quantidade = Convert.ToInt32(reader["Quantidade"]),
                                DataCadastro = Convert.ToDateTime(reader["DataCadastro"]),
                                UrlImagem = reader["UrlImagem"] as string ?? string.Empty
                            };

                            products.Add(product);
                        }
                    }

                    connection.Close();
                }
            }

            return products;
        }

        public Produto? GetById(int id)
        {
            Produto? product = null;

            using (var connection = _connectionFactory.CriarConexaoBaseDeDados())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_GetProductById";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Produto
                            {
                                Id = Convert.ToInt32(reader["ProductId"]),
                                Nome = reader["Name"] as string ?? string.Empty,
                                Preco = Convert.ToDecimal(reader["Price"]),
                                DataCadastro = Convert.ToDateTime(reader["RegistrationDate"])
                            };
                        }
                    }
                }
            }

            return product;
        }

        public int Save(Produto product)
        {
            using (var connection = _connectionFactory.CriarConexaoBaseDeDados())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "USP_INSERT_PRODUCT";
                    command.CommandType = CommandType.StoredProcedure;

                    var nameParam = command.CreateParameter();
                    nameParam.ParameterName = "@NAME";
                    nameParam.DbType = DbType.String;
                    nameParam.Value = product.Nome;
                    command.Parameters.Add(nameParam);

                    var priceParam = command.CreateParameter();
                    priceParam.ParameterName = "@PRICE";
                    priceParam.DbType = DbType.Decimal;
                    priceParam.Value = product.Preco;
                    command.Parameters.Add(priceParam);

                    var dateParam = command.CreateParameter();
                    dateParam.ParameterName = "@EXPIRATION_DATE";
                    dateParam.DbType = DbType.DateTime;
                    dateParam.Value = product.DataCadastro;
                    command.Parameters.Add(dateParam);

                    var descParam = command.CreateParameter();
                    descParam.ParameterName = "@DESCRIPTION";
                    descParam.DbType = DbType.String;
                    descParam.Value = product.Descricao ?? string.Empty;
                    command.Parameters.Add(descParam);

                    // Parâmetro de saída
                    var outputIdParam = command.CreateParameter();
                    outputIdParam.ParameterName = "@ID";
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

        public void Update(Produto product)
        {
            using (var connection = _connectionFactory.CriarConexaoBaseDeDados())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_UpdateProduct";
                    command.CommandType = CommandType.StoredProcedure;

                    // Parâmetro @Id
                    var idParam = command.CreateParameter();
                    idParam.ParameterName = "@Id";
                    idParam.DbType = DbType.Int32;
                    idParam.Value = product.Id;
                    command.Parameters.Add(idParam);

                    // Parâmetro @Name
                    var nameParam = command.CreateParameter();
                    nameParam.ParameterName = "@Name";
                    nameParam.DbType = DbType.String;
                    nameParam.Size = 100; 
                    nameParam.Value = product.Nome;
                    command.Parameters.Add(nameParam);

                    // Parâmetro @Price
                    var priceParam = command.CreateParameter();
                    priceParam.ParameterName = "@Price";
                    priceParam.DbType = DbType.Decimal;
                    priceParam.Value = product.Preco;
                    command.Parameters.Add(priceParam);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
