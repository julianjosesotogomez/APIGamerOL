using System;
using System.Collections.Generic;

namespace APIGamerOL.Domain.Entities.SecureEntities
{
    public partial class Usuario
    {
        public Guid Id { get; set; }
        public string? NombreUsuario { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Contrasena { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}
