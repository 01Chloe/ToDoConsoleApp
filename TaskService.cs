namespace ToDoConsoleApp;

class TaskService
{
    public List<TaskItem> Tasks { get; set; } = [];

    private bool IsValidIndex(int index) => index >= 0 && index < Tasks.Count;

    public bool Add(string? title)
    {
        if (String.IsNullOrWhiteSpace(title))
        {
            return false;
        }
        TaskItem task = new(title, false);
        Tasks.Add(task);
        return true;
    }

    public bool Complete(int index)
    {
        if(!IsValidIndex(index))
        {
            return false;
        }

        Tasks[index].IsDone = true;
        return true;
    }

    public bool Remove(int index)
    {
        if (!IsValidIndex(index))
        {
            return false;
        }

        Tasks.RemoveAt(index);
        return true;
    }
}
