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

        public async Task DeactivateAsync(Guid id)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_ProductImage_Deactivate";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = id
            });

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<ProductImage>> GetAllAsync()
        {
            var productImages = new List<ProductImage>();

            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_ProductImage_GetAll";
            command.CommandType = CommandType.StoredProcedure;

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var productImage = new ProductImage
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    ProductId = reader.GetGuid(reader.GetOrdinal("ProductId")),
                    ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl")),
                    IsMain = reader.GetBoolean(reader.GetOrdinal("IsMain")),
                    IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                };

                productImages.Add(productImage);
            }

            return productImages;
        }

        public async Task<ProductImage?> GetByIdAsync(Guid id)
        {
            ProductImage? productImage = null;

            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_ProductImage_GetById";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = id
            });

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                productImage = new ProductImage
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    ProductId = reader.GetGuid(reader.GetOrdinal("ProductId")),
                    ImageUrl = reader.GetString(reader.GetOrdinal("ImageUrl")),
                    IsMain = reader.GetBoolean(reader.GetOrdinal("IsMain")),
                    IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                };
            }

            return productImage;
        }

        public async Task<Guid> SaveAsync(ProductImage entity)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

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

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(ProductImage entity)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

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

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }
}
