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

        public void Deactivate(int id)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductFAQ_Deactivate";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public List<ProductFAQ> GetAll()
        {
            var productFAQs = new List<ProductFAQ>();

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductFAQ_GetAll";
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var productFAQ = new ProductFAQ
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Question = reader["Question"].ToString() ?? string.Empty,
                                Answer = reader["Answer"].ToString() ?? string.Empty,
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            };

                            productFAQs.Add(productFAQ);
                        }
                    }

                    connection.Close();
                }
            }

            return productFAQs;
        }

        public ProductFAQ? GetById(int id)
        {
            ProductFAQ? productFAQ = null;

            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductFAQ_GetById";
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", SqlDbType.Int) { Value = id });

                    connection.Open();

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            productFAQ = new ProductFAQ
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Question = reader["Question"].ToString() ?? string.Empty,
                                Answer = reader["Answer"].ToString() ?? string.Empty,
                                IsActive = Convert.ToBoolean(reader["IsActive"]),
                                CreatedAt = Convert.ToDateTime(reader["CreatedAt"])
                            };
                        }
                    }
                }
            }

            return productFAQ;
        }

        public int Save(ProductFAQ entity)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductFAQ_Insert";
                    command.CommandType = CommandType.StoredProcedure;

                    var ProductIdParameter = command.CreateParameter();
                    ProductIdParameter.ParameterName = "@ProductId";
                    ProductIdParameter.DbType = DbType.Int32;
                    ProductIdParameter.Value = entity.ProductId;
                    command.Parameters.Add(ProductIdParameter);

                    var QuestionParameter = command.CreateParameter();
                    QuestionParameter.ParameterName = "@Question";
                    QuestionParameter.DbType = DbType.String;
                    QuestionParameter.Value = entity.Question;
                    command.Parameters.Add(QuestionParameter);

                    var AnswerParameter = command.CreateParameter();
                    AnswerParameter.ParameterName = "@Answer";
                    AnswerParameter.DbType = DbType.String;
                    AnswerParameter.Value = entity.Answer;
                    command.Parameters.Add(AnswerParameter);

                    var IsActiveParam = command.CreateParameter();
                    IsActiveParam.ParameterName = "@IsActive";
                    IsActiveParam.DbType = DbType.Boolean;
                    IsActiveParam.Value = entity.IsActive;
                    command.Parameters.Add(IsActiveParam);

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

        public void Update(ProductFAQ entity)
        {
            using (var connection = _connectionFactory.CreateDatabaseConnection())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_ProductFAQ_Update";
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

                    var QuestionParameter = command.CreateParameter();
                    QuestionParameter.ParameterName = "@Question";
                    QuestionParameter.DbType = DbType.String;
                    QuestionParameter.Value = entity.Question;
                    command.Parameters.Add(QuestionParameter);

                    var AnswerParameter = command.CreateParameter();
                    AnswerParameter.ParameterName = "@Answer";
                    AnswerParameter.DbType = DbType.String;
                    AnswerParameter.Value = entity.Answer;
                    command.Parameters.Add(AnswerParameter);

                    var IsActiveParam = command.CreateParameter();
                    IsActiveParam.ParameterName = "@IsActive";
                    IsActiveParam.DbType = DbType.Boolean;
                    IsActiveParam.Value = entity.IsActive;
                    command.Parameters.Add(IsActiveParam);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}
