using module3.Data;
using module3.TaskManager;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace module3.Menu
{
    internal class MainMenu
    {
        private readonly IUserTaskManager _userTaskManager;
        private List<UserTask> userTasks;

        public MainMenu(IUserTaskManager userTaskManager, List<UserTask> userTasks)
        {
            _userTaskManager = userTaskManager ?? throw new ArgumentNullException(nameof(userTaskManager));
            this.userTasks = userTasks;
        }

        public void Show()
        {
            var isExit = false;
            while(!isExit)
            {
                Console.WriteLine("1. Добавить задачу");
                Console.WriteLine("2. Обновить задачу");
                Console.WriteLine("3. Удалить задачу");
                Console.WriteLine("4. Получить задачу по id");
                Console.WriteLine("\n0. Выход");

                var key = Console.ReadKey();
                switch (key.KeyChar)
                {
                    case '1':
                        Console.Clear();
                        Create();
                        break;
                    case '2':
                        Console.Clear();
                        Update();
                        break;
                    case '3':
                        Console.Clear();
                        Delete();
                        break;
                    case '4':
                        Console.Clear();
                        GetById();
                        break;
                    case '0':
                        isExit = true;
                        break;

                }
                Console.Clear();

            }
        }

        private void Create()
        {
            Console.WriteLine("Введите название задачи");
            var title = Console.ReadLine();
            Console.WriteLine("Введите описание");
            var description = Console.ReadLine();
            try
            {
                var createdId = _userTaskManager.Add(new Data.UserTask
                {
                    Title = title,
                    Description = description,
                });
                Console.WriteLine($"Добавлена задача с Id = {createdId}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при создании задачи. {e.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
        }
        
        private void Update()
        {
            if (IsListEmpty()) return;

            foreach(var ut in userTasks)
            {
                Console.WriteLine(ut);
            }

            Console.WriteLine("\nУкажите Id задачи для редактирования");
            try
            {
                var id = Console.ReadLine();
                if (userTasks.FirstOrDefault(ut => ut.Id == Convert.ToInt64(id)) == null)
                {
                    Console.WriteLine($"Не найдено задачи с указанным Id = {id}");
                    return;
                }

                Console.WriteLine("Введите новое название задачи");
                var title = Console.ReadLine();
                Console.WriteLine("Введите новое описание задачи");
                var description = Console.ReadLine();

                _userTaskManager.Update(new UserTask
                {
                    Id = Convert.ToInt64(id),
                    Title = title,
                    Description = description,
                });

                Console.WriteLine("Задача успешно обновлена");

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при обновлении задачи. {e.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private void Delete()
        {
            if (IsListEmpty()) return;

            foreach (var ut in userTasks)
            {
                Console.WriteLine(ut);
            }

            Console.WriteLine("\nУкажите Id задачи для удаления");
            try
            {
                var id = Console.ReadLine();
                if (userTasks.FirstOrDefault(ut => ut.Id == Convert.ToInt64(id)) == null)
                {
                    Console.WriteLine($"Не найдено задачи с указанным Id = {id}");
                }

                _userTaskManager.Delete(Convert.ToInt64(id));

                Console.WriteLine("Задача успешно удалена");

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при удалении задачи. {e.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private void GetById()
        {
            Console.WriteLine("\nУкажите Id задачи для поиска");
            try
            {
                var id = Console.ReadLine();
                var ut = _userTaskManager.GetById(Convert.ToInt64(id));

                if (ut == null)
                {
                    Console.WriteLine($"Задачи с Id {id} не найдено");
                }
                Console.WriteLine(ut);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при поиске задачи. {e.Message}");
            }
            finally
            {
                Console.ReadKey();
            }
        }

        private bool IsListEmpty()
        {
            if (userTasks == null || userTasks.Count == 0)
            {
                Console.WriteLine("Список задач пустой");
                Console.ReadKey();
                return true;
            }
            return false;
        }
    }
}
