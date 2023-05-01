using CapituloApi.Contexts;
using CapituloApi.Interfaces;
using CapituloApi.Models;

namespace CapituloApi.Repositories
{
    public class UsuarioRepository : IUsuariRepository
    {
        private readonly CapituloContext _capituloContext;

        public UsuarioRepository (CapituloContext capituloContext)
        {
            _capituloContext= capituloContext;
        }

        public List<Usuario> ListarUsuario()
        {
            return _capituloContext.Usuarios.ToList();
        }

        public Usuario BuscarPorIdUsuario(int Id)
        {
            return _capituloContext.Usuarios.Find(Id);
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            _capituloContext.Usuarios.Add(usuario);
            _capituloContext.SaveChanges();
        }

        public void DeletarUsuario(int Id)
        {
            Usuario usuarioBuscado = _capituloContext.Usuarios.Find(Id);
            _capituloContext.Usuarios.Remove(usuarioBuscado);
            _capituloContext.SaveChanges();
        }

        public void AtualizarUsuario(int Id, Usuario usuario)
        {
            Usuario usuarioBuscado = _capituloContext.Usuarios.Find(Id);

            if(usuarioBuscado != null)
            {
                usuarioBuscado.Email= usuario.Email;
                usuarioBuscado.Senha= usuario.Senha;
                usuarioBuscado.Tipo= usuario.Tipo;
            }

            _capituloContext.Usuarios.Update(usuarioBuscado);
            _capituloContext.SaveChanges();
        }
        
        public Usuario Login(string email, string senha)
        {
            return _capituloContext.Usuarios.FirstOrDefault(u => u.Email==email && u.Senha ==senha);
        }
    }
}
