using System;

namespace myApp
{
    [Serializable]
    public class Transacao
    {
        private Char Tipo { set; get; } // S – Saque, D – Depósito e R – Rendimento
        private Double Valor { set; get; }

        public Transacao(Char tipo, Double valor)
        {
            this.Tipo = tipo;
            this.Valor = valor;
        }

        public override String ToString()
        {
            switch (this.Tipo)
            {
                case 'D':
                    return $"R$ {this.Valor:0.00} (depósito)";
                case 'S':
                    return $"R$ {this.Valor:0.00} (saque)";
                default:
                    return $"R$ {this.Valor:0.00} (rendimento)";
            }
        }
    }
}