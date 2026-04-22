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

        public async Task DeactivateAsync(Guid id)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_ProductFAQ_Deactivate";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = id
            });

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<ProductFAQ>> GetAllAsync()
        {
            var productFAQs = new List<ProductFAQ>();

            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_ProductFAQ_GetAll";
            command.CommandType = CommandType.StoredProcedure;

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
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

            return productFAQs;
        }

        public async Task<ProductFAQ?> GetByIdAsync(Guid id)
        {
            ProductFAQ? productFAQ = null;

            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_ProductFAQ_GetById";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = id
            });

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
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

            return productFAQ;
        }

        public async Task<Guid> SaveAsync(ProductFAQ entity)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

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

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(ProductFAQ entity)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

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

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }
}
