using System.Collections.Generic;

namespace Dio.Alunos.Series

{
    public interface IRepositorioAluno<A>
    {
        List<A> Lista();
        A RetornaPorId(int id);
        void Insere(A entidade);
        void Exclui(int id);
        void Atualiza(int id, A entidade);
        int ProximoId();
    }
}