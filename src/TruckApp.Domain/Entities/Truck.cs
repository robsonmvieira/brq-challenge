using FluentValidation;
using TruckApp.Domain.Rules;

namespace TruckApp.Domain.Entities

{
    public class Truck: Entity
    {
        public string Modelo { get; private set; }
        public int AnoFabricacao { get; private set; }
        public int AnoModelo { get; private set; }


        public Truck(string modelo, int anoFabricacao, int anoModelo)
        {
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            AnoModelo = anoModelo;
        }

        public void SetModelo(string modelo)
        {
            Modelo = modelo;
        }

        public void SetAnoModelo(int anoModelo)
        {
            AnoModelo = anoModelo;
        }

        public void IsValid() => new TruckValidator().ValidateAndThrow(this);
    }
}