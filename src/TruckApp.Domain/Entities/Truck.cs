using System;
using System.Collections.Generic;
using FluentValidation;
using FluentValidation.Results;
using TruckApp.Core.DomainObject;
using TruckApp.Domain.Rules;

namespace TruckApp.Domain.Entities

{
    public class Truck: Entity
    {
        public string Model { get; private set; }
        public int YearManufacture { get; private set; }
        public int ModelYear { get; private set; }


        public Truck(string model, int yearManufacture, int modelYear)
        {
            Model = model;
            YearManufacture = yearManufacture;
            ModelYear = modelYear;
        }

        public void SetModel(string model)
        {
            List<string> optionsName = new List<string> {"FM", "FH"};
            if (!optionsName.Contains(model)) throw new DomainException("O modelo do veículo só pode ser FH ou FM");
            Model = model;
        }

        public void SetYearModel(int modelYear)
        {
            if (modelYear < DateTime.Now.Year)
                throw new DomainException("O Ano do modelo não pode ser inferior ao ano Atual");
            ModelYear = modelYear;
        }

        public ValidationResult IsValid() => new TruckValidator().Validate(this);
    }
}