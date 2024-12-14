using FluentValidation;
using ITIL.Services.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ITIL.Services.Validation
{
    public class CreateCityValidator : AbstractValidator<CreateCityDto>
    {
        private readonly IApplicationDbContext _context;

        public CreateCityValidator(IApplicationDbContext context)
        {
            _context = context;
            RuleFor(x => x.Title).NotEmpty().NotNull();
            
            Func<string,  bool> methodPointer = (title) => {

                var result = _context.CityList
               .All(l => l.Title != title);
                return result;
            };

            RuleFor(x => x.Title).Must(methodPointer)
                .WithMessage("{PropertyName} must be unique.")
                .WithErrorCode("Unique");
        }
        public async Task<bool> BeUnique(string cityTitle, CancellationToken cancellationToken)
        {
            var result = await _context.CityList
                .AllAsync(l => l.Title != cityTitle, cancellationToken);
            return result;
        }
    }
}