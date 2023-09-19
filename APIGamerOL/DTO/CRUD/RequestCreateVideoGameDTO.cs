namespace APIGamerOL.DTO.CRUD
{
    public class RequestCreateVideoGameDTO
    {
        /// <summary>
        /// Nombre del video juego
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Compañia del video juego
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// Año de lanzamineto
        /// </summary>
        public int YearOfLaunch { get; set; }
        /// <summary>
        /// Precio del video juego
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Puntaje de valoracion
        /// </summary>
        public decimal Score { get; set; }
        /// <summary>
        /// Usuario de la creacion del registro 
        /// </summary>
        public string User { get; set; }
    }
}
