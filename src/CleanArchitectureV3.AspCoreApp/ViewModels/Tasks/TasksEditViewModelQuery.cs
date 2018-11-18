using MediatR;

namespace CleanArchitectureV3.AspCoreApp.ViewModels.Tasks
{
    public class TasksEditViewModelQuery : IRequest<TasksEditViewModel>
    {
        public int Id { get; set; }
    }
}
