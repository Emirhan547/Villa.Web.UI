using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class SubHeaderValidator:AbstractValidator<SubHeader>
    {
        public SubHeaderValidator()
        {
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres boş olamaz.")
                .MinimumLength(5).WithMessage("Adres en az 5 karakter olmalıdır.")
                .MaximumLength(200).WithMessage("Adres en fazla 200 karakter olabilir.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email boş olamaz.")
                .EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");

            RuleFor(x => x.Facebook)
                .Must(BeAValidUrl).When(x => !string.IsNullOrWhiteSpace(x.Facebook))
                .WithMessage("Geçerli bir Facebook linki giriniz.");

            RuleFor(x => x.Twitter)
                .Must(BeAValidUrl).When(x => !string.IsNullOrWhiteSpace(x.Twitter))
                .WithMessage("Geçerli bir Twitter linki giriniz.");

            RuleFor(x => x.Linkedin)
                .Must(BeAValidUrl).When(x => !string.IsNullOrWhiteSpace(x.Linkedin))
                .WithMessage("Geçerli bir Linkedin linki giriniz.");

            RuleFor(x => x.Instagram)
                .Must(BeAValidUrl).When(x => !string.IsNullOrWhiteSpace(x.Instagram))
                .WithMessage("Geçerli bir Instagram linki giriniz.");
        }

        private bool BeAValidUrl(string url)
        {
            return Uri.IsWellFormedUriString(url, UriKind.Absolute);
        }
    }
}
