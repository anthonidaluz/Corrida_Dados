using System;
using System.Threading;

namespace Atividade2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=======================================");
            Console.WriteLine("            CORRIDA DE DADOS           ");
            Console.WriteLine("=======================================");
            Thread.Sleep(1000);

            Random aleatorio = new Random();

            int posicaoJogador = 0;
            int posicaoBot = 0;
            bool turnoJogador = true;

            Console.WriteLine("Pressione ENTER para começar! ");
            Console.ReadLine();

            Console.Clear();
            Console.Write("\nInforme seu Nome: ");
            string nome = Console.ReadLine();

            while (true)
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("POSIÇÕES ATUAIS");
                Console.WriteLine($"{nome,-15}: {posicaoJogador,3}");
                Console.WriteLine($"Computador     : {posicaoBot,3}");
                Console.WriteLine("=======================================\n");

                if (turnoJogador)
                {
                    Console.WriteLine($"{nome}, pressione ENTER para jogar o dado!");
                    Console.ReadLine();


                    bool jogaDeNovo = ExecutarRodada(nome, ref posicaoJogador, aleatorio);

                    if (posicaoJogador >= 30)
                    {
                        AnunciarVencedor(nome);
                        break;
                    }

                    if (!jogaDeNovo) turnoJogador = false;
                }
                else
                {
                    Console.WriteLine("É a vez do BOT jogar! ");


                    bool jogaDeNovo = ExecutarRodada("Computador", ref posicaoBot, aleatorio);

                    if (posicaoBot >= 30)
                    {
                        AnunciarVencedor("Computador");
                        break;
                    }

                    if (!jogaDeNovo) turnoJogador = true;
                }

                Console.WriteLine("\nPressione ENTER para continuar! ");
                Console.ReadLine();
                Console.Clear();
            }

            Console.WriteLine("\nFim de jogo! ");
        }

        static bool ExecutarRodada(string nomeDaVez, ref int posicaoAtual, Random aleatorio)
        {
            Console.WriteLine("O Dado está rolando...\n");
            Thread.Sleep(1500);

            int dado = aleatorio.Next(1, 7);
            Console.WriteLine($"Dado sorteado: {dado}");

            posicaoAtual += dado;

            if (posicaoAtual == 7)
            {
                Console.WriteLine($"Sorte grande, {nomeDaVez}! Posição 7 premiada, avance 3 casas!");
                posicaoAtual += 3;
                Console.WriteLine($"Nova posição: {posicaoAtual}");
            }
            else if (posicaoAtual == 21)
            {
                Console.WriteLine($"Deu ruim, {nomeDaVez}! Posição 21 com armadilha, volte 7 casas!");
                posicaoAtual -= 7;
                Console.WriteLine($"Nova posição: {posicaoAtual}");
            }

            if (dado == 6)
            {
                Console.WriteLine($"Que sorte, {nomeDaVez} tirou 6! Vai jogar novamente!");
                return true;
            }

            return false;
        }

        static void AnunciarVencedor(string nomeVencedor)
        {
            Console.WriteLine("\n=======================================");
            Console.WriteLine($"VENCEDOR: {nomeVencedor}!");
            Console.WriteLine("=======================================");

            Console.WriteLine("\nPressione ENTER para Finalizar! ");
            Console.ReadLine();
        }
    }
}