using System;
using System.ComponentModel.DataAnnotations;

namespace Nexos.Cliente.Core.API.BindingModel
{
    /// <summary>
    /// Calase para el manejo de autores
    /// </summary>
    public class AutorDTO
    {
        /// <summary>
        /// Id del autor
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nombre completo del autor
        /// </summary>
        [Required(ErrorMessage = "El nombre completo del autor es requerido")]
        public string NombreCompleto { get; set; }
        /// <summary>
        /// Fecha de nacimiento
        /// </summary>
        [Required(ErrorMessage = "La fecha de nacimiento es requerida")]
        public DateTime FechaNacimiento { get; set; }
        /// <summary>
        /// Ciudad de nacimiento
        /// </summary>
        [Required(ErrorMessage = "La ciudad de nacimiento es requerida")]
        public string CiudadNacimiento { get; set; }
        /// <summary>
        /// Correo electronico
        /// </summary>
        [Required(ErrorMessage = "El email es requerido")]
        public string Email { get; set; }
    }
}
