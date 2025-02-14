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
                Price = saveProductViewModel.Price,
                EAN = saveProductViewModel.EAN,
                ExpirationDate = saveProductViewModel.ExpirationDate,
                RegistrationDate = saveProductViewModel.RegistrationDate
            };
        }
    }
}

