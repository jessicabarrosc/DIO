using System;

namespace Dio.Alunos.Series
{
    class Program
    {
        static RepositorioAlunos repositorio = new RepositorioAlunos();
        static void Main(string[] args)
        {
            string opcao = ObterOpcao();

			while (opcao.ToUpper() != "X")
			{
				switch (opcao)
				{
					case "1":
						ListarAluno();
						break;
					case "2":
						InserirAluno();
						break;
					case "3":
						AtualizarAluno();
						break;
					case "4":
						ExcluirAluno();
						break;
					case "5":
						VisualizarAluno();
						break;
					case "C":
						Console.Clear();
						break;

					default:
						throw new ArgumentOutOfRangeException();
				}

				opcao = ObterOpcao();
			}

			Console.WriteLine("Obrigado por utilizar nossos serviços.");
			Console.ReadLine();
        }

        private static void ExcluirAluno()
		{
			Console.Write("Digite o id do aluno: ");
			int idAluno = int.Parse(Console.ReadLine());

			repositorio.Exclui(idAluno);
		}

        private static void VisualizarAluno()
		{
			Console.Write("Digite o id do aluno: ");
			int idAluno = int.Parse(Console.ReadLine());

			var aluno = repositorio.RetornaPorId(idAluno);

			Console.WriteLine(aluno);
		}

        private static void AtualizarAluno()
		{
			Console.Write("Digite o id do Aluno: ");
			int idAluno = int.Parse(Console.ReadLine());

			foreach (int i in Enum.GetValues(typeof(Materia)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Materia), i));
			}
            Console.Write("Digite a materia: ");
			int opcaoMateria = int.Parse(Console.ReadLine());
            
			Console.Write("Nome do Aluno: ");
			string nomeAluno = Console.ReadLine();

			Console.Write("Digite a Nota 1: ");
			float nota1aluno = float.Parse(Console.ReadLine());

            Console.Write("Digite a Nota 2: ");
			float nota2aluno = float.Parse(Console.ReadLine());

            Console.Write("Digite a Nota 3: ");
			float nota3aluno = float.Parse(Console.ReadLine());

            Console.Write("Digite a Nota 4: ");
			float nota4aluno = float.Parse(Console.ReadLine());

			Alunos atualizaAluno = new Alunos(id: idAluno,
										materia: (Materia)opcaoMateria,
										nome: nomeAluno,
										nota1: nota1aluno,
                                        nota2: nota2aluno,
                                        nota3: nota3aluno,
                                        nota4: nota4aluno);

			repositorio.Atualiza(idAluno, atualizaAluno);
		}
        private static void ListarAluno()
		{
			Console.WriteLine("Listar Alunos");

			var lista = repositorio.Lista();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum aluno registrado");
				return;
			}
            foreach (var alunos in lista)
			{
                
				Console.WriteLine("#ID {0}: - {1} {2}", alunos.retornaId(), alunos.retornaNome());
			}
		}

        private static void InserirAluno()
		{
			Console.WriteLine("Inserir novo Aluno");

            Console.Write("Digite o nome do aluno: ");
			string nomeAluno = Console.ReadLine();

			Console.Write("Digite o número da materia entre as opções: ");
			

			foreach (int i in Enum.GetValues(typeof(Materia)))
			{
				Console.WriteLine("{0}-{1}", i, Enum.GetName(typeof(Materia), i));
			}
            int opcaoMateria = int.Parse(Console.ReadLine());

			Console.Write("Digite a Nota 1: ");
			float nota1aluno = float.Parse(Console.ReadLine());

            Console.Write("Digite a Nota 2: ");
			float nota2aluno = float.Parse(Console.ReadLine());

            Console.Write("Digite a Nota 3: ");
			float nota3aluno = float.Parse(Console.ReadLine());

            Console.Write("Digite a Nota 4: ");
			float nota4aluno = float.Parse(Console.ReadLine());

			Alunos novoAluno = new Alunos(id: repositorio.ProximoId(),
										materia: (Materia)opcaoMateria,
										nome: nomeAluno,
										nota1: nota1aluno,
                                        nota2: nota2aluno,
                                        nota3: nota3aluno,
                                        nota4: nota4aluno);

			repositorio.Insere(novoAluno);
		}

        private static string ObterOpcao()
		{
			Console.WriteLine();
			Console.WriteLine("***Registro de professores DIO***");
            Console.WriteLine("Por gentileza, digite a opção desejada");
			Console.WriteLine("1- Listar Alunos");
			Console.WriteLine("2- Inserir novo Aluno");
			Console.WriteLine("3- Atualizar Aluno");
			Console.WriteLine("4- Excluir Aluno");
			Console.WriteLine("5- Visualizar Aluno");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
    }
}
}
