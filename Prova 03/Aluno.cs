using System;
using System.Collections.Generic;

namespace myApp

{
    public class Aluno
    {
        private Int32 Codigo { set; get; }
        public String Nome { set; get; }
        private List<Nota> Notas { set; get; }

        public Aluno(Int32 codigo)
        {
            this.Codigo = codigo;
            this.Notas = new List<Nota>();
        }

        public override Boolean Equals(Object obj)
        {
            return this.Codigo == ((Aluno)obj).Codigo;
        }

        public override Int32 GetHashCode()
        {
            return this.Codigo;
        }

        public void CadastraNome(String nome)
        {
            this.Nome = nome;
        }

        public string getNome()
        {
            return this.Nome;
        }


        public void LancarNota(Disciplina disciplina, double nota)
        {
            this.Notas.Add(new Nota(disciplina, nota));
        }
        public void ExibeNotas()
        {
            var notasIterator = this.Notas.GetEnumerator();

            Console.WriteLine($"{this.Codigo} - {this.Nome}");
            while (notasIterator.MoveNext())
            {
                Console.WriteLine(notasIterator.Current);
            }
        }

    }
}