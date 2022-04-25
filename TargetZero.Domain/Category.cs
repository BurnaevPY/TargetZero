using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TargetZero.Domain
{
    /// <summary>
    /// Категория предложения
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
    }
}
