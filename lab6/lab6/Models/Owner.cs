using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace lab6.Models
{
    public partial class Owner
    {
        public Owner()
        {
            Cars = new HashSet<Car>();
        }

        [Key]
        [Display(Name = "Код владельца")]
        public int OwnerID { get; set; }

        [Display(Name = "ФИО")]
        public string OwnerName { get; set; }

        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? OwnerBirthDate { get; set; }

        [Display(Name = "Адрес")]
        public string OwnerAddress { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
