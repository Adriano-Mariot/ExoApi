using CapituloApi.Models;

namespace CapituloApi.Interfaces
{
    public interface IUsuariRepository
    {
        List<Usuario> ListarUsuario();

        Usuario BuscarPorIdUsuario(int Id);

        void CadastrarUsuario(Usuario usuario);

        void AtualizarUsuario(int Id, Usuario usuario);

        void DeletarUsuario(int Id);

        Usuario Login(string email, string senha);

    }
}
