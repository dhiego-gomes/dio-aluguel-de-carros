using System;
using System.Collections.Generic;
using DIO.AluguelDeCarros.Interfaces;

namespace DIO.AluguelDeCarros
{
    public class CarroRepositorio : IRepositorio<Carro>
    {
        private List<Carro> listaCarro = new List<Carro>();
        public List<Carro> Lista()
        {
            return listaCarro;
        }

        public Carro RetornaPorId(int id)
        {
            return listaCarro[id];
        }

        public void Insere(Carro objeto)
        {
            listaCarro.Add(objeto);
        }

        public void Exclui(int id)
        {
            listaCarro[id].Excluir();
        }

        public void Atualiza(int id, Carro objeto)
        {
            listaCarro[id] = objeto;
        }

        public int ProximoId()
        {
            return listaCarro.Count;
        }

        public void Aluga(int id)
        {
            listaCarro[id].Alugar();
        }

        public void Devolve(int id)
        {
            listaCarro[id].Devolver();
        }
    }
}