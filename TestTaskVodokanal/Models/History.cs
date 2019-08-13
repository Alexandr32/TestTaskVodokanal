using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskVodokanal.Models
{
    public class History
    {
        public int HistoryID { get; set; }

        public int ApplicationId { get; set; }

        [Required, Display(Name = "Дата внесения изменений")]
        /// <summary>
        /// Дата снесения изменений
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        [Required, Display(Name = "Статус")]
        /// <summary>
        /// Статус завки
        /// </summary>
        public Status Status { get; set; }

        [Required, Display(Name = "Комментарий")]
        /// <summary>
        /// Комментарий
        /// </summary>
        public string Comment { get; set; }

    }
}
