using AutoMapper;
using CleanArchitectureV3.AspCoreApp.Commands.Tasks;
using CleanArchitectureV3.AspCoreApp.Models;
using CleanArchitectureV3.AspCoreApp.ViewModels.Tasks;

namespace CleanArchitectureV3.AspCoreApp.Infrastructure.Mapping
{
    public class TasksProfile : Profile
    {
        public TasksProfile()
        {
            CreateMap<Task, TasksIndexViewModel.TaskListEntry>();
            CreateMap<Task, TasksEditViewModel>();
            //CreateMap<Task, TasksDeleteViewModel>();

            CreateMap<TasksEditViewModel, TaskAddOrEditCommand>();
            //CreateMap<TasksEditViewModel, TaskDeleteCommand>();
        }
    }
}
