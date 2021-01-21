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
            RuleFor(x => x.Modelo).Must(
                x => NameOptions.Contains(x)).WithMessage("Você só pode Escolher Entre  os modelos: FH e FM");

            RuleFor(x => x.AnoFabricacao).Must(x => x == Year).WithMessage("O Ano deve ser o ano atual");
            RuleFor(x => x.AnoModelo).GreaterThanOrEqualTo(Year)
                .WithMessage($"O ano modelo do  veículo deve se a partir de {Year}");
        }
    }
}