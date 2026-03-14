using EcommerceCandyHill.Application.Interfaces;
using EcommerceCandyHill.Domain.Entities;
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
        //private readonly ProductService _productService;

        public ProdutoServiceTests()
        {
            _mockProductAppService = new Mock<IProductAppService>();
            //_productService = new ProductService(_mockProductAppService.Object);
        }

        [Fact]
        public void GetAll_DeveRetornarListaDeProdutos_QuandoExistiremProdutos()
        {
            var listaProdutos = CriarProdutosDeTeste();

            ConfigurarMock(listaProdutos);

            //var resultado = _productService.GetAll();

            //resultado.Should().NotBeNull();
            //resultado.Should().BeEquivalentTo(listaProdutos);

            _mockProductAppService.Verify(app => app.GetAll(), Times.Once);
        }

        private List<Product> CriarProdutosDeTeste()
        {
            var produtosEsperados = new List<Product>
            {
                new() { Id = 1, Name = "Chocolate", Price = 10 },
                new() { Id = 2, Name = "Bala de Goma", Price = 5 }
            };

            return produtosEsperados;
        }

        private void ConfigurarMock(List<Product> produtos)
        {
            _mockProductAppService
                .Setup(app => app.GetAll())
                .Returns(produtos);
        }
    }
}
