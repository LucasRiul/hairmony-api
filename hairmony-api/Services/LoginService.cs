using hairmony_api.Data;
using hairmony_api.Interface;
using hairmony_api.Model;

namespace hairmony_api.Services
{
    public class LoginService : ILoginService
    {
        private readonly hairmonyContext _context;
        public LoginService(hairmonyContext context)
        {
            _context = context;
        }
        public salao? ValidarUsuario(string username, string senha)
        {
            var usuario = _context.salao.FirstOrDefault(x => x.nome.ToLower() == username.ToLower());

            if (usuario == null)
            {
                return null;
            }
            bool senhaValida = BCrypt.Net.BCrypt.Verify(senha, usuario.senha);
            if (senhaValida) 
            {
                return usuario;
            } 
            else
            {
                return null;
            }
        }
    }
}
