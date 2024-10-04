using module3.Data;
using module3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace module3.TaskManager
{
    internal class UserTaskManager : IUserTaskManager
    {
        private readonly IRepository _repository;

        public UserTaskManager(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public long Add(UserTask userTask)
        {
            return _repository.Add(userTask);
        }

        public UserTask Clone(UserTask userTask)
        {
            return (UserTask)userTask.Clone();
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public UserTask GetById(long id)
        {
            return _repository.GetById(id);
        }

        public void Update(UserTask userTask)
        {
            _repository.Update(userTask);
        }
    }
}
