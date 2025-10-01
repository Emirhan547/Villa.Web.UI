using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Resim linki boş olamaz.");
                

            RuleFor(x => x.Category)
                .NotEmpty().WithMessage("Kategori boş olamaz.");

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage("Fiyat boş olamaz.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            RuleFor(x => x.BedroomCount)
                .GreaterThan(0).WithMessage("Yatak odası sayısı en az 1 olmalıdır.");

            RuleFor(x => x.BathroomCount)
                .GreaterThan(0).WithMessage("Banyo sayısı en az 1 olmalıdır.");

            RuleFor(x => x.Area)
                .GreaterThan(0).WithMessage("Alan bilgisi 0'dan büyük olmalıdır.");

            RuleFor(x => x.Floor)
                .GreaterThanOrEqualTo(0).WithMessage("Kat bilgisi 0 veya daha büyük olmalıdır.");

            RuleFor(x => x.ParkingCount)
                .GreaterThanOrEqualTo(0).WithMessage("Otopark sayısı 0 veya daha büyük olmalıdır.");
        }
    }
}
