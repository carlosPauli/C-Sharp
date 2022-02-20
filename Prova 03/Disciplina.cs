using System;
using System.Collections.Generic;

namespace myApp

{
    public class Disciplina
    {
        private int ID { get; set; }
        protected string Nome { get; set; }

        public Disciplina(int id)
        {
            this.ID = id;
        }

        public void addNome(string nome)
        {
            this.Nome = nome;
        }

        public override string ToString()
        {
            return this.Nome;
        }

        public override bool Equals(Object obj)
        {
            return this.ID == ((Disciplina)obj).ID;
        }

        public override Int32 GetHashCode()
        {
            return this.ID;
        }
    }
}