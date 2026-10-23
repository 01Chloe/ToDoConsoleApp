namespace ToDoConsoleApp;

class ToDoConsoleApp
{
    static void Main (string[] args)
    {
        TaskStorage taskStorage = new();
        TaskService taskService = new(taskStorage);
        DisplayTasks displayTasks = new(taskService);

        displayTasks.Run();
    }    
}