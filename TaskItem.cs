namespace ToDoConsoleApp;
internal class TaskItem(string title, bool isDone)
{
    public string Title { get; set; } = title;
    public bool IsDone { get; set; } = isDone;

    public static void AddTask(List<TaskItem> Tasks)
    {
        Console.WriteLine("Enter your new task : ");

        string? userTask = Console.ReadLine();
        if (!String.IsNullOrWhiteSpace(userTask))
        {
            TaskItem task = new(userTask, false);
            Tasks.Add(task);
        }
    }

    public static void DisplayTasks(List<TaskItem> Tasks)
    {
        if (Tasks.Count == 0)
        {
            Console.WriteLine("Your list is empty");
        }
        else
        {
            Console.WriteLine("Your list : ");
        }

        foreach (var item in Tasks)
        {
            if (!item.IsDone)
            {
                Console.WriteLine($"[ ] {item.Title}");
            }
            else
            {
                Console.WriteLine($"[X] {item.Title}");
            }
        }
    }

    public static void CompleteTask(List<TaskItem> Tasks)
    {
        Console.WriteLine("Enter the number of the task you want to complete :");

        LoopOverListOfTasks(Tasks);

        if (UserChoice(Console.ReadLine(), Tasks, out int taskNumber))
        {
            Tasks[taskNumber].IsDone = true;
        }
        else
        {
            Console.WriteLine("Please choose a number in the list");
        }
    }

    public static void RemoveTask(List<TaskItem> Tasks)
    {
        Console.WriteLine("Enter the number of the task you want to remove :");

        LoopOverListOfTasks(Tasks);

        if (UserChoice(Console.ReadLine(), Tasks, out int taskNumberToRemove))
        {
            Tasks.RemoveAt(taskNumberToRemove);
        }
        else
        {
            Console.WriteLine("Please choose a number in the list");
        }
    }

    private static bool UserChoice(string? userChoice, List<TaskItem> Tasks, out int result)
    {
        return int.TryParse(userChoice, out result) && result < Tasks.Count && result > 0;
    }

    private static void LoopOverListOfTasks(List<TaskItem> Tasks)
    {
        for (int i = 0; i < Tasks.Count; i++)
        {
            Console.WriteLine($"{i} : {Tasks[i].Title}");
        }
    }
}
