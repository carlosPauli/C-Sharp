using System;
using System.Collections.Generic;
using System.IO;

namespace myApp
{
    class Program
    {
        // Metodo para ler numeros positivos inteiros
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

        // Metodo para ler numeros positivos Real
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

        // Obter conta
        static Conta ObterConta(List<Conta> contas)
        {
            Int32 posicaoConta = contas.IndexOf(new Conta(LerInteiroPositivo("Informe o número da conta:")));

            if (posicaoConta >= 0)
            {
                return contas[posicaoConta];
            }

            return null;
        }
        
        // Principal
        static void Main(string[] args)
        {
            Int32 opcao = 0;
            List<Conta> contas = new List<Conta>();
            List<String> registroContas = new List<string>();
            Conta conta;

            do
            {
                opcao = LerInteiroPositivo("1 - Abrir Conta Poupança\n2 - Abrir Conta Corrente\n3 - Depositar\n4 - Sacar\n5 - Consultar Saldo\n6 - Consultar Extrato\n7 - Consultar Limite\n8 - Calcular Rendimento\n 9 - Atualizar arquivo TXT\n10 - Sair");

                switch (opcao)
                {
                    case 1:
                        conta = new ContaPoupanca(LerInteiroPositivo("Informe o número da conta:"), LerRealPositivo("Informe a taxa de juros da conta:"));

                        if (contas.Contains(conta))
                        {
                            Console.WriteLine("Conta já cadastrada");
                        }
                        else
                        {
                            registroContas.Add(conta.ToString());
                            
                            Console.WriteLine("Conta cadastrada com sucesso");
                        }
                        break;
                    case 2:
                        conta = new ContaCorrente(LerInteiroPositivo("Informe o número da conta:"), LerRealPositivo("Informe o limite da conta:"));

                        if (contas.Contains(conta))
                        {
                            Console.WriteLine("Conta já cadastrada");
                        }
                        else
                        {
                            registroContas.Add(conta.ToString());
                            
                            Console.WriteLine("Conta cadastrada com sucesso");

                            Console.WriteLine("Conta cadastrada com sucesso");
                        }
                        break;
                    case 3:
                        conta = ObterConta(contas);

                        if (conta != null)
                        {
                            conta.Depositar(LerRealPositivo("Informe o valor do depósito:"));

                            Console.WriteLine("Depósito realizado com sucesso");
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada");
                        }
                        break;
                    case 4:
                        conta = ObterConta(contas);

                        if (conta != null)
                        {
                            if (conta.Sacar(LerRealPositivo("Informe o valor do saque:")))
                            {
                                Console.WriteLine("Saque realizado com sucesso");
                            }
                            else
                            {
                                Console.WriteLine("Saldo insuficiente");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada");
                        }
                        break;
                    case 5:
                        conta = ObterConta(contas);

                        if (conta != null)
                        {
                            Console.WriteLine($"R$ {conta.ObterSaldo():0.00}");
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada");
                        }
                        break;
                    case 6:
                        conta = ObterConta(contas);

                        if (conta != null)
                        {
                            conta.ExibirExtrato();
                        }
                        else
                        {
                            Console.WriteLine("Conta não encontrada");
                        }
                        break;
                    case 7:
                        conta = ObterConta(contas);

                        if (conta == null || !(conta is ContaCorrente))
                        {
                            Console.WriteLine("Conta não encontrada");
                        }
                        else
                        {
                            Console.WriteLine($"R$ {((ContaCorrente)conta).ConsultarLimite():0.00}");
                        }
                        break;
                    case 8:
                        conta = ObterConta(contas);

                        if (conta == null || !(conta is ContaPoupanca))
                        {
                            Console.WriteLine("Conta não encontrada");
                        }
                        else
                        {
                            ((ContaPoupanca)conta).CalcularRendimento();
                        }
                        break;
                    case 9:
                        foreach (Conta c in contas)
                        {
                            registroContas.Add(contas.ToString());
                        }
                        File.WriteAllLines("registroContas.txt", registroContas);

                        Console.WriteLine("Arquivo atualizado");
                        break;
                    case 10:
                        Console.WriteLine("Finalizando o programa...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
            } while (opcao != 10);
        }
    }
}
