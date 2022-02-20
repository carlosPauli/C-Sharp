using System;
using System.Collections.Generic;

namespace myApp
{
    public class Conta
    {
        private Int32 Numero { set; get; }

        protected Double Saldo { set; get; }

        protected List<Transacao> Transacoes { set; get; }

        public Conta(Int32 numero)
        {
            this.Numero = numero;
            this.Transacoes = new List<Transacao>();
        }

        protected virtual Boolean ValidarSaque(Double valor)
        {
            return (this.Saldo - valor) >= 0;
        }

        public void Depositar(Double valor, Boolean salvarTransacao = true)
        {
            this.Saldo = this.Saldo + valor;

            if (salvarTransacao)
            {
                this.Transacoes.Add(new Transacao('D', valor));
            }
        }

        public Boolean Sacar(Double valor)
        {
            if (this.ValidarSaque(valor))
            {
                this.Saldo = this.Saldo - valor;

                this.Transacoes.Add(new Transacao('S', valor));

                return true;
            }

            return false;
        }

        public Double ObterSaldo()
        {
            return this.Saldo;
        }

        public void ExibirExtrato()
        {
            var transacoesIterator = this.Transacoes.GetEnumerator();

            while (transacoesIterator.MoveNext())
            {
                Console.WriteLine(transacoesIterator.Current);
            }

            Console.WriteLine($"Saldo: R$ {this.Saldo:0.00}");
        }

        public override Boolean Equals(Object obj)
        {
            return this.Numero == ((Conta)obj).Numero;
        }

        public override Int32 GetHashCode()
        {
            return this.Numero;
        }

        public override String ToString()
        {
            return $"{this.Numero}: R$ {this.Saldo:0.00}";
        }

    }
}
