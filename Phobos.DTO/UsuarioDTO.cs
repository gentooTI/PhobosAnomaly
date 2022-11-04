using System;

namespace Phobos.DTO
{
    public class UsuarioDTO
    {
        public int idUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string EmailUsuario { get; set; }
        public string SenhaUsuario { get; set; }
        public DateTime DataNascUsuario { get; set; }
        public int UsuarioTp { get; set; }
    }
}
