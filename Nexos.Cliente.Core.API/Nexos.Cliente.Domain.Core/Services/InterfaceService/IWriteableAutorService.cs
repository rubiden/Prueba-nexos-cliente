using Nexos.Cliente.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nexos.Cliente.Domain.Core.Services.InterfaceService
{
    public interface IWriteableAutorService
    {
        Task<int> PostAutor(Autor autor);
        Task<int> PutAutor(Autor autor);
    }
}
