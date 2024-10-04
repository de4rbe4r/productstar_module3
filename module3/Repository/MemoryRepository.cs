using module3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module3.Repository
{
    /// <summary>
    /// Хранение информации в памяти.
    /// </summary>
    internal class MemoryRepository : IRepository
    {
        private List<UserTask> userTasks;

        public MemoryRepository(List<UserTask> userTasks)
        {
            this.userTasks = userTasks;
        }

        public long Add(UserTask userTask)
        {
            userTask.Id = userTasks.Count + 1;
            userTasks.Add(userTask);
            return userTask.Id;
        }

        public void Delete(long id)
        {
            var removedItem = userTasks.FirstOrDefault(u => u.Id == id);
            if (removedItem != null)
            {
                userTasks.Remove(removedItem);
            }
        }

        public UserTask GetById(long id)
        {
            return userTasks.FirstOrDefault(u => u.Id == id);
        }

        public void Update(UserTask userTask)
        {
            var updatedItem = userTasks.FirstOrDefault(u => u.Id == userTask.Id);
            if (updatedItem != null)
            {
                updatedItem.Title = userTask.Title;
                updatedItem.Description = userTask.Description;
            }
        }
    }
}
