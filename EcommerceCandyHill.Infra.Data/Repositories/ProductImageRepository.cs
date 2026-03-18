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

        public void Deactivate(int id)
        {
            using (var connection = _connectionFactory.CriarConexaoBaseDeDados())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductImage_Delete";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public List<ProductImage> GetAll()
        {
            List<ProductImage> productImages = new List<ProductImage>();

            using (var connection = _connectionFactory.CriarConexaoBaseDeDados())
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
                            ProductImage productImage = new ProductImage
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                ImageUrl = reader["ImageUrl"].ToString() ?? string.Empty,
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

        public ProductImage? GetById(int id)
        {
            ProductImage? productImage = null;

            using (var connection = _connectionFactory.CriarConexaoBaseDeDados())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductImage_GetById";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            productImage = new ProductImage
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                ProductId = Convert.ToInt32(reader["ProductId"]),
                                ImageUrl = reader["ImageUrl"].ToString() ?? string.Empty,
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

        public int Save(ProductImage entity)
        {
            using (var connection = _connectionFactory.CriarConexaoBaseDeDados())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductImage_Insert";
                    command.CommandType = CommandType.StoredProcedure;

                    var ProductIdParameter = command.CreateParameter();
                    ProductIdParameter.ParameterName = "@ProductId";
                    ProductIdParameter.DbType = DbType.Int32;
                    ProductIdParameter.Value = entity.ProductId;
                    command.Parameters.Add(ProductIdParameter);

                    var ImageUrlParameter = command.CreateParameter();
                    ImageUrlParameter.ParameterName = "@ImageUrl";
                    ImageUrlParameter.DbType = DbType.String;
                    ImageUrlParameter.Value = entity.ImageUrl;
                    command.Parameters.Add(ImageUrlParameter);

                    var IsMainParameter = command.CreateParameter();
                    IsMainParameter.ParameterName = "@IsMain";
                    IsMainParameter.DbType = DbType.Boolean;
                    IsMainParameter.Value = entity.IsActive;
                    command.Parameters.Add(IsMainParameter);

                    var IsActiveParam = command.CreateParameter();
                    IsActiveParam.ParameterName = "@IsActive";
                    IsActiveParam.DbType = DbType.Boolean;
                    IsActiveParam.Value = entity.IsActive;
                    command.Parameters.Add(IsMainParameter);

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

        public void Update(ProductImage entity)
        {
            using (var connection = _connectionFactory.CriarConexaoBaseDeDados())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductImage_Update";
                    command.CommandType = CommandType.StoredProcedure;

                    var IdParameter = command.CreateParameter();
                    IdParameter.ParameterName = "@Id";
                    IdParameter.DbType = DbType.Int32;
                    IdParameter.Value = entity.Id;
                    command.Parameters.Add(IdParameter);

                    var ProductIdParameter = command.CreateParameter();
                    ProductIdParameter.ParameterName = "@ProductId";
                    ProductIdParameter.DbType = DbType.Int32;
                    ProductIdParameter.Value = entity.ProductId;
                    command.Parameters.Add(ProductIdParameter);

                    var ImageUrlParameter = command.CreateParameter();
                    ImageUrlParameter.ParameterName = "@ImageUrl";
                    ImageUrlParameter.DbType = DbType.String;
                    ImageUrlParameter.Value = entity.ImageUrl;
                    command.Parameters.Add(ImageUrlParameter);

                    var IsMainParameter = command.CreateParameter();
                    IsMainParameter.ParameterName = "@IsMain";
                    IsMainParameter.DbType = DbType.Boolean;
                    IsMainParameter.Value = entity.IsActive;
                    command.Parameters.Add(IsMainParameter);

                    var IsActiveParam = command.CreateParameter();
                    IsActiveParam.ParameterName = "@IsActive";
                    IsActiveParam.DbType = DbType.Boolean;
                    IsActiveParam.Value = entity.IsActive;
                    command.Parameters.Add(IsMainParameter);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
