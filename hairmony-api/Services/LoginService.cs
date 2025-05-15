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
            var usuario = _context.salao.FirstOrDefault(x => x.nome.ToLower() == username.ToLower() && x.senha == senha);
            if (usuario != null)
            {
                return usuario;
            }
            return null;
        }
    }
}
