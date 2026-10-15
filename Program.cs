namespace ToDoConsoleApp;

class ToDoConsoleApp
{
    public static List<string> Tasks { get; set; } = new List<string>();

    static void Main (string[] args)
    {
        Console.WriteLine("Welcome into your todo!");
        Console.WriteLine("Choose an action, then press enter :");

        string? option = "";
        while (option != "e")
        {
            Console.WriteLine();
            Console.WriteLine("*1 : Add a task.");
            Console.WriteLine("*2 : Complete a task.");
            Console.WriteLine("*3 : Remove a task.");
            Console.WriteLine("*4 : View all tasks.");
            Console.WriteLine("*e : Exit the program.");

            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Console.WriteLine("Enter your new task : ");
                    
                    string? userTask = Console.ReadLine();
                    if (userTask != null)
                    {
                        Tasks.Add(userTask);
                    }

                    break;
                case "2":
                    Console.WriteLine("Enter the number of the task you want to complete :");
                    
                    LoopOverListOfTasks();
                    
                    int taskNumber = UserChoice(Console.ReadLine());
                    if (taskNumber != -1)
                    {
                        Tasks[taskNumber] = $"~{Tasks[taskNumber]}~";
                    } 
                    else
                    {
                        Console.WriteLine("Please choose a number in the list");
                    }

                    break; 
                case "3":
                    Console.WriteLine("Enter the number of the task you want to remove :");

                    LoopOverListOfTasks();
                    
                    int taskNumberToRemove = UserChoice(Console.ReadLine());
                    if (taskNumberToRemove != -1)
                    {
                        Tasks.RemoveAt(taskNumberToRemove);
                    } 
                    else
                    {
                        Console.WriteLine("Please choose a number in the list");
                    }

                    break; 
                case "4":
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
                        Console.WriteLine(item);
                    }

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

    private static int UserChoice(string? userChoice)
    {
        if(userChoice != null && Convert.ToInt32(userChoice) < Tasks.Count)
        {
            return Convert.ToInt32(userChoice);
        } 
        else
        {
            return -1;
        }
    }

    private static void LoopOverListOfTasks()
    {
        for (int i = 0; i < Tasks.Count; i++)
        {
            Console.WriteLine($"{i} : {Tasks[i]}");
        }
    }
}