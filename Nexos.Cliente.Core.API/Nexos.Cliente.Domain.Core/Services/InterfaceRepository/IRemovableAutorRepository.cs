using Nexos.Cliente.Domain.Core.Models;
using System.Threading.Tasks;

namespace Nexos.Cliente.Domain.Core.Services.InterfaceRepository
{
    public interface IRemovableAutorRepository
    {
        Task<int> DeleteAutor(Autor autor);
    }
}
