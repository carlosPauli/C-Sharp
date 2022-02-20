using System;

namespace myApp
{
    class Program
    {
        // start first method
        static Int32 LerInteiroPositivo(String mensagem)
        {
            Console.WriteLine(mensagem);

            Int32 numeroLido = -1;

            Boolean lerNota = true;



            do
            {
                try
                {
                    numeroLido = Convert.ToInt32(Console.ReadLine());

                    if (numeroLido > 0)
                    {
                        lerNota = false;
                    }
                    else
                    {
                        Console.WriteLine("Favor informar um número inteiro positivo");
                    }
                }
                catch
                {
                    Console.WriteLine("Valor inválido, favor informar um número inteiro positivo");
                }
            } while (lerNota == true);

            return numeroLido;
        }
        // end first method 
        // Start second method
        static Int32 LerNotaPositiva(String mensagem)
        {
            Console.WriteLine(mensagem);

            Int32 NotaLida = -1;

            Boolean lerANota = true;



            do
            {
                try
                {
                    NotaLida = Convert.ToInt32(Console.ReadLine());

                    if (NotaLida > 0)
                    {
                        lerANota = false;
                    }
                    else
                    {
                        Console.WriteLine("Favor informar uma nota valida");
                    }
                }
                catch
                {
                    Console.WriteLine("Valor inválido, favor informar um número inteiro positivo");
                }
            } while (lerANota == true);

            return NotaLida;
        }
        // end second method

        static void Main(string[] args)
        {
            Int32 inteiroPositivo = LerInteiroPositivo("Informe a quantidade de alunos:");

        
            for(Int32 i = 0; i < inteiroPositivo; i++)
            {
                
                Int32 NotaAluno = LerNotaPositiva("Informe a nota do aluno");

                 if(NotaAluno >= 7){
                Console.WriteLine($"O aluno  esta aprovado");
            }
            else
            {
                Console.WriteLine($"O aluno  esta reprovado");
            }

            }
           
    }
    }
}
