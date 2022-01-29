using Microsoft.EntityFrameworkCore;
using Nexos.Cliente.Domain.Core.Models;
using Nexos.Cliente.Domain.Core.Services.InterfaceRepository;
using Nexos.Cliente.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Nexos.Cliente.Infrastructure.Repository
{
    public class AutorRepository : IWriteableAutorRepository, IReadableAutorRepository, IRemovableAutorRepository
    {
        public readonly NexosClienteDBContext _context;

        public AutorRepository(NexosClienteDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Autor>> GetAutores()
        {
            IEnumerable<Autor> result;

            using (_context)
            {
                result = await _context.Autores.ToListAsync();
            }

            return result;
        }

        public async Task<int> PostAutor(Autor autor)
        {
            using (_context)
            {
                _context.Autores.Add(autor);
                await _context.SaveChangesAsync();
            }

            return autor.Id;
        }

        public async Task<Autor> GetAutorById(int id)
        {
            return await _context.Autores.FindAsync(id);
        }

        public async Task<int> PutAutor(Autor autor)
        {
            using (_context)
            {
                _context.Entry(autor).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return autor.Id;
        }

        public async Task<int> DeleteAutor(Autor autor)
        {
            int result;

            using (_context)
            {
                _context.Autores.Remove(autor);
                result = await _context.SaveChangesAsync();
            }

            return result;
        }
    }
}
