using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.MapUrl).NotEmpty().WithMessage("Harita linki boş olamaz.");
            RuleFor(x => x.MapUrl).MinimumLength(10).WithMessage("Harita linki en az 10 karakter olmalıdır.");

            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon numarası boş olamaz.");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email adresi boş olamaz.");
        }
    }
}
