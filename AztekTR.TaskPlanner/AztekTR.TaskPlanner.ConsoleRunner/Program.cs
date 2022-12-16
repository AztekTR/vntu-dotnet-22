using AztekTR.TaskPlanner.Domain.Logic;
using AztekTR.TaskPlanner.Domain.Models;
using AztekTR.TaskPlanner.Domain.Models.Enums;
using System;
using System.Collections.Generic;

namespace AztekTR.TaskPlanner.ConsoleRunner
{

    internal static class Program
    {
        public static void Main(string[] args)
        {
            var items = ReadWorkItems();

            var planner = new SimpleTaskPlanner();

            var orderedItems = planner.CreatePlan(items);

            PrintWorkPlan(orderedItems);
        }

        private static WorkItem[] ReadWorkItems()
        {
            var items = new List<WorkItem>();

            bool promptToEnterWorkItem = true;

            while (promptToEnterWorkItem)
            {
                var workItem = ReadWorkItem();

                items.Add(workItem);

                promptToEnterWorkItem = PromptForInputMoreItems();
            }

            return items.ToArray();
        }

        private static bool PromptForInputMoreItems()
        {
            Console.WriteLine("Do you want to enter another work item? Y/[N]");
            var response = Console.ReadLine();

            response = response?.ToUpper();

            return response == "Y";
        }

        private static WorkItem ReadWorkItem()
        {
            Console.WriteLine("Input item title:");
            string title = Console.ReadLine();

            Console.WriteLine("Input item priority:");
            string priorityInput = Console.ReadLine();
            Priority priority = Enum.Parse<Priority>(priorityInput, ignoreCase: true);

            Console.WriteLine("Input item complexity:");
            string complexityInput = Console.ReadLine();
            Complexity complexity = Enum.Parse<Complexity>(complexityInput, ignoreCase: true);

            Console.WriteLine("Input item description:");
            string description = Console.ReadLine();

            Console.WriteLine("Input item due date(dd.MM.yyyy):");
            string dueDateInput = Console.ReadLine();
            DateTime dueDate = DateTime.Parse(dueDateInput);

            return new WorkItem
            {
                Title = title,
                Complexity = complexity,
                Priority = priority,
                Description = description,
                DueDate = dueDate,
                CreationDate = DateTime.Now,
                IsCompleted = false,
            };
        }

        private static void PrintWorkPlan(WorkItem[] items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}