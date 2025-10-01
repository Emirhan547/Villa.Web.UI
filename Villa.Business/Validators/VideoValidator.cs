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
                .NotEmpty().WithMessage("Video linki boş olamaz.");
                
        }
    }
}
