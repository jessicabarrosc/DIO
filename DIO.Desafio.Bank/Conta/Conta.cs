using System;

namespace DIO.Desafio.Bank
{
    public class Conta
    {
        public Conta(string nome, double saldo, double credito, string extrato)
        {
            this.Nome = nome;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Extrato = extrato;

        }
        private string Nome { get; set; }
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Extrato {get; set;}

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome, string extrato)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
            this.Extrato = extrato;
        }

        public bool Sacar(double valorSaque)
        {
            if (this.Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                return false;
            }
            
            this.Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", this.Nome, this.Saldo);
            this.Extrato += "\nSaque no valor R$" + valorSaque;
            this.Extrato += "\nSaldo Atual: R$" + Saldo; 
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            this.Saldo += valorDeposito;

            Console.WriteLine("Deposito efetuado! \nConta de :{0}\nSaldo Atual:{1}", this.Nome, this.Saldo);
            this.Extrato += "\nDeposito no valor R$" + valorDeposito;
            this.Extrato += "\nSaldo Atual: R$" + Saldo; 
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            //reuso validação
            if(this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }

            this.Extrato += "\nTransferência para" + contaDestino.Nome + "Valor: R$" + valorTransferencia;
            this.Extrato += "\nSaldo Atual: R$" + Saldo; 

        }

       public string ExtrairConta(){

           return this.Extrato.ToString();
       }

        public override string ToString()
        {
            String retorno = "";
            retorno += "TipoConta: "+ this.TipoConta + " | ";
            retorno += "Nome: "+ this.Nome + " | ";
            retorno += "Saldo: "+ this.Saldo + " | ";
            retorno += "Crédito: "+ this.Credito + " | ";
            retorno += "Extrato: "+ this.Extrato;
            return retorno;
        }
    }
}
