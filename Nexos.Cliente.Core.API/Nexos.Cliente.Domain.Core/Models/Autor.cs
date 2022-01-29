using System;

namespace Nexos.Cliente.Domain.Core.Models
{
    public partial class Autor
    {
        public int Id { get; set; }
        public string NombreCompleto { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CiudadNacimiento { get; set; }
        public string Email { get; set; }
    }
}
