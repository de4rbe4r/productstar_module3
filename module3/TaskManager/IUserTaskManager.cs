using module3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module3.TaskManager
{
    /// <summary>
    /// Интерфейс для работы с пользовательскими задачами.
    /// </summary>
    internal interface IUserTaskManager
    {
        /// <summary>
        /// Удалить задачу.
        /// </summary>
        /// <param name="id">Id задачи.</param>
        void Delete(long id);

        /// <summary>
        /// Добавить задачу.
        /// </summary>
        /// <param name="user"><see cref="UserTask"/>.</param>
        /// <returns>Id созданной записи.</returns>
        long Add(UserTask userTask);

        /// <summary>
        /// Получить задачу по Id.
        /// </summary>
        /// <param name="id">Id задачи.</param>
        /// <returns>Пользовательская задача.</returns>
        UserTask GetById(long id);

        /// <summary>
        /// Обновить задачу.
        /// </summary>
        /// <param name="user"><see cref="UserTask"/>.</param>
        void Update(UserTask userTask);

        /// <summary>
        /// Клонировать пользовательскую задачу.
        /// </summary>
        /// <param name="userTask">Пользовательская задача.</param>
        /// <returns>Клонированная пользовательская задача.</returns>
        UserTask Clone(UserTask userTask);
    }
}
