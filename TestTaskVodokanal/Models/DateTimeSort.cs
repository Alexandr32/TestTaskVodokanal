using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskVodokanal.Models
{
    /// <summary>
    /// Класс для сортировки данных по времени
    /// </summary>
    public class DateTimeSort
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Начальная дата")]
        public DateTime DateTimeMin { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Конечная дата")]
        public DateTime DateTimeMax { get; set; }

    }
}
