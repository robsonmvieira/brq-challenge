using System;
using System.ComponentModel.DataAnnotations;

namespace StruckApp.API.ViewModels
{
    public class AddTruckRequest
    {
        [Required(ErrorMessage = "The {0} It's required")]
        public string Model { get; set; }
        
        [Required(ErrorMessage = "The {0} It's required")]
        public int ModelYear { get; set; }
        
        public int YearManufacture = DateTime.UtcNow.Year;
      
    }
}