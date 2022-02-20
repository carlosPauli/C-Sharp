using System;
using System.Collections.Generic;

namespace myApp
{
    [Serializable]
    public class ContaCorrente : Conta
    {
        protected Double Limite { set; get; }

        public ContaCorrente(Int32 numero, Double limite) : base(numero)
        {
            this.Limite = limite;
            this.Transacoes = new List<Transacao>();
        }

        public Double ConsultarLimite()
        {
            return this.Limite;
        }

        protected override Boolean ValidarSaque(Double valor)
        {
            return (this.Saldo - valor) >= 0;
        }

    }
}
