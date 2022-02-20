namespace myApp
{
    public class Nota
    {
        private Disciplina Disciplina { get; set; }
        private double _Nota { get; set; }

        public Nota(Disciplina disciplina, double nota)
        {
            this.Disciplina = disciplina;
            this._Nota = nota;
        }

        public override string ToString()
        {
            return $"{this.Disciplina.ToString()} - {_Nota:N} {(_Nota >= 6 ? "(Aprovado)" : "(Reprovado)")}";
        }
    }
}