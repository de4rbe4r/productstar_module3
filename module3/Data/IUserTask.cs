using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module3.Data
{
    /// <summary>
    /// Интерфейс для пользовательской задачи.
    /// </summary>
    internal interface IUserTask
    {
        /// <summary>
        /// Клонировать пользовательскую задачу.
        /// </summary>
        /// <returns>Пользовательская задача.</returns>
        IUserTask Clone();
    }
}
