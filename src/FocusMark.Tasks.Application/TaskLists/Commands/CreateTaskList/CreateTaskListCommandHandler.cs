using FocusMark.Tasks.Application.Services;
using FocusMark.Tasks.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace FocusMark.Tasks.Application.TasksLists.Commands
{
    public class CreateTaskListCommandHandler : IRequestHandler<CreateTaskListCommand, Guid>
    {
        public CreateTaskListCommandHandler(ICurrentUserService currentUserService, ITaskListService taskListService)
        {
            CurrentUserService = currentUserService ?? throw new ArgumentNullException(nameof(currentUserService));
            TaskListService = taskListService ?? throw new ArgumentNullException(nameof(taskListService));
        }

        public ICurrentUserService CurrentUserService { get; }
        public ITaskListService TaskListService { get; }

        public async Task<Guid> Handle(CreateTaskListCommand request, CancellationToken cancellationToken)
        {
            //var list = new TaskList(Guid.NewGuid(), this.CurrentUserService.UserId);

            //list.RenameTaskList(request.Title);
            //list.MoveTaskList(request.Path);

            //if (request.StartDate.HasValue)
            //{
            //    list.StartTaskList(request.StartDate.Value);
            //}
            //else
            //{
            //    list.StartPlanning();
            //}

            //this.dbContext.TaskLists.Add(list);

            //await this.dbContext.SaveChangesAsync(cancellationToken);

            var taskListId = Guid.NewGuid();
            await this.TaskListService.CreateTaskList(
                taskListId,
                request.Title,
                request.Color,
                request.Path,
                this.GetTaskListMethodology(request.Kind),
                request.StartDate,
                request.TargetDate);

            return taskListId;
        }

        private Methodology GetTaskListMethodology(string methodology)
        {
            if (!Enum.TryParse(methodology, out Methodology listType))
            {
                //list.ConvertToKanbanTaskList();
                return Methodology.Kanban;
            }

            switch (listType)
            {
                case Methodology.Kanban:
                    //list.ConvertToKanbanTaskList();
                    return Methodology.Kanban;
                default:
                    //list.ConvertToKanbanTaskList();
                    return Methodology.Kanban;
            }
        }
    }
}
