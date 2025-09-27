using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Villa.Entity.Entities;

namespace Villa.Business.Validators
{
    public class VideoValidator : AbstractValidator<Video>
    {
        public VideoValidator()
        {
            RuleFor(x => x.VideoUrl)
                .NotEmpty().WithMessage("Video linki boş olamaz.")
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("Geçerli bir video linki giriniz.");
        }
    }
}
