using System;
using System.Collections.Generic;

namespace myApp
{
    class Program
    {
        static Int32 LerInteiroPositivo(String mensagem)
        {
            Int32 numero = 0;
            Boolean lerNumero = true;

            Console.WriteLine(mensagem);

            do
            {
                try
                {
                    numero = Convert.ToInt32(Console.ReadLine());

                    if (numero > 0)
                    {
                        lerNumero = false;
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
            } while (lerNumero == true);

            return numero;
        }

        static Double LerRealPositivo(String mensagem)
        {
            Double numero = 0;
            Boolean lerNumero = true;

            Console.WriteLine(mensagem);

            do
            {
                try
                {
                    numero = Convert.ToDouble(Console.ReadLine());

                    if (numero > 0)
                    {
                        lerNumero = false;
                    }
                    else
                    {
                        Console.WriteLine("Favor informar um número real positivo");
                    }
                }
                catch
                {
                    Console.WriteLine("Valor inválido, favor informar um número real positivo");
                }
            } while (lerNumero == true);

            return numero;
        }

        static String LerString(String mensagem)

        {
            Console.WriteLine(mensagem);

            String texto = Console.ReadLine();

            return texto;
        }
       
        static Aluno ObterAluno(List<Aluno> aluno)
        {
            Int32 posicaoConta = aluno.IndexOf(new Aluno(LerInteiroPositivo("Informe o número do aluno:")));

            if (posicaoConta >= 0)
            {
                return aluno[posicaoConta];
            }

            return null;
        }

        static double ObterNota(String mensagem)
        {
            Console.WriteLine(mensagem);
            Double numLido = -1;
            Boolean valido = true;
            string teste = "";

            do
            {
                try
                {
                    teste = Console.ReadLine();
                    numLido = Convert.ToDouble(teste.Replace('.', ','));
                    if (numLido >= 0 && numLido <= 10)
                    {
                        valido = false;
                    }
                    else
                    {
                        throw new Exception("Informe uma nota válida.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida, favor informar um número no campo.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Entrada inválida, detalhes: {e.Message}");
                }
            } while (valido);

            return numLido;
        }
      
        static Disciplina ObterDisciplina(List<Disciplina> disciplina)
        {
            Int32 posicaoConta = disciplina.IndexOf(new Disciplina(LerInteiroPositivo("Informe o número da diciplina:")));

            if (posicaoConta >= 0)
            {
                return disciplina[posicaoConta];
            }

            return null;
        }
        static void Main(string[] args)
        {
            Int32 opcao = 0;

            List<Disciplina> disciplinas = new List<Disciplina>();
            Disciplina disciplina;

            List<Aluno> alunos = new List<Aluno>();
            Aluno aluno;

            List<Nota> notas = new List<Nota>();
            Double nota = -1;

            String nomeAluno;
            String nomeMateria;
            
            

            do
            {
                opcao = LerInteiroPositivo("1 - Cadastrar Matéria\n2 - Cadastrar Alunos\n3 - Lançar Notas\n4 - Exibir Aluno\n5 - Sair");

                switch (opcao)
                {
                    case 1:
                        disciplina = new Disciplina(LerInteiroPositivo("Informe o codigo da materia:"));

                        if (disciplinas.Contains(disciplina))
                        {
                            Console.WriteLine("Matéria já cadastrada");
                        }
                        else
                        {
                            nomeMateria = LerString("Informe o nome da materia:");
                            disciplinas.Add(disciplina);

                            Console.WriteLine("Materia cadastrada com sucesso");
                        }
                        break;
                    case 2:
                        aluno = new Aluno(LerInteiroPositivo("Informe a matricula do aluno:"));

                        if (alunos.Contains(aluno))
                        {
                            Console.WriteLine("Conta já cadastrada");
                        }
                        else
                        {   
                        
                        nomeAluno = LerString("Informe o nome do aluno:");

                        alunos.Add(aluno);

                        Console.WriteLine("Aluno matriculado com sucesso");
                        }
                        break;
                   case 3:

                        disciplina = ObterDisciplina(disciplinas);
                        if (disciplina != null)
                            {
                                    aluno = ObterAluno(alunos);
                                    if (aluno != null)
                                    {
                                        nota = ObterNota("Informe a nota do aluno: ");
                                        aluno.LancarNota(disciplina, nota);
                                        Console.WriteLine("Nota lançada com sucesso");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Aluno não encontrado");
                                    }
                            }
                        else
                        {
                             Console.WriteLine("Disciplina não encontrada");
                        }

                        break;

                    case 4:
                        aluno = ObterAluno(alunos);

                        if (aluno != null)
                        {
                            aluno.ExibeNotas();
                        }
                        else
                        {
                            Console.WriteLine("Aluno não encontrado");
                        }
   

                        break;
                    case 5:
                        Console.WriteLine("Finalizando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (opcao != 5);
        }
    }
}
