namespace ToDoConsoleApp;

class ToDoConsoleApp
{
    public static List<Task> Tasks { get; set; } = [];

    static void Main (string[] args)
    {
        Console.WriteLine("Welcome into your todo!");
        Console.WriteLine("Choose an action, then press enter :");

        string? option = "";
        while (option != "e" && option != "E")
        {
            Console.WriteLine();
            Console.WriteLine("- 1 : Add a task.");
            Console.WriteLine("- 2 : Complete a task.");
            Console.WriteLine("- 3 : Remove a task.");
            Console.WriteLine("- 4 : View all tasks.");
            Console.WriteLine("- e or E : Exit the program.");

            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    Task.AddTask(Tasks);

                    break;
                case "2":
                    Task.CompletTask(Tasks);

                    break; 
                case "3":
                    Task.RemoveTask(Tasks);

                    break; 
                case "4":
                    Task.DisplayTasks(Tasks);

                    break; 
                case "e":
                    Console.WriteLine("Exit program.");
                    break;
                case "E":
                    Console.WriteLine("Exit program.");
                    break;
                default:
                    Console.WriteLine("Please choose a valid option.");
                    break;
            }
        }
    }    
}