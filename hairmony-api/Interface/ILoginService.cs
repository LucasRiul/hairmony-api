using hairmony_api.Model;

namespace hairmony_api.Interface
{
    public interface ILoginService
    {
        public salao? ValidarUsuario(string username, string senha);
    }
}
