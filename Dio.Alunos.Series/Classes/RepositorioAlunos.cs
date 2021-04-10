using System;
using System.Collections.Generic;
using Dio.Alunos.Series;

namespace Dio.Alunos.Series
{
    public class RepositorioAlunos : IRepositorioAluno<Alunos>
    {
        private List<Alunos> listaAluno = new List<Alunos>();

        public void Atualiza(int id, Alunos entidade)
        {
            listaAluno[id] = entidade;
        }

        public void Exclui(int id)
        {
            listaAluno.RemoveAt(id);
        }

        public void Insere(Alunos entidade)
        {
            listaAluno.Add(entidade);
        }

        public List<Alunos> Lista()
        {
            return listaAluno;
        }

        public int ProximoId()
        {
            return listaAluno.Count;
        }

        public Alunos RetornaPorId(int id)
        {
            return listaAluno[id];
        }
    }
}