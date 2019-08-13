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

        /// <summary>
        /// Дата регестрации заявки
        /// </summary>
        [Required, Display(Name = "Дата регестрации завки")]
        [DisplayFormat(DataFormatString = "{0:hh:mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Статус завки
        /// </summary>
        [Required, Display(Name = "Текущий статус завки")]
        public Status Status { get; set; }

        [Required, Display(Name = "Название")]
        public string Name { get; set; }

        [Required, Display(Name = "Описание")]
        public string Description { get; set; }

        /// <summary>
        /// История изменений
        /// </summary>
        public ICollection<History> ChangeHistory { get; set; }

    }
}
