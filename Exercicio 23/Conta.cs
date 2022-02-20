using System;

namespace myApp
{
    public class Conta
    {
        private Int32 Numero { set; get; }

        protected Double Saldo { set; get; }

        public Conta(Int32 numero)
        {
            this.Numero = numero;
        }

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

        public Double ObterSaldo()
        {
            return this.Saldo;
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
            return $"{this.Numero}: R$ {this.Saldo}";
        }

    }
}
