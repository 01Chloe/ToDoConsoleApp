namespace ToDoConsoleApp;

class TaskService(TaskStorage taskStorage)
{
    public List<TaskItem> Tasks { get; set; } = taskStorage.Load();

    private bool IsValidIndex(int index) => index >= 0 && index < Tasks.Count;

    public bool Add(string? title)
    {
        if (String.IsNullOrWhiteSpace(title))
        {
            return false;
        }
        TaskItem task = new(title, false);
        Tasks.Add(task);
        taskStorage.Save(Tasks);
        return true;
    }

    public bool Complete(int index)
    {
        if(!IsValidIndex(index))
        {
            return false;
        }

        Tasks[index].IsDone = true;
        taskStorage.Save(Tasks);
        return true;
    }

    public bool Uncomplete(int index)
    {
        if (!IsValidIndex(index))
        {
            return false;
        }

        Tasks[index].IsDone = false;
        taskStorage.Save(Tasks);
        return true;
    }

    public bool Remove(int index)
    {
        if (!IsValidIndex(index))
        {
            return false;
        }

        Tasks.RemoveAt(index);
        taskStorage.Save(Tasks);
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
        return [.. Tasks.Where(task => task.Title.Contains(taskSought, StringComparison.CurrentCultureIgnoreCase))];
    }
}
