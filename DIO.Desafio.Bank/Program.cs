using System;
using System.Collections.Generic;

namespace DIO.Desafio.Bank
{
   
    class Program
    {
        private const string V = "6";
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "6":
                        Extrair();
                    break;
                    case "7":
                        CancelarConta();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigada por utilizar nossos serviços.");
            Console.ReadLine();
        }

        private static void Extrair()
        {
                Console.Write("Digite o número da conta que deseja extrair:");
                int indice = int.Parse(Console.ReadLine());
                
                Console.WriteLine("Extrato: {0}", listContas[indice].ExtrairConta());
        }

        private static void CancelarConta()
        {
            Console.Write("Operação realizada apenas por gerente, digite a senha:");
            string senha = Console.ReadLine();
            if(senha == "admin"){
                ListarContas();
                Console.Write("Digite o número da conta que deseja cancelar:");
                int indice = int.Parse(Console.ReadLine());

                listContas.RemoveAt(indice);

                Console.Write("Conta Cancelada com Sucesso!");
            }
            else
                Console.Write("Contate o seu gerente, obrigada!");

        }

        private static void Transferir()
        {
            Console.Write("Digite o número da conta origem:");
            int indiceOriegm = int.Parse(Console.ReadLine());

            Console.Write("Digite o número da conta destino:");
            int indiceDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor de transferência:");
            double valorTransf = double.Parse(Console.ReadLine());

            listContas[indiceOriegm].Transferir(valorTransf, listContas[indiceDestino]);
        }

        private static void Depositar()
        {
              Console.Write("Digite o número da conta:");
            int indice = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor de deposito:");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indice].Depositar(valorDeposito);
        }

        private static void Sacar()
        {
            Console.Write("Digite o número da conta:");
            int indice = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor de saque:");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indice].Sacar(valorSaque);
        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if(listContas.Count == 0){
                Console.WriteLine("Não há contas cadastradas.");
                return;
            }

            for(int i = 0; i < listContas.Count; i++){
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Juridica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o crédito do cliente: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            string entradaExtrato = "Conta Criada, Saldo R$" + entradaSaldo;

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                                    saldo: entradaSaldo,
                                                    credito: entradaCredito,
                                                    nome: entradaNome,
                                                    extrato: entradaExtrato);
            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("***********DIO BANK***********\n");
            Console.WriteLine("Informe a opção desejada:");
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("6- Extrato da Conta");
            Console.WriteLine("7- Cancelar Conta");
            Console.WriteLine("C- Limpar Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
