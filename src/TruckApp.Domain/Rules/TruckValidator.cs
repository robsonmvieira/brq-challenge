using System;
using System.Collections.Generic;
using FluentValidation;
using TruckApp.Domain.Entities;

namespace TruckApp.Domain.Rules
{
    public class TruckValidator: AbstractValidator<Truck>
    {
        private List<string> NameOptions = new List<string>{"FH", "FM"};
        private int Year = DateTime.UtcNow.Year;
        public TruckValidator()
        {
            RuleFor(x => x.Model).Must(
                x => NameOptions.Contains(x)).WithMessage("You can only choose between models: FH and FM");

            RuleFor(x => x.YearManufacture).Must(x => x == Year).WithMessage("The Year must be the current year");
            RuleFor(x => x.ModelYear).GreaterThanOrEqualTo(Year)
                .WithMessage($"Vehicle model year must start from {Year}");
        }
    }
}