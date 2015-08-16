using Definition.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Definition.Interfaces
{
    public interface IAppLoader
    {

        Task LoadStack(StackEnum stack);

    }
}
