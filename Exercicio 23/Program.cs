using System;
using System.Collections.Generic;

namespace myApp
{
    class Program
    {
         // Metodo para leitura da matricula
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
        // Fim do metodo

        // Metodo para leitura de numeros reais (Saque e deposito)
        static Double LerNumeroReal(String mensagem, Boolean positivo = true)
        {
            Console.WriteLine(mensagem);
            Double numLido = -1;
            Boolean valido = true;

            do
            {
                try
                {
                    numLido = Convert.ToDouble(Console.ReadLine());
                    if (positivo)
                    {
                        
                    valido = false;
                
                    }
                    else
                    {
                        valido = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida, favor informar um número no campo.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Número inválido, detalhes: {e.Message}");
                }
            } while (valido);

            return numLido;
        }      

        // Fim do metodo  


        static void Main(string[] args)
        {
             List<Conta> contas = new List<Conta>();
           
            
            Conta conta;

            Int32 menu;
            Int32 cadastraConta;
            Int32 posicao;
            Double valorSaque;
            Double valorDeposito;
            

             
             do
            {
                menu = LerInteiroPositivo(" 1 - Cadastrar conta bancaria\n 2 - Sacar Valor\n 3 - Depositar valor\n 4 - Consultar saldo\n 5 - Exit");

                switch(menu)
                {
                    case 1:
                        cadastraConta = LerInteiroPositivo("Informe o numero da conta:");

                        conta = new Conta(cadastraConta);
                        if(contas.Contains(new Conta(cadastraConta))) {
                            Console.WriteLine("Conta já existe");
                        }
                        else
                        {
                            contas.Add(conta);
                            Console.WriteLine("Conta Criada com sucesso");


                        }
                        break;
                    case 2:
                        
                        cadastraConta = LerInteiroPositivo("Informe o numero da conta: ");
                        posicao = contas.IndexOf(new Conta(cadastraConta));
                        
                        if(contas.Contains(new Conta(cadastraConta))) {
                            valorSaque = LerNumeroReal("Informe o valor a ser sacado: ");

                            if(contas[posicao].Sacar(valorSaque)){
                                Console.WriteLine("O saque foi realizado com sucesso");
                            }
                            else{
                                Console.WriteLine("Saldo insuficiente");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Conta não existe!");
                        }
                        break;
                    case 3:
                        cadastraConta = LerInteiroPositivo("Informe o numero da conta: ");
                        posicao = contas.IndexOf(new Conta(cadastraConta));

                        if(contas.Contains(new Conta(cadastraConta))) {
                            valorDeposito = LerNumeroReal("Informe o valor a ser depositado: ");
                            contas[posicao].Depositar(valorDeposito);

                            Console.WriteLine("Deposito realizado");
                        }
                        else
                        {
                            Console.WriteLine("Conta não existe!");
                        }
                        break;
                    case 4:
                        cadastraConta = LerInteiroPositivo("Informe o numero da conta");
                        posicao = contas.IndexOf(new Conta(cadastraConta));
                        
                        if(contas.Contains(new Conta(cadastraConta))) {
                            Console.WriteLine($"O valor atual da sua conta é {contas[posicao].ObterSaldo()}");
                        }
                        else
                        {
                            Console.WriteLine("Conta não existe!");

                        }
                        break;
                    case 5:
                        Console.WriteLine("Finalizando sistema");
                        break;
                        default:
                        Console.WriteLine("Opção invalida");
                        break;

                }   
             
            }while (menu != 5);
        }
    }
}