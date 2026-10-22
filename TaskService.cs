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

    public bool Uncomplete(int index)
    {
        if (!IsValidIndex(index))
        {
            return false;
        }

        Tasks[index].IsDone = false;
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

    public List<TaskItem> GetPendingTasks()
    {
        return [.. Tasks.Where(task => !task.IsDone)];
    }

    public int GetDoneTaskCount()
    {
        return Tasks.Count(task => task.IsDone);
    }

    public List<TaskItem> Search(string taskSought)
    {
        return [.. Tasks.Where(task => task.Title.Contains(taskSought))];
    }
}
