using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class BannerValidator:AbstractValidator<Banner>
    {
        public BannerValidator()
        {
            RuleFor(x => x.City).NotEmpty().WithMessage("Şehir boş bırakılamaz");
            RuleFor(x => x.City).MinimumLength(2).WithMessage("Minimum 2 karakter giriniz");
            RuleFor(x => x.City).MaximumLength(50).WithMessage("Maksimum 50 karakter girebilirsiniz");

            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş bırakılamaz");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Minimum 3 karakter giriniz");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Maksimum 100 karakter girebilirsiniz");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim URL boş bırakılamaz");
                
        }
    }
}
