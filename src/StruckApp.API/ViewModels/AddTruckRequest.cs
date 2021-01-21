using System.ComponentModel.DataAnnotations;

namespace StruckApp.API.ViewModels
{
    public class AddTruckRequest
    {
        [Required(ErrorMessage = "O {0} não pode ser vazio")]
        public string Modelo { get; private set; }
        [Required(ErrorMessage = "O {0} não pode ser vazio")]
        public int AnoFabricacao { get; private set; }
        [Required(ErrorMessage = "O {0} não pode ser vazio")]
        public int AnoModelo { get; private set; }
    }
}