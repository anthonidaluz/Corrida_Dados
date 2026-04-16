using System;
using System.Threading;
using Atividade2.Entidades;

namespace Atividade2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("=======================================");
            Console.WriteLine("            CORRIDA DE DADOS           ");
            Console.WriteLine("=======================================");
            Thread.Sleep(1000);

            Dado dadoDoJogo = new Dado();

            Console.WriteLine("Pressione ENTER para começar! ");
            Console.ReadLine();

            Console.Clear();
            Console.Write("\nInforme seu Nome: ");
            string nomeDigitado = Console.ReadLine();

            Jogador jogador1 = new Jogador(nomeDigitado);
            Computador bot = new Computador();

            bool turnoJogador = true;

            while (true)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("POSIÇÕES ATUAIS");
                Console.WriteLine($"{jogador1.Nome,-15}: {jogador1.Posicao,3}");
                Console.WriteLine($"{bot.Nome,-15}: {bot.Posicao,3}");
                Console.WriteLine("=======================================\n");

                if (turnoJogador)
                {
                    Console.WriteLine($"{jogador1.Nome}, pressione ENTER para jogar o dado!");
                    Console.ReadLine();

                    bool jogaDeNovo = jogador1.ExecutarRodada(dadoDoJogo);

                    if (jogador1.Posicao >= 30)
                    {
                        AnunciarVencedor(jogador1.Nome);
                        break;
                    }

                    if (!jogaDeNovo) turnoJogador = false;
                }
                else
                {
                    Console.WriteLine($"É a vez do {bot.Nome} jogar! ");

                    bool jogaDeNovo = bot.ExecutarRodada(dadoDoJogo);

                    if (bot.Posicao >= 30)
                    {
                        AnunciarVencedor(bot.Nome);
                        break;
                    }

                    if (!jogaDeNovo) turnoJogador = true;
                }

                Console.WriteLine("\nPressione ENTER para continuar! ");
                Console.ReadLine();
                Console.Clear();
            }
        }

        static void AnunciarVencedor(string nomeVencedor)
        {
            Console.WriteLine("\n=======================================");
            Console.WriteLine($"🏆 VENCEDOR: {nomeVencedor}! 🏆");
            Console.WriteLine("=======================================");
            Console.WriteLine("\nPressione ENTER para Finalizar! ");
            Console.ReadLine();
        }
    }
}