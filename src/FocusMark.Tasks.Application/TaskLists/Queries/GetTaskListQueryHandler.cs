using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace FocusMark.Tasks.Application.TaskLists.Queries
{
    public class TaskListDto
    {

    }

    public class TaskListViewModel
    {
        public IList<TaskListDto> TaskLists { get; set; }
    }

    public class GetTaskListQuery : IRequest<TaskListDto>
    {

    }

    class GetTaskListQueryHandler
    {
    }
}
