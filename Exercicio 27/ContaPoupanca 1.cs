using System;

namespace myApp
{
    [Serializable]
    public class ContaPoupanca : Conta
    {
        private Double TaxaJuros { set; get; }

        public ContaPoupanca(Int32 numero, Double taxaJuros) : base(numero)
        {
            this.TaxaJuros = taxaJuros;
        }

        public void CalcularRendimento()
        {
            Double valor = (this.Saldo * this.TaxaJuros) / 100;

            Console.WriteLine($"Saldo anterior: R$ {this.Saldo:0.00}");
            Console.WriteLine($"Rendimento: R$ {valor:0.00}");

            this.Depositar(valor, false);

            Console.WriteLine($"Novo saldo: R$ {this.Saldo:0.00}");
            Console.WriteLine($"Taxa de juros: {this.TaxaJuros}%");

            this.Transacoes.Add(new Transacao('R', valor));
        }
    }
}