namespace CapituloApi.Models
{
    public class Projeto
    {
        //prop do Projeto

        public int Id { get; set; }
        public string? NomeProjeto { get; set; }
        public string? Autor { get; set; }
        public string? Gerente{ get; set; }
        //public int QuantidadePaginas { get; set; }
        public bool Disponivel { get; set; }

    }
}
