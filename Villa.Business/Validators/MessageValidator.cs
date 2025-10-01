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
                .NotEmpty().WithMessage("Ad soyad boş olamaz.");


            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş olamaz.");


            RuleFor(x => x.Subject)
                .NotEmpty().WithMessage("Konu boş olamaz.");


            RuleFor(x => x.MessageContent)
                .NotEmpty().WithMessage("Mesaj içeriği boş olamaz.");
  
        }
    }
}
