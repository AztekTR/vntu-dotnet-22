using AztekTR.TaskPlanner.Domain.Models.Enums;

namespace AztekTR.TaskPlanner.Domain.Models
{

    public class WorkItem
    {
        public System.DateTime CreationDate { get; set; }

        public System.DateTime DueDate { get; set; }

        public string Title { get; set; }

        public Priority Priority { get; set; }

        public Complexity Complexity { get; set; }

        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public override string ToString()
        {
            var adjustedPriority = Priority.ToString().ToLower();

            return $"{Title}: due {DueDate:dd.MM.yyyy}, {adjustedPriority} priority";
        }
    }

}