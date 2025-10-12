using EcommerceCandyHill.Application.Util;
using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.MVC.Models.Save;


namespace EcommerceCandyHill.MVC.Mapper
{
    public static class ProductMapper
    {
        public static Product ConvertViewModelToEntity(SaveProductViewModel saveProductViewModel)
        {
            return new Product
            {
                Nome = saveProductViewModel.Nome,
                Descricao = saveProductViewModel.Descricao,
                Preco = ConversorHelper.ConverterParaDecimal(saveProductViewModel.Preco),
                DataCadastro = saveProductViewModel.Data_Cadastro
            };
        }
    }
}

