using module3.Data;
using module3.Menu;
using module3.Repository;
using module3.TaskManager;

var userTasks = new List<UserTask>();
IRepository repository = new MemoryRepository(userTasks);
IUserTaskManager manager = new UserTaskManager(repository);
var menu = new MainMenu(manager, userTasks);

menu.Show();