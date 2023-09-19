using System;
using System.Collections.Generic;

namespace APIGamerOL.Domain.Entities.CRUDEntities
{
    public partial class Calificaciones
    {
        public Guid Id { get; set; }
        public string? Nickname { get; set; }
        public int? VideojuegoId { get; set; }
        public decimal? Puntuacion { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string? Usuario { get; set; }

        public virtual Videojuegos? Videojuego { get; set; }
    }
}
