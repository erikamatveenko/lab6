using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab6.Models
{
    public partial class Brand
    {
        public Brand()
        {
            Cars = new HashSet<Car>();
        }

        [Key]
        [Display(Name = "Код марки автомобиля")]
        public int BrandID { get; set; }

        [Display(Name = "Наименование")]
        public string BrandName { get; set; }

        [Display(Name = "Фирма-производитель")]
        public string BrandCompany { get; set; }

        [Display(Name = "Страна-производитель")]
        public string BrandCountry { get; set; }

        
        public ICollection<Car> Cars { get; set; }
    }
}
