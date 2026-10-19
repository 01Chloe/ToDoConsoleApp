namespace ToDoConsoleApp;

class ToDoConsoleApp
{
    static void Main (string[] args)
    {
        TaskService taskService = new();
        DisplayTasks displayTasks = new(taskService);

        displayTasks.Run();
    }    
}