namespace APIGamerOL.DTO.Register
{
    public class RegisterRequestDTO
    {
        /// <summary>
        /// Nombre del usuario
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Correo Electrónico 
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Contraseña 
        /// </summary>
        public string Password { get; set; }
    }
}
