using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
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

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetAll()
        {
            throw new NotImplementedException();
        }

        public User? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public long Save(User user)
        {
            using (var connection = _connectionFactory.CriarConexaoBaseDeDados())
            {
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = "usp_User_Insert";
                    command.CommandType = CommandType.StoredProcedure;

                    var NameParam = command.CreateParameter();
                    NameParam.ParameterName = "@Name";
                    NameParam.DbType = DbType.String;
                    NameParam.Value = user.Name;
                    command.Parameters.Add(NameParam);

                    var EmailParam = command.CreateParameter();
                    EmailParam.ParameterName = "@Email";
                    EmailParam.DbType = DbType.String;
                    EmailParam.Value = user.Email;
                    command.Parameters.Add(EmailParam);                    

                    var PasswordHash = command.CreateParameter();
                    PasswordHash.ParameterName = "@PasswordHash";
                    PasswordHash.DbType = DbType.String;
                    EmailParam.Value = user.PasswordHash;
                    command.Parameters.Add(PasswordHash);

                    var RegistrationDateParam = command.CreateParameter();
                    RegistrationDateParam.ParameterName = "@RegistrationDate";
                    RegistrationDateParam.DbType = DbType.DateTime;
                    RegistrationDateParam.Value = user.RegistrationDate;
                    command.Parameters.Add(RegistrationDateParam);

                    var outputIdParam = command.CreateParameter();
                    outputIdParam.ParameterName = "@Id";
                    outputIdParam.DbType = DbType.Int32;
                    outputIdParam.Direction = ParameterDirection.Output;
                    command.Parameters.Add(outputIdParam);

                    connection.Open();

                    command.ExecuteNonQuery();

                    user.Id = Convert.ToInt32(outputIdParam.Value);

                    connection.Close();
                }
            }

            return user.Id;
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
