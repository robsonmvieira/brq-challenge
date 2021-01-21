using System;
using System.ComponentModel.DataAnnotations;

namespace StruckApp.API.ViewModels
{
    public class UpdateTruckRequest
    {
        [Required(ErrorMessage = "O {0} não pode ser vazio")]
        public string Modelo { get; set; }
        
        [Required(ErrorMessage = "O {0} não pode ser vazio")]
        public int AnoModelo { get; set; }
        
        public int AnoFabricacao = DateTime.UtcNow.Year;
    }
}