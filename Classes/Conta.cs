using System;

namespace Rafa.Conta
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }
        public bool Sacar(double valorSaque)
		{            
            if (this.Saldo - valorSaque < (this.Credito *-1)){
                Console.WriteLine("Saldo insuficiente!");
                return false;
            }
            this.Saldo -= valorSaque;

            Console.WriteLine("Saldo da conta de {0} é de R$ {1}", this.Nome, (this.Saldo).ToString("N2"));            

            return true;
		}
        public void Depositar(double valorDeposito)
		{
			this.Saldo += valorDeposito;

            Console.WriteLine("Saldo da conta de {0} é de R$ {1}", this.Nome, (this.Saldo).ToString("N2"));
		}

        public void Transferir(double valorTransferencia, Conta contaDestino)
		{
			if (this.Sacar(valorTransferencia)){
                contaDestino.Depositar(valorTransferencia);
            }
		}

        public override string ToString()
		{
            string retorno = "";
            retorno += "Tipo da Conta: " + this.TipoConta + " - ";
            retorno += "Nome: " + this.Nome + " - ";
            retorno += "Saldo: R$ " + (this.Saldo).ToString("N2") + " - ";
            retorno += "Crédito: R$ " + (this.Credito).ToString("N2");
			return retorno;
		}
    }
}