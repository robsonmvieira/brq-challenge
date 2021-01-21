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
    }
}