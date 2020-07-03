using System;
using System.Text.RegularExpressions;

namespace FocusMark.Tasks.Domain
{
    public class TaskList : AuditableEntity
    {
        public const byte MaximumPercentCompleteAllowed = 100;
        public const byte MinimumPercentCompleteAllowed = 1;
        public const string HexColorRegEx = "^#+([a-fA-F0-9]{6}|[a-fA-F0-9]{3})$";

        public TaskList(Guid id, string userId)
        {
            if (id == default)
            {
                throw new InvalidListIdException(id);
            }

            this.TaskListId = id;

            if (string.IsNullOrEmpty(userId))
            {
                throw new UserIdMissingException(id);
            }

            this.UserId = userId;
        }

        // EF Core default constructor
        public TaskList() { }

        public Guid TaskListId { get; private set; }

        public string Title { get; private set; }

        public string Color { get; private set; }

        public string Path { get; private set; }

        public Methodology Kind { get; private set; }

        public Status Status { get; private set; }

        public byte PercentComplete { get; private set; }

        public bool IsArchived { get; private set; }

        public DateTime? StartDate { get; private set; }

        public DateTime? TargetDate { get; private set; }

        public DateTime? CompletionDate { get; private set; }

        //public IList<TodoItem> Items { get; set; } = new List<TodoItem>();

        public void SetColor(string color)
        {
            if(!Regex.IsMatch(color, HexColorRegEx))
            {
                throw new InvalidTaskListColor(this.TaskListId, color, HexColorRegEx);
            }

            this.Color = color;
        }

        public void ProgressTaskList(byte percentageAmount)
        {
            if (percentageAmount < MinimumPercentCompleteAllowed)
            {
                throw new ListProgressMinimumNotMetException(percentageAmount);
            }

            if (this.PercentComplete + percentageAmount > MaximumPercentCompleteAllowed)
            {
                this.PercentComplete = MaximumPercentCompleteAllowed;
            }
            else
            {
                this.PercentComplete += percentageAmount;
            }
        }

        public void RegressTaskList(byte percentageAmount)
        {
            if (percentageAmount < MinimumPercentCompleteAllowed)
            {
                throw new ListProgressMinimumNotMetException(percentageAmount);
            }

            if (this.PercentComplete - percentageAmount < MinimumPercentCompleteAllowed)
            {
                throw new ListProgressMinimumNotMetException(percentageAmount);
            }

            this.PercentComplete -= percentageAmount;
        }

        public void ArchiveTaskList()
        {
            this.IsArchived = true;
        }

        public void RebaselineTaskList(DateTime newStartDate)
        {
            this.StartDate = newStartDate;
        }

        public void RescheduleTaskList(DateTime newTargetDate)
        {
            this.TargetDate = newTargetDate;
        }

        public void ReviseCompletionDate(DateTime newCompletionDate)
        {
            this.CompletionDate = newCompletionDate;
        }

        public void RenameTaskList(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
            {
                throw new ListNameMissingException(this.TaskListId);
            }

            this.Title = newName;
        }

        public void MoveTaskList(string newPath)
        {
            if (string.IsNullOrWhiteSpace(newPath))
            {
                throw new ListPathEmptyException(this.TaskListId);
            }

            this.Path = newPath;
        }

        public void ConvertToKanbanTaskList()
        {
            this.Kind = Methodology.Kanban;
        }

        public void StartPlanning()
        {
            this.Status = Status.Planning;
        }

        public void StartTaskList(DateTime startDate)
        {
            this.Status = Status.Active;
            if (!this.StartDate.HasValue)
            {
                this.StartDate = startDate;
            }
            else
            {
                throw new TaskListAlreadyStartedException(this.TaskListId);
            }
        }

        public void PauseTaskList()
        {
            this.Status = Status.Paused;
        }

        public void CompleteTaskList(DateTime? dateCompleted)
        {
            this.Status = Status.Completed;
            if (dateCompleted.HasValue)
            {
                this.CompletionDate = dateCompleted;
            }
            else
            {
                this.CompletionDate = DateTime.UtcNow;
            }
        }
    }
}
