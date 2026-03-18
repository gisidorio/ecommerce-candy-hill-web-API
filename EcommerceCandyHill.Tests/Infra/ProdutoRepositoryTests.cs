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
    //public class ProdutoRepositoryTests
    //{
    //    [Fact]
    //    public void GetAll_DeveRetornarListaDeProdutos()
    //    {
    //        var produtosEsperados = new List<Product>
    //        {
    //            new() {
    //                Id = 1,
    //                Name = "Chocolate",
    //                Price = 10,
    //                Description = "",
    //                UrlImagem = "",
    //                DataCadastro = DateTime.MinValue,
    //                Quantity = 5
    //            },
    //            new() {
    //                Id = 2,
    //                Name = "Bala",
    //                Price = 2,
    //                Description = "",
    //                UrlImagem = "",
    //                DataCadastro = DateTime.MinValue,
    //                Quantity = 10
    //            },
    //            new() {
    //                Id = 3,
    //                Name = "Café",
    //                Price = 8,
    //                Description = "",
    //                UrlImagem = "",
    //                DataCadastro = DateTime.MinValue,
    //                Quantity = 7
    //            }
    //        };

    //        var readerMock = new Mock<IDataReader>();
    //        int callCount = -1;
    //        readerMock.Setup(r => r.Read()).Returns(() => ++callCount < produtosEsperados.Count);
    //        readerMock.Setup(r => r["Id"]).Returns(() => produtosEsperados[callCount].Id);
    //        readerMock.Setup(r => r["Nome"]).Returns(() => produtosEsperados[callCount].Name);
    //        readerMock.Setup(r => r["Preco"]).Returns(() => produtosEsperados[callCount].Price);
    //        readerMock.Setup(r => r["Descricao"]).Returns(() => produtosEsperados[callCount].Description ?? "");
    //        readerMock.Setup(r => r["Quantidade"]).Returns(() => produtosEsperados[callCount].Quantity);
    //        readerMock.Setup(r => r["DataCadastro"]).Returns(() => produtosEsperados[callCount].DataCadastro ?? DateTime.MinValue);
    //        readerMock.Setup(r => r["UrlImagem"]).Returns(() => produtosEsperados[callCount].UrlImagem ?? "");

    //        var commandMock = new Mock<IDbCommand>();
    //        commandMock.Setup(c => c.ExecuteReader()).Returns(readerMock.Object);

    //        var connectionMock = new Mock<IDbConnection>();
    //        connectionMock.Setup(c => c.CreateCommand()).Returns(commandMock.Object);

    //        var factoryMock = new Mock<IDbConnectionFactory>();
    //        factoryMock.Setup(f => f.CriarConexaoBaseDeDados()).Returns(connectionMock.Object);

    //        var repository = new ProductRepository(factoryMock.Object);

    //        var resultado = repository.GetAll();

    //        resultado.Should().BeEquivalentTo(produtosEsperados);
    //    }
    //}
}
