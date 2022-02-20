using System;

namespace myApp
{
    public class Conta
    {

        protected Double Saldo { set; get; }

        protected virtual Boolean ValidarSaque(Double valor)
        {
            return (this.Saldo - valor) >= 0;
        }

        public void Depositar(Double valor)
        {
            this.Saldo = this.Saldo + valor;
        }

        public Boolean Sacar(Double valor)
        {
            if (this.ValidarSaque(valor))
            {
                this.Saldo = this.Saldo - valor;

                return true;
            }

            return false;
        }

        public Double GetSaldo()
        {
            return this.Saldo;
        }

    }
}