using Nexos.Cliente.Domain.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nexos.Cliente.Domain.Core.Services.InterfaceRepository
{
    public interface IWriteableAutorRepository
    {      
        Task<int> PostAutor(Autor autor);       
        Task<int> PutAutor(Autor autor);
    }
}
