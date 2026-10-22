namespace ToDoConsoleApp;

class DisplayTasks (TaskService taskService)
{
    public void Run()
    {
        Console.WriteLine("Welcome into your todo!");
        Console.WriteLine("Choose an action, then press enter :");

        string? option = "";
        while (option != "e" && option != "E")
        {
            ShowMenu();
            option = Console.ReadLine();

            switch (option?.ToLower())
            {
                case "1":
                    AddTask();

                    break;
                case "2":
                    CompleteTask();

                    break;
                case "3":
                    RemoveTask();

                    break;
                case "4":
                    Display(taskService.Tasks);

                    break;
                case "5":
                    UncompleteTask();

                    break;
                case "6":
                    Display(taskService.GetPendingTasks());

                    break;
                case "7":
                    SearchTask();

                    break;
                case "e":
                    Console.WriteLine("Exit program.");
                    break;
                default:
                    Console.WriteLine("Please choose a valid option.");
                    break;
            }
        }
    }

    private static void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine("- 1 : Add a task.");
        Console.WriteLine("- 2 : Complete a task.");
        Console.WriteLine("- 3 : Remove a task.");
        Console.WriteLine("- 4 : View all tasks.");
        Console.WriteLine("- 5 : Uncomplete a task.");
        Console.WriteLine("- 6 : View pending tasks.");
        Console.WriteLine("- 7 : Looking for a task.");
        Console.WriteLine("- e or E : Exit the program.");
    }

    private void AddTask()
    {
        Console.WriteLine("Enter your new task : ");
        string? title = Console.ReadLine();

        if (!taskService.Add(title))
        {
            Console.WriteLine("A task cannot be empty.");
        }
    }

    private void CompleteTask()
    {
        Console.WriteLine("Enter the number of the task you want to complete :");

        LoopOverListOfTasks();

        if (UserChoice(Console.ReadLine(), taskService.Tasks, out int index))
        {
            taskService.Complete(index);
        }
        else
        {
            Console.WriteLine("Please choose a number in the list");
        }
    }

    private void UncompleteTask()
    {
        Console.WriteLine("Enter the number of the task you want to uncomplete :");

        LoopOverListOfTasks();

        if (UserChoice(Console.ReadLine(), taskService.Tasks, out int index))
        {
            taskService.Uncomplete(index);
        }
        else
        {
            Console.WriteLine("Please choose a number in the list");
        }
    }

    private void RemoveTask()
    {
        Console.WriteLine("Enter the number of the task you want to remove :");

        LoopOverListOfTasks();

        if (UserChoice(Console.ReadLine(), taskService.Tasks, out int index))
        {
            taskService.Remove(index);
        }
        else
        {
            Console.WriteLine("Please choose a number in the list");
        }
    }

    private void Display(IEnumerable<TaskItem> tasks)
    {
        if (!tasks.Any())
        {
            Console.WriteLine("Your list is empty");
        }
        else
        {
            Console.WriteLine("Your list : ");
        }

        foreach (var item in tasks)
        {
            string box = item.IsDone ? "[X]" : "[ ]";
            Console.WriteLine($"{box} {item.Title}");
        }
        Console.WriteLine($"{taskService.GetDoneTaskCount()} tasks completed out of {tasks.Count()}");
    }

    private void SearchTask()
    {
        Console.WriteLine("Task sought : ");

        string? userTaskSearch = Console.ReadLine();

        if (userTaskSearch != null)
        {
            List<TaskItem> taskSought = taskService.Search(userTaskSearch);

            Console.WriteLine("There is your task : ");
            foreach (TaskItem item in taskSought)
            {
                Console.WriteLine(item.Title);
            }
        }
    }

    private void LoopOverListOfTasks()
    {
        List<TaskItem> tasks = taskService.Tasks;

        if (tasks.Count == 0)
        {
            Console.WriteLine("Your list is empty !");
        }
        else
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"{i} : {tasks[i].Title}");
            }
        }
    }

    private static bool UserChoice(string? userChoice, List<TaskItem> Tasks, out int result)
    {
        return int.TryParse(userChoice, out result) && result < Tasks.Count && result >= 0;
    }
}
