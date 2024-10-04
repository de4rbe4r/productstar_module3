using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module3.Data
{
    /// <summary>
    /// Пользовательская задача.
    /// </summary>
    internal class UserTask : IUserTask
    {
        /// <summary>
        /// Идентификатор.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Описание.
        /// </summary>
        public string Description { get; set; }

        public IUserTask Clone()
        {
            return new UserTask
            {
                Title = this.Title,
                Description = this.Description,
            };
        }

        public override string ToString()
        {
            return $"{Id}. {Title}\n{Description}";
        }
    }
}
