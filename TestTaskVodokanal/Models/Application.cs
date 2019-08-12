using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskVodokanal.Models
{
    public enum Status
    {
        Open,
        Close,
        Return,
        Completed
    }

    /// <summary>
    /// Класс заявок
    /// </summary>
    public class Application
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApplicationID { get; set; }

        /// <summary>
        /// Дата регестрации заявки
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Статус завки
        /// </summary>
        public Status Status { get; set; }

        /// <summary>
        /// История изменений
        /// </summary>
        public ICollection<History> ChangeHistory { get; set; }

    }
}
