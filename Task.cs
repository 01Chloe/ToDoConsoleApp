using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoConsoleApp
{
    internal class Task(string title, bool state)
    {
        public string Title { get; set; } = title;
        public bool State { get; set; } = state;

        public static void AddTask(List<Task> Tasks)
        {
            Console.WriteLine("Enter your new task : ");

            string? userTask = Console.ReadLine();
            if (!String.IsNullOrWhiteSpace(userTask))
            {
                Task task = new(userTask, false);
                Tasks.Add(task);
            }
        }

        public static void DisplayTasks(List<Task> Tasks)
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
                if (!item.State)
                {
                    Console.WriteLine($"[ ] {item.Title}");
                }
                else
                {
                    Console.WriteLine($"[X] {item.Title}");
                }
            }
        }

        public static void CompletTask(List<Task> Tasks)
        {
            Console.WriteLine("Enter the number of the task you want to complete :");

            LoopOverListOfTasks(Tasks);

            int taskNumber = UserChoice(Console.ReadLine(), Tasks);
            if (taskNumber != -1)
            {
                Tasks[taskNumber].State = true;
            }
            else
            {
                Console.WriteLine("Please choose a number in the list");
            }
        }

        public static void RemoveTask(List<Task> Tasks)
        {
            Console.WriteLine("Enter the number of the task you want to remove :");

            LoopOverListOfTasks(Tasks);

            int taskNumberToRemove = UserChoice(Console.ReadLine(), Tasks);
            if (taskNumberToRemove != -1)
            {
                Tasks.RemoveAt(taskNumberToRemove);
            }
            else
            {
                Console.WriteLine("Please choose a number in the list");
            }
        }

        private static int UserChoice(string? userChoice, List<Task> Tasks)
        {
            bool successfullyParsed = int.TryParse(userChoice, out _);
            if (userChoice != null && successfullyParsed)
            {
                if (Convert.ToInt32(userChoice) < Tasks.Count)
                {
                    return Convert.ToInt32(userChoice);
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        private static void LoopOverListOfTasks(List<Task> Tasks)
        {
            for (int i = 0; i < Tasks.Count; i++)
            {
                Console.WriteLine($"{i} : {Tasks[i].Title}");
            }
        }
    }
}
