using MediatR;

namespace CleanArchitectureV3.AspCoreApp.Commands.Tasks
{
    public class TaskAddOrEditCommand : AddOrEditSingleEntityCommandBase, IRequest<CommandResult<int>>
    {
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
