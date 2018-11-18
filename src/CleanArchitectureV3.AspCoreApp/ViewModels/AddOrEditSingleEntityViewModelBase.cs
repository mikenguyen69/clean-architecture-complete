using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchitectureV3.AspCoreApp.ViewModels
{
    public abstract class AddOrEditSingleEntityViewModelBase : SingleEntityViewModelBase
    {
        public bool IsAdding => Id == 0;
    }
}
