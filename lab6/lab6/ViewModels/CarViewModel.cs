using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace lab6.ViewModels
{
    public class CarViewModel
    {
        public int CarID { get; set; }

        public int? BrandID { get; set; }
        public string BrandName { get; set; }

        public int? OwnerID { get; set; }
        public string OwnerName { get; set; }

        [Display(Name = "Регистрационный номер")]
        public string CarRegistrationNumber { get; set; }

        [Display(Name = "Номер техпаспорта")]
        public string CarNumberOfPassport { get; set; }

        [Display(Name = "Дата выпуска")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? CarReleaseDate { get; set; }

        [Display(Name = "Цвет")]
        public string CarColor { get; set; }
    }
}
