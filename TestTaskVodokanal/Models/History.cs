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

        /// <summary>
        /// Дата снесения изменений
        /// </summary>
        [Required, Display(Name = "Дата внесения изменений")]
        [DisplayFormat(DataFormatString = "{0:hh:mm dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Статус завки
        /// </summary>
        [Required, Display(Name = "Статус")]
        public Status Status { get; set; }

        /// <summary>
        /// Комментарий
        /// </summary>
        [Required, Display(Name = "Комментарий")]
        public string Comment { get; set; }

    }
}
