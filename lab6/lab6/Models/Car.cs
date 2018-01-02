using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab6.Models
{
    public partial class Car
    {
    

        [Key]
        [Display(Name = "Код автомобиля")]
        public int CarID { get; set; }
        public int? BrandID { get; set; }
        public int? OwnerID { get; set; }

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
      
        public virtual Brand Brand { get; set; }
        public virtual Owner Owner { get; set; }
       
    }
}
