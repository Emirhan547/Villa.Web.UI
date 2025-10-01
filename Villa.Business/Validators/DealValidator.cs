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
            RuleFor(x => x.Type).NotEmpty().WithMessage("İlan türü boş olamaz.");
            RuleFor(x => x.Type).MinimumLength(3).WithMessage("İlan türü en az 3 karakter olmalıdır.");
            RuleFor(x => x.Type).MaximumLength(50).WithMessage("İlan türü en fazla 50 karakter olabilir.");

            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Resim linki boş olamaz.");


            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz.");
            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık en az 5 karakter olmalıdır.");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("Açıklama boş olamaz.");
            RuleFor(x => x.Description).MinimumLength(20).WithMessage("Açıklama en az 20 karakter olmalıdır.");

            RuleFor(x => x.Square).NotEmpty().WithMessage("Metrekare bilgisi boş olamaz.");

            RuleFor(x => x.Floor).NotEmpty().WithMessage("Kat bilgisi boş olamaz.");

            RuleFor(x => x.RoomCount)
                .GreaterThan(0).WithMessage("Oda sayısı en az 1 olmalıdır.");

            RuleFor(x => x.PaymentType).NotEmpty().WithMessage("Ödeme türü boş olamaz.");
            RuleFor(x => x.PaymentType).MinimumLength(3).WithMessage("Ödeme türü en az 3 karakter olmalıdır.");
            RuleFor(x => x.PaymentType).MaximumLength(50).WithMessage("Ödeme türü en fazla 50 karakter olabilir.");
        }
    }
}
