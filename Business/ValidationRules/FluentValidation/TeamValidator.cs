using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class TeamValidator : AbstractValidator<Team>
    {
        public TeamValidator()
        {
            RuleFor(t => t.TeamName).NotEmpty().WithMessage("Takım adı boş geçilemez");
            RuleFor(t => t.CountryId).NotEmpty().WithMessage("Takımların ülke id leri boş olamaz");
            RuleFor(t => t.TeamName).MinimumLength(2).WithMessage("takım adı en az 2 karakter olmalı");
        }
    }
}
