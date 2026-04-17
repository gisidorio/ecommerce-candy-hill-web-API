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
            _connectionFactory = connectionFactory
                ?? throw new ArgumentNullException(nameof(connectionFactory));
        }

        public async Task AddTagsToProductAsync(Guid productId, IEnumerable<Guid> tagIds)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_ProductTag_InsertBatch";
            command.CommandType = CommandType.StoredProcedure;

            var productIdParam = command.CreateParameter();
            productIdParam.ParameterName = "@productId";
            productIdParam.DbType = DbType.Guid;
            productIdParam.Value = productId;
            command.Parameters.Add(productIdParam);

            var table = new DataTable();
            table.Columns.Add("TagId", typeof(Guid));

            foreach (var tagId in tagIds)
            {
                table.Rows.Add(tagId);
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

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task DeactivateAsync(Guid id)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_Product_Deactivate";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = id
            });

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            var products = new List<Product>();

            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "USP_OBTER_TODOS_PRODUTOS";
            command.CommandType = CommandType.StoredProcedure;

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var product = new Product
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

            return products;
        }

        public async Task<Product?> GetByIdAsync(Guid id)
        {
            Product? product = null;

            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "OBTER_PRODUTO_POR_ID";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = id
            });

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
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

            return product;
        }

        public async Task<Guid> SaveAsync(Product product)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

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

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();

            return product.Id;
        }

        public async Task UpdateAsync(Product product)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

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

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }
}
