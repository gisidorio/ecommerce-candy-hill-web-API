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
    public class PaymentMethodRepository : IPaymentMethodRepository
    {
        private readonly IDbConnectionFactory _connectionFactory;

        public PaymentMethodRepository(IDbConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public void Deactivate(Guid id)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_PaymentMethod_Deactivate";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(
                        new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                        {
                            Value = id
                        });

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<PaymentMethod> GetAll()
        {
            var paymentMethods = new List<PaymentMethod>();

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_PaymentMethod_GetAll";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var paymentMethod = new PaymentMethod
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };

                            paymentMethods.Add(paymentMethod);
                        }
                    }

                    connection.Close();
                }
            }

            return paymentMethods;
        }

        public PaymentMethod? GetById(Guid id)
        {
            PaymentMethod? paymentMethod = null;

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_PaymentMethod_GetById";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(
                        new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                        {
                            Value = id
                        });

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            paymentMethod = new PaymentMethod
                            {
                                Id = reader.GetGuid(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                                IsActive = reader.GetBoolean(reader.GetOrdinal("IsActive")),
                                CreatedAt = reader.GetDateTime(reader.GetOrdinal("CreatedAt"))
                            };
                        }
                    }
                }
            }

            return paymentMethod;
        }

        public Guid Save(PaymentMethod entity)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_PaymentMethod_Insert";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                    {
                        Value = entity.Id
                    });

                    command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar)
                    {
                        Value = entity.Name
                    });

                    command.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)
                    {
                        Value = entity.IsActive
                    });

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            return entity.Id;
        }

        public void Update(PaymentMethod entity)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "usp_PaymentMethod_Update";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.Add(new SqlParameter("@Id", SqlDbType.UniqueIdentifier)
                {
                    Value = entity.Id
                });

                command.Parameters.Add(new SqlParameter("@Name", SqlDbType.VarChar)
                {
                    Value = entity.Name ?? (object)DBNull.Value
                });

                command.Parameters.Add(new SqlParameter("@IsActive", SqlDbType.Bit)
                {
                    Value = entity.IsActive
                });

                connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
