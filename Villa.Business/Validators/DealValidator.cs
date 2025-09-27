using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class DealValidator : AbstractValidator<Deal>
    {
        public DealValidator()
        {
            RuleFor(x => x.Type)
                .NotEmpty().WithMessage("İlan türü boş olamaz.")
                .MinimumLength(3).WithMessage("İlan türü en az 3 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("İlan türü en fazla 50 karakter olabilir.");

            RuleFor(x => x.ImageUrl)
                .NotEmpty().WithMessage("Resim linki boş olamaz.")
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("Geçerli bir resim linki giriniz.");

            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Başlık boş olamaz.")
                .MinimumLength(5).WithMessage("Başlık en az 5 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Açıklama boş olamaz.")
                .MinimumLength(20).WithMessage("Açıklama en az 20 karakter olmalıdır.");

            RuleFor(x => x.Square)
                .NotEmpty().WithMessage("Metrekare bilgisi boş olamaz.")
                .Matches(@"^\d+$").WithMessage("Metrekare sadece rakamlardan oluşmalıdır.");

            RuleFor(x => x.Floor)
                .NotEmpty().WithMessage("Kat bilgisi boş olamaz.")
                .Matches(@"^\d+$").WithMessage("Kat bilgisi sadece rakamlardan oluşmalıdır.");

            RuleFor(x => x.RoomCount)
                .GreaterThan(0).WithMessage("Oda sayısı en az 1 olmalıdır.");

            RuleFor(x => x.PaymentType)
                .NotEmpty().WithMessage("Ödeme türü boş olamaz.")
                .MinimumLength(3).WithMessage("Ödeme türü en az 3 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Ödeme türü en fazla 50 karakter olabilir.");
        }
    }
}
