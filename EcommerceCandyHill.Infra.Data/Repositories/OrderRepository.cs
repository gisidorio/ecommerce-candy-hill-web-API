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
    public class OrderRepository : IOrderRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public OrderRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public async Task DeactivateAsync(Guid id)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_PaymentMethod_Deactivate";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = id
            });

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            var orders = new List<Order>();

            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_Order_GetAll";
            command.CommandType = CommandType.StoredProcedure;

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                var order = new Order
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    OrderNumber = reader.GetInt64(reader.GetOrdinal("OrderNumber")),
                    UserId = reader.GetGuid(reader.GetOrdinal("UserId")),
                    PaymentMethodId = reader.GetGuid(reader.GetOrdinal("PaymentMethodId")),
                    Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                    Status = reader.GetString(reader.GetOrdinal("Status")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                };

                orders.Add(order);
            }

            return orders;
        }

        public async Task<Order?> GetByIdAsync(Guid id)
        {
            Order? order = null;

            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_Order_GetById";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = id
            });

            await connection.OpenAsync();

            await using var reader = await command.ExecuteReaderAsync();

            if (await reader.ReadAsync())
            {
                order = new Order
                {
                    Id = reader.GetGuid(reader.GetOrdinal("Id")),
                    OrderNumber = reader.GetInt64(reader.GetOrdinal("OrderNumber")),
                    UserId = reader.GetGuid(reader.GetOrdinal("UserId")),
                    PaymentMethodId = reader.GetGuid(reader.GetOrdinal("PaymentMethodId")),
                    Total = reader.GetDecimal(reader.GetOrdinal("Total")),
                    Status = reader.GetString(reader.GetOrdinal("Status")),
                    CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                };
            }

            return order;
        }

        public async Task<Guid> SaveAsync(Order entity)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_Order_InsertWithItems";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = entity.Id
            });

            command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.UniqueIdentifier)
            {
                Value = entity.UserId
            });

            command.Parameters.Add(new SqlParameter("@PaymentMethodId", SqlDbType.UniqueIdentifier)
            {
                Value = entity.PaymentMethodId
            });

            command.Parameters.Add(new SqlParameter("@Total", SqlDbType.Decimal)
            {
                Precision = 10,
                Scale = 2,
                Value = entity.Total
            });

            command.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar, 50)
            {
                Value = entity.Status
            });

            var itemsParam = new SqlParameter("@Items", SqlDbType.Structured)
            {
                TypeName = "dbo.OrderItemType",
                Value = CreateOrderItemsTable(entity.Items)
            };

            command.Parameters.Add(itemsParam);

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(Order entity)
        {
            await using var connection = _connectionFactory.CreateDatabaseConnection();
            await using var command = connection.CreateCommand();

            command.CommandText = "usp_Order_Update";
            command.CommandType = CommandType.StoredProcedure;

            command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
            {
                Value = entity.Id
            });

            command.Parameters.Add(new SqlParameter("@OrderNumber", SqlDbType.BigInt)
            {
                Value = entity.OrderNumber
            });

            command.Parameters.Add(new SqlParameter("@UserId", SqlDbType.UniqueIdentifier)
            {
                Value = entity.UserId
            });

            command.Parameters.Add(new SqlParameter("@PaymentMethodId", SqlDbType.UniqueIdentifier)
            {
                Value = entity.PaymentMethodId
            });

            command.Parameters.Add(new SqlParameter("@Total", SqlDbType.Decimal)
            {
                Value = entity.Total
            });

            command.Parameters.Add(new SqlParameter("@Status", SqlDbType.VarChar)
            {
                Value = entity.Status
            });

            await connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        private static DataTable CreateOrderItemsTable(IEnumerable<OrderItem> items)
        {
            var table = new DataTable();

            table.Columns.Add("OrderId", typeof(Guid));
            table.Columns.Add("ProductId", typeof(Guid));
            table.Columns.Add("ProductName", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("UnitPrice", typeof(decimal));
            table.Columns.Add("Subtotal", typeof(decimal));

            foreach (var item in items)
            {
                table.Rows.Add(
                    item.OrderId,
                    item.ProductId,
                    item.ProductName,
                    item.Quantity,
                    item.UnitPrice,
                    item.Subtotal
                );
            }

            return table;
        }
    }
}
