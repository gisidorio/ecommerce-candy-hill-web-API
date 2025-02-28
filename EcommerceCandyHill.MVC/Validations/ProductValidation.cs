using EcommerceCandyHill.Domain.Entities;
using EcommerceCandyHill.MVC.Models.Save;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EcommerceCandyHill.Application.Validations.Interfaces;

namespace EcommerceCandyHill.Application.Validations
{
    public class ProductValidator : AbstractValidator<SaveProductViewModel>, IProductValidator
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("O nome do produto é obrigatório")
                .MinimumLength(3).WithMessage("O nome deve ter pelo ou menos 3 caracteres");

            RuleFor(p => p.Price)
                .NotEmpty().WithMessage("O valor não pode ser zero ou vazio!")
                .Matches(@"^\d+(\.\d{1,2})?$").WithMessage("O preço deve ser um número decimal válido com até duas casas decimais.");
                

            RuleFor(p => p.EAN)
                .NotEmpty().WithMessage("O preenchimento do campo EAN é obrigatório!")
                .MinimumLength(8).WithMessage("O EAN possui 8 dígitos ou 13 dígitos!")
                .MaximumLength(13).WithMessage("O EAN possui 8 dígitos ou 13 dígitos!")
                .Matches("^[0-9]+$").WithMessage("O campo EAN deve conter apenas números!");

            RuleFor(p => p.ExpirationDate)
                .NotEmpty().WithMessage("O preenchimento do campo data de validade deve ser preenchido!")
                .GreaterThan(DateTime.Now).WithMessage("A data de validade é obrigatória, deve ser maior que data atual e menor que 31/12/9999!");
            
        }
    }
}
