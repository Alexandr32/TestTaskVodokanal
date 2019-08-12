using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskVodokanal.Models
{
    public enum Status
    {
        [Display(Name = "Открыта")]
        Open,
        [Display(Name = "Закрыта")]
        Close,
        [Display(Name = "Возврат")]
        Return,
        [Display(Name = "Выполнено")]
        Completed
    }

    /// <summary>
    /// Класс заявок
    /// </summary>
    public class Application
    {
        public int ApplicationID { get; set; }

        [Required]
        /// <summary>
        /// Дата регестрации заявки
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        [Required]
        /// <summary>
        /// Статус завки
        /// </summary>
        public Status Status { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// История изменений
        /// </summary>
        public ICollection<History> ChangeHistory { get; set; }

    }
}
