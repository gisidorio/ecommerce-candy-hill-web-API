using EcommerceCandyHill.Application.Interfaces;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.Services.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceCandyHill.Tests.Services
{
    public class ProdutoServiceTests
    {
        private readonly Mock<IProductAppService> _mockProductAppService;
        private readonly ProductService _productService;

        public ProdutoServiceTests()
        {
            _mockProductAppService = new Mock<IProductAppService>();
            _productService = new ProductService(_mockProductAppService.Object);
        }

        [Fact]
        public void GetAll_DeveRetornarListaDeProdutos_QuandoExistiremProdutos()
        {
            var listaProdutos = CriarProdutosDeTeste();

            ConfigurarMock(listaProdutos);

            var resultado = _productService.GetAll();

            resultado.Should().NotBeNull();
            resultado.Should().BeEquivalentTo(listaProdutos);

            _mockProductAppService.Verify(app => app.GetAll(), Times.Once);
        }

        private List<Produto> CriarProdutosDeTeste()
        {
            var produtosEsperados = new List<Produto>
            {
                new() { Id = 1, Nome = "Chocolate", Preco = 10 },
                new() { Id = 2, Nome = "Bala de Goma", Preco = 5 }
            };

            return produtosEsperados;
        }

        private void ConfigurarMock(List<Produto> produtos)
        {
            _mockProductAppService
                .Setup(app => app.GetAll())
                .Returns(produtos);
        }
    }
}
