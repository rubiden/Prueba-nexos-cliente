using Nexos.Cliente.Domain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nexos.Cliente.Domain.Core.Services.InterfaceRepository
{
    public interface IReadableAutorRepository
    {
        Task<IEnumerable<Autor>> GetAutores();
        Task<Autor> GetAutorById(int id);
    }
}
