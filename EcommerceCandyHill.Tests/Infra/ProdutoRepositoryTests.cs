using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Infra.Data;
using EcommerceCandyHill.Infra.Data.Repositories;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Tests.Infra
{
    public class ProdutoRepositoryTests
    {
        [Fact]
        public void GetAll_DeveRetornarListaDeProdutos()
        {
            var produtosEsperados = new List<Produto>
            {
                new() {
                    Id = 1,
                    Nome = "Chocolate",
                    Preco = 10,
                    Descricao = "",
                    UrlImagem = "",
                    DataCadastro = DateTime.MinValue,
                    Quantidade = 5
                },
                new() {
                    Id = 2,
                    Nome = "Bala",
                    Preco = 2,
                    Descricao = "",
                    UrlImagem = "",
                    DataCadastro = DateTime.MinValue,
                    Quantidade = 10
                },
                new() {
                    Id = 3,
                    Nome = "Café",
                    Preco = 8,
                    Descricao = "",
                    UrlImagem = "",
                    DataCadastro = DateTime.MinValue,
                    Quantidade = 7
                }
            };

            var readerMock = new Mock<IDataReader>();
            int callCount = -1;
            readerMock.Setup(r => r.Read()).Returns(() => ++callCount < produtosEsperados.Count);
            readerMock.Setup(r => r["Id"]).Returns(() => produtosEsperados[callCount].Id);
            readerMock.Setup(r => r["Nome"]).Returns(() => produtosEsperados[callCount].Nome);
            readerMock.Setup(r => r["Preco"]).Returns(() => produtosEsperados[callCount].Preco);
            readerMock.Setup(r => r["Descricao"]).Returns(() => produtosEsperados[callCount].Descricao ?? "");
            readerMock.Setup(r => r["Quantidade"]).Returns(() => produtosEsperados[callCount].Quantidade);
            readerMock.Setup(r => r["DataCadastro"]).Returns(() => produtosEsperados[callCount].DataCadastro ?? DateTime.MinValue);
            readerMock.Setup(r => r["UrlImagem"]).Returns(() => produtosEsperados[callCount].UrlImagem ?? "");

            var commandMock = new Mock<IDbCommand>();
            commandMock.Setup(c => c.ExecuteReader()).Returns(readerMock.Object);

            var connectionMock = new Mock<IDbConnection>();
            connectionMock.Setup(c => c.CreateCommand()).Returns(commandMock.Object);

            var factoryMock = new Mock<IDbConnectionFactory>();
            factoryMock.Setup(f => f.CriarConexaoBaseDeDados()).Returns(connectionMock.Object);

            var repository = new ProductRepository(factoryMock.Object);

            var resultado = repository.GetAll();

            resultado.Should().BeEquivalentTo(produtosEsperados);
        }
    }
}
