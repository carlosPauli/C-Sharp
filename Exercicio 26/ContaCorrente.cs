using System;

namespace myApp
{
    public class ContaCorrente : Conta
    {
        private Double Limite { set; get; }

        public ContaCorrente(Int32 numero, Double limite) : base(numero)
        {
            this.Limite = limite;
        }

        protected override bool ValidarSaque(double valor)
        {
            return ((this.Saldo + this.Limite) - valor) >= 0;
        }

        public Double ConsultarLimite()
        {
            return this.Limite;
        }
    }
}
