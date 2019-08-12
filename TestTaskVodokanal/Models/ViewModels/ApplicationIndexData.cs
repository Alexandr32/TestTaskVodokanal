using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestTaskVodokanal.Models.ViewModels
{
    /// <summary>
    /// Ипользуется для сортировки и выбора данных об заявке
    /// </summary>
    public class ApplicationIndexData
    {
        /// <summary>
        /// Выбранная заявка
        /// </summary>
        public IEnumerable<Application> Applications { get; set; }
        /// <summary>
        /// История завки
        /// </summary>
        public IEnumerable<History> Historys { get; set; }
    }
}
