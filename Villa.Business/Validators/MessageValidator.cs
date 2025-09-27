using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Ad soyad boş olamaz.")
                .MinimumLength(2).WithMessage("Ad soyad en az 2 karakter olmalıdır.")
                .MaximumLength(50).WithMessage("Ad soyad en fazla 50 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Konu boş olamaz.")
                .MinimumLength(3).WithMessage("Konu en az 3 karakter olmalıdır.")
                .MaximumLength(100).WithMessage("Konu en fazla 100 karakter olabilir.");

            RuleFor(x => x.MessageContent)
                .NotEmpty().WithMessage("Mesaj içeriği boş olamaz.")
                .MinimumLength(10).WithMessage("Mesaj içeriği en az 10 karakter olmalıdır.");

            RuleFor(x => x.MessageDate)
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Mesaj tarihi bugünden ileri olamaz.");
        }
    }
}
