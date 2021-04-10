using System;
namespace Dio.Alunos.Series
{
    public class Alunos : EntidadeBase
    {
        private Materia Materia { get; set; }
        private string Nome { get; set; }
        private float Nota1 { get; set; }
        private float Nota2 { get; set; }
        private float Nota3 { get; set; }
        private float Nota4 { get; set; }
        private float Media { get; set; }

         public Alunos(Materia materia, string nome, float nota1, float nota2, float nota3, float nota4, int id)
        {
            this.Materia = materia;
            this.Nome = nome;
            this.Nota1 = nota1;
            this.Nota2 = nota2;
            this.Nota3 = nota3;
            this.Nota4 = nota4;
            this.Id = id;
            this.Media = (nota1+nota2+nota3+nota4)/4;

        }

         public override string ToString()
        {
            string retorno = "";
            retorno += "Materia: " + this.Materia + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Nota1: " + this.Nota1 + Environment.NewLine;
            retorno += "Nota2: " + this.Nota2 + Environment.NewLine;
            retorno += "Nota3: " + this.Nota3 + Environment.NewLine;
            retorno += "Nota4: " + this.Nota4 + Environment.NewLine;
            retorno += "Média: " + this.Media;
            return retorno;
        }

        public string retornaNome(){
            return this.Nome;
        }
        public int retornaId(){
            return this.Id;
        }
    }
}