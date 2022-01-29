using Nexos.Cliente.Domain.Core.Models;
using Nexos.Cliente.Domain.Core.Services.InterfaceRepository;
using Nexos.Cliente.Domain.Core.Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nexos.Cliente.Domain.Core.Services
{
    public class AutorService : IReadableAutorService, IWriteableAutorService, IRemovableAutorService
    {
        private readonly IWriteableAutorRepository _writeableAutorRepository;
        private readonly IReadableAutorRepository _readableAutorRepository;
        private readonly IRemovableAutorRepository _removableAutorRepository;

        public AutorService(IWriteableAutorRepository writeableAutorRepository, 
            IReadableAutorRepository readableAutorRepository, 
            IRemovableAutorRepository removableAutorRepository)
        {
            _writeableAutorRepository = writeableAutorRepository ?? throw new ArgumentNullException(nameof(writeableAutorRepository));
            _readableAutorRepository = readableAutorRepository ?? throw new ArgumentNullException(nameof(readableAutorRepository));
            _removableAutorRepository = removableAutorRepository ?? throw new ArgumentNullException(nameof(removableAutorRepository));
        }

        public async Task<int> PostAutor(Autor autor)
        {
            return await _writeableAutorRepository.PostAutor(autor);
        }

        public async Task<int> PutAutor(Autor autor)
        {
            return await _writeableAutorRepository.PutAutor(autor);
        }


        public async Task<Autor> GetAutorById(int id)
        {
            return await _readableAutorRepository.GetAutorById(id);
        }

        public async Task<IEnumerable<Autor>> GetAutores()
        {
            return await _readableAutorRepository.GetAutores();
        }

        
        public async Task<int> DeleteAutor(int id)
        {
            Autor autor = await _readableAutorRepository.GetAutorById(id);
            if (autor == null)
                return 0;

            return await _removableAutorRepository.DeleteAutor(autor);
        }
    }
}
