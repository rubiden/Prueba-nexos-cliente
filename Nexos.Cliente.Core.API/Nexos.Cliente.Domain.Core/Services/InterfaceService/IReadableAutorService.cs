using Nexos.Cliente.Domain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nexos.Cliente.Domain.Core.Services.InterfaceService
{
    public interface IReadableAutorService
    {
        Task<IEnumerable<Autor>> GetAutores();      
        Task<Autor> GetAutorById(int id);
    }
}
