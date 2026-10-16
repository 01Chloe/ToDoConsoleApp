using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoConsoleApp
{
    internal class Task(string title, bool state)
    {
        public string Title { get; set; } = title;
        public bool State { get; set; } = state;
    }
}
