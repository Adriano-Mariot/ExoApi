using CapituloApi.Models;

namespace CapituloApi.Interfaces
{
    public interface IProjetoRepository
    {
        List<Projeto> ler();
        Projeto BuscarPorId(int Id);

        void Cadastrar(Projeto projeto);

        void Atualizar(int Id, Projeto projeto);

        void Deletar(int Id);

    }
}
