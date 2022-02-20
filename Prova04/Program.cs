using System;
using System.Collections.Generic;
using System.IO;


namespace myApp
{
    class Program
    {   
        // Leitura dos numeros inteiros
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
        // calculo fatorial
        static Int32 CalcularFatorial(Int32 numero)
        {
            if (numero < 2)
            {
                return 1;
            }

            return numero * CalcularFatorial(numero - 1);
        }

        // calculo de numeros primos
        static Boolean EhPrimo(Int32 numero)

        {
            Int32 divisor = 2;
            Boolean ehPrimo = true;

            while (divisor < numero && ehPrimo == true)
            {
                if (numero % divisor == 0)
                {
                    ehPrimo = false;
                }
                divisor++;
            }

            return ehPrimo;
        }
        

        // principal
        static void Main(string[] args)
        {
            List<Int32> numeros = new List<Int32>();
            List<String> log = new List<String>();
            Int32 numeroPrimo = 0;
            Int32 num = 0;
            
            Int32 menu = 0;

             try

            {

                log.AddRange(File.ReadLines("log.txt"));

                log.Add(($"O número {numeros} é primo\n"));

                log.Add($"O fatorial do número {num} é igual a {CalcularFatorial(num)}\n");

            }

            catch

            {

            }

           // menu
             do
            {
                 menu = LerInteiroPositivo("1 - Verificar Primo\n2 - Verificar Fatorial\n3 - Ver Logs\n4 - Sair");

                switch (menu)
                {
                    case 1:
                        numeroPrimo = (LerInteiroPositivo("Informe um número para verificar se é primo"));
                        if(EhPrimo(numeroPrimo))
                        {
                            
                         
                            Console.WriteLine("O número {0} é primo", numeroPrimo);
                            
                        }
                        
                        else
                        {
                            Console.WriteLine("O número {0} não é primo", numeroPrimo);
                        }
                            
                        break;
                    case 2:
                        Int32 numero = LerInteiroPositivo("Informe um número inteiro:");

                        Int32 resultadoFor = 1;
                        
                        for (Int32 i = numero; i >= 1; i--)
                        {
                            resultadoFor = resultadoFor * i;
                        }  
                        
                        Console.WriteLine($"O fatorial de {numero} é igual a {resultadoFor}");
                               
                        break;
                    case 3:
                    try

                    {

                        log.AddRange(File.ReadLines("log.txt"));

                        log.Add(($"O número {numeros} é primo\n"));

                        log.Add($"O fatorial do número {num} é igual a {CalcularFatorial(num)}\n");

                    }  
                        
                        catch
    
                        {
    
                        }
                            break;
                    case 4:
                        Console.WriteLine("Saindo...");
                        break;
                    
                }

            } while (menu != 4);   
        }
    }
}
