using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class CounterValidator:AbstractValidator<Counter>
    {
        public CounterValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Başlık boş olamaz.");
            RuleFor(x => x.Title).MinimumLength(3).WithMessage("Başlık en az 3 karakter olmalıdır.");
            RuleFor(x => x.Title).MaximumLength(100).WithMessage("Başlık en fazla 100 karakter olabilir.");

            RuleFor(x => x.Count).NotEmpty().WithMessage("Sayı alanı boş olamaz.");
               
        }
    }
    }

