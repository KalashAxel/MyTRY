using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcSql.Domain
{
    public class People
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "ФИО")]
        public string FIO { get; set; }
        //Title-FIO TEXT-DATA
        [Display(Name = "Дата рождения")]
        public string Data { get; set; }

        [Display(Name = "Номер телефона")]
        public string Number { get; set; }
    }
}
