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
    public class TagRepository : ITagRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public TagRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task DeactivateAsync(Guid id)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_Tag_Deactivate";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = id
            });

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<Tag>> GetAllAsync()
        {
            var tags = new List<Tag>();

            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_Tag_GetAll";
            command.CommandType = CommandType.StoredProcedure;

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var tag = new Tag
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                };

                tags.Add(tag);
            }

            return tags;
        }

        public async Task<Tag?> GetByIdAsync(Guid id)
        {
            Tag? tag = null;

            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_Tag_GetById";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = id
            });

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                tag = new Tag
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                };
            }

            return tag;
        }

        public async Task<Guid> SaveAsync(Tag entity)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_Tag_Insert";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = entity.Id
            });

            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 100)
            {
                Value = entity.Name
            });

            command.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)
            {
                Value = entity.IsActive
            });

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(Tag entity)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_Tag_Update";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = entity.Id
            });

            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 100)
            {
                Value = entity.Name ?? (object)DBNull.Value
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
