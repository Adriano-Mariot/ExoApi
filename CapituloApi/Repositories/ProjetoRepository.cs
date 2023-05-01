using CapituloApi.Contexts;
using CapituloApi.Interfaces;
using CapituloApi.Models;

namespace CapituloApi.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        private readonly CapituloContext _capituloContext;
        public ProjetoRepository(CapituloContext context) 
        {
            _capituloContext= context;
        }

        public List<Projeto> ler()
        {
            return _capituloContext.Prj.ToList();
        }

        public Projeto BuscarPorId(int Id)
        {
            return _capituloContext.Prj.Find(Id);
        }

        public void Cadastrar(Projeto projeto)
        {
            _capituloContext.Prj.Add(projeto);
            _capituloContext.SaveChanges();
        }

        public void Atualizar(int Id, Projeto projeto)
        {
            Projeto projetobuscado = _capituloContext.Prj.Find(Id);
            if (projetobuscado != null)
            {
                projetobuscado.NomeProjeto=projeto.NomeProjeto;
                projetobuscado.Autor = projeto.Autor;
                projetobuscado.Gerente = projeto.Gerente;
                projeto.Disponivel=projeto.Disponivel;
            }

            _capituloContext.Prj.Update(projetobuscado);
            _capituloContext.SaveChanges();
        }

        public void Deletar(int Id)
        {
            Projeto projeto = _capituloContext.Prj.Find(Id);
            _capituloContext.Remove(projeto);
            _capituloContext.SaveChanges();
        }
    }
}
