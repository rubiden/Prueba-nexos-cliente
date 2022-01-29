using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Cliente.Domain.Core.Services.InterfaceService
{
    public interface IRemovableAutorService
    {
        Task<int> DeleteAutor(int id);
    }
}
