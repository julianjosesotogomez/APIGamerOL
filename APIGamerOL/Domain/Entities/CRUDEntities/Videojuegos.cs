using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APIGamerOL.Domain.Entities.CRUDEntities
{
    public partial class Videojuegos
    {
        public Videojuegos()
        {
            Calificaciones = new HashSet<Calificaciones>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Compañia { get; set; }
        public int? AñoLanzamiento { get; set; }
        public decimal? Precio { get; set; }
        public decimal? Puntaje { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string? Usuario { get; set; }

        [JsonIgnore]
        public virtual ICollection<Calificaciones> Calificaciones { get; set; }
    }
}
