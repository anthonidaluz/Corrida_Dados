using System;
using System.ComponentModel.Design;
using System.Threading;

namespace Atividade2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("           CORRIDA DE DADOS            ");
            Console.WriteLine("=======================================");
            Thread.Sleep(1000);

            Random aleatorio = new Random();

            string nome;
            int posicaoJogador = 0;
            int posicaoBot = 0;
            Boolean turnoJogador = true;

            Console.WriteLine("Pressione ENTER para começar! ");
            Console.ReadLine();

            Console.Clear();

            Console.Write("\nInforme seu Nome: ");
            nome = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("POSIÇÕES ATUAIS");
                Console.WriteLine($"{nome,-15}: {posicaoJogador,3}");
                Console.WriteLine($"Computador     : {posicaoBot,3}");
                Console.WriteLine("=======================================\n");

                if (turnoJogador)
                {
                    Console.WriteLine($"{nome} Pressione ENTER para jogar o dado!");
                    Console.ReadLine();
                    Console.WriteLine("Dado está rolando...");
                    Console.WriteLine();
                    Thread.Sleep(1500);

                    int dado = aleatorio.Next(1, 7);

                    Console.WriteLine($"Dado sorteado: {dado}");
                    posicaoJogador = posicaoJogador + dado;
                    if (posicaoJogador == 7)
                    {
                        Console.WriteLine($"Posição {posicaoJogador} premiada avance 3 casas!");
                        posicaoJogador = posicaoJogador + 3;
                        Console.WriteLine($"Nova posição: {posicaoJogador}");
                    }
                    else if (posicaoJogador == 21)
                    {
                        Console.WriteLine($"Posição {posicaoJogador} premiada volte 7 casas!");
                        posicaoJogador = posicaoJogador - 7;
                        Console.WriteLine($"Nova posição: {posicaoJogador}");
                    }

                    if (posicaoJogador >= 30)
                    {
                        Console.WriteLine("\n=======================================");
                        Console.WriteLine($"VENCEDOR: {nome}");
                        Console.WriteLine("=======================================");
                        break;
                    }

                    if (dado != 6)
                        turnoJogador = false;
                    else
                        Console.WriteLine("Sorte você tirou 6. Jogue novamente! ");
                }
                else
                {
                    Console.WriteLine("É a vez do BOT jogar! ");
                    Console.WriteLine("Dado está rolando...");
                    Console.WriteLine();
                    Thread.Sleep(1500);

                    int dado = aleatorio.Next(1, 7);

                    Console.WriteLine($"Dado sorteado: {dado}");
                    posicaoBot = posicaoBot + dado;
                    if (posicaoBot == 7)
                    {
                        Console.WriteLine($"Posição {posicaoBot} premiada avance 3 casas!");
                        posicaoBot = posicaoBot + 3;
                        Console.WriteLine($"Nova posição: {posicaoBot}");
                    }
                    else if (posicaoBot == 21)
                    {
                        Console.WriteLine($"Posição {posicaoBot} premiada volte 7 casas!");
                        posicaoBot = posicaoBot - 7;
                        Console.WriteLine($"Nova posição: {posicaoBot}");
                    }

                    if (posicaoBot >= 30)
                    {
                        Console.WriteLine("=======================================");
                        Console.WriteLine("VENCEDOR: BOT");
                        Console.WriteLine("=======================================");
                        break;
                    }

                    if (dado != 6)
                        turnoJogador = true;
                    else
                        Console.WriteLine("O BOT está sortudo tirou 6. Vai jogar novamente!");
                }

                Console.WriteLine();
                Console.WriteLine("Pressione ENTER para continuar! ");
                Console.ReadLine();
                Console.Clear();
            }

            Console.WriteLine();
            Console.WriteLine("Fim de jogo! ");

        }
    }
}

// Anthoni da Luz.