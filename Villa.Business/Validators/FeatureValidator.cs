using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class FeatureValidator:AbstractValidator<Feature>
    {
        public FeatureValidator()
        {
            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Resim linki boş olamaz.")
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("Geçerli bir resim linki giriniz.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            RuleFor(x => x.SubTitle)
                .NotEmpty().WithMessage("Alt başlık boş olamaz.")
                .MinimumLength(3).WithMessage("Alt başlık en az 3 karakter olmalıdır.")
                .MaximumLength(200).WithMessage("Alt başlık en fazla 200 karakter olabilir.");

            RuleFor(x => x.Square)
                .NotEmpty().WithMessage("Metrekare bilgisi boş olamaz.")
                .Matches(@"^\d+$").WithMessage("Metrekare sadece rakamlardan oluşmalıdır.");

            RuleFor(x => x.Contract)
                .NotEmpty().WithMessage("Sözleşme bilgisi boş olamaz.")
                .MinimumLength(3).WithMessage("Sözleşme bilgisi en az 3 karakter olmalıdır.");

            RuleFor(x => x.Safety)
                .NotEmpty().WithMessage("Güvenlik bilgisi boş olamaz.")
                .MinimumLength(3).WithMessage("Güvenlik bilgisi en az 3 karakter olmalıdır.");
        }
    }
}
