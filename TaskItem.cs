namespace ToDoConsoleApp;

class TaskItem(string title, bool isDone)
{
    public string Title { get; set; } = title;
    public bool IsDone { get; set; } = isDone; 
}
