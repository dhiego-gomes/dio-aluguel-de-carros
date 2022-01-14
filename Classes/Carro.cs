using DIO.AluguelDeCarros;

namespace DIO.AluguelDeCarros
{
    public class Carro : EntidadeBase
    {
        // ATRIBUTOS
        private Tipo Tipo { get; set; }
        private string Modelo { get; set; }
        private string Cor { get; set; }
        private string Ano { get; set; }
        private int KM { get; set; }
        private bool Excluido { get; set; }
        private bool Alugado { get; set; }

        // MÉTODOS
        public Carro(int id, Tipo tipo, string modelo, string cor, string ano, int km)
        {
            this.Id = id;
            this.Tipo = tipo;
            this.Modelo = modelo;
            this.Cor = cor;
            this.Ano = ano;
            this.KM = km;
            this.Excluido = false;
            this.Alugado = false;
        }

        // SOBESCREVENDO MÉTODO ToString
        public override string ToString()
        {
            string retorno = "";
            retorno += "Tipo: " + this.Tipo + Environment.NewLine;
            retorno += "Modelo: " + this.Modelo + Environment.NewLine;
            retorno += "Cor: " + this.Cor + Environment.NewLine;
            retorno += "Ano: " + this.Ano + Environment.NewLine;
            retorno += "KM: " + this.KM + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido + Environment.NewLine;
            retorno += "Alugado: " + this.Alugado + Environment.NewLine;
            return retorno;
        }

        public string RetornaModelo()
        {
            return this.Modelo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public bool RetornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public bool RetornaAlugado()
        {
            return this.Alugado;
        }

        public void Alugar()
        {
            this.Alugado = true;
        }

        public void Devolver()
        {
            this.Alugado = false;
        }
    }

}