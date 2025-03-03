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
                Name = saveProductViewModel.Name,
                Description = saveProductViewModel.Description,
                Price = ConversorHelper.ConverterParaDecimal(saveProductViewModel.Price),
                ExpirationDate = saveProductViewModel.ExpirationDate
            };
        }
    }
}

