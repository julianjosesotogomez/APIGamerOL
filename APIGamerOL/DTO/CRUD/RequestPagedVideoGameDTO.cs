namespace APIGamerOL.DTO.CRUD
{
    public class RequestPagedVideoGameDTO
    {
        /// <summary>
        /// Nombre del video Juego
        /// </summary>
        public string? NameVideoGame {  get; set; }
        /// <summary>
        /// Nombre de la compañia
        /// </summary>
        public string? Company { get; set;}
        /// <summary>
        /// Año de lanzamineto
        /// </summary>
        public int?  YearOfLaunch{ get; set; }

    }
}
