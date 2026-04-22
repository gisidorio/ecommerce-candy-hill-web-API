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
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public UserRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task AddRolesToUserAsync(Guid userId, IEnumerable<Guid> roleIds)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_UserRole_InsertBatch";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.UniqueIdentifier)
            {
                Value = userId
            });

            var table = CreateRoleIdsTable(roleIds);

            command.Parameters.Add(new SqlParameter("@RoleIds", SqlDbType.Structured)
            {
                TypeName = "dbo.RoleIdList",
                Value = table
            });

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task DeactivateAsync(Guid id)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_User_Deactivate";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = id
            });

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<User>> GetAllAsync()
        {
            var users = new List<User>();

            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_User_GetAll";
            command.CommandType = CommandType.StoredProcedure;

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var user = new User
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                    IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                };

                users.Add(user);
            }

            return users;
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            User? user = null;

            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_User_GetById";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = id
            });

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                user = new User
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    Name = reader.GetString(reader.GetOrdinal("Name")),
                    Email = reader.GetString(reader.GetOrdinal("Email")),
                    PasswordHash = reader.GetString(reader.GetOrdinal("PasswordHash")),
                    IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                };
            }

            return user;
        }

        public async Task<Guid> SaveAsync(User user)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_User_Insert";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = user.Id
            });

            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 100)
            {
                Value = user.Name
            });

            command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 150)
            {
                Value = user.Email
            });

            command.Parameters.Add(new SqlParameter("@PasswordHash", SqlDbType.VarChar, 255)
            {
                Value = user.PasswordHash
            });

            command.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)
            {
                Value = user.IsActive
            });

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();

            return user.Id;
        }

        public async Task UpdateAsync(User user)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_User_Update";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = user.Id
            });

            command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar, 100)
            {
                Value = user.Name ?? (object)DBNull.Value
            });

            command.Parameters.Add(new SqlParameter("@Email", SqlDbType.VarChar, 150)
            {
                Value = user.Email ?? (object)DBNull.Value
            });

            command.Parameters.Add(new SqlParameter("@PasswordHash", SqlDbType.VarChar, 255)
            {
                Value = user.PasswordHash ?? (object)DBNull.Value
            });

            command.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)
            {
                Value = user.IsActive
            });

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task UpdateRolesToUserAsync(Guid userId, IEnumerable<Guid> roleIds)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_UserRole_UpdateBatch";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.UniqueIdentifier)
            {
                Value = userId
            });

            var table = CreateRoleIdsTable(roleIds);

            command.Parameters.Add(new SqlParameter("@RoleIds", SqlDbType.Structured)
            {
                TypeName = "dbo.RoleIdList",
                Value = table
            });

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        private static DataTable CreateRoleIdsTable(IEnumerable<Guid> roleIds)
        {
            var table = new DataTable();
            table.Columns.Add("RoleId", typeof(Guid));

            foreach (var roleId in roleIds)
            {
                table.Rows.Add(roleId);
            }

            return table;
        }
    }
}
