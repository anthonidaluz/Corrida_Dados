using System;
using System.Threading;

namespace Atividade2.Entidades
{
    public class Computador
    {
        public string Nome { get; private set; }
        public int Posicao { get; set; }

        public Computador()
        {
            Nome = "Computador";
            Posicao = 0;
        }

        public bool ExecutarRodada(Dado dado)
        {
            Console.WriteLine($"\n[{Nome}] Calculando jogada e rolando o dado...");
            Thread.Sleep(1500);

            int valorSorteado = dado.Rolar();
            Console.WriteLine($"[{Nome}] Dado sorteado: {valorSorteado}");

            Posicao += valorSorteado;

            if (Posicao == 7)
            {
                Console.WriteLine($"O {Nome} caiu na casa 7 e avançou 3 casas automáticas.");
                Posicao += 3;
            }
            else if (Posicao == 21)
            {
                Console.WriteLine($"O {Nome} caiu na armadilha 21 e perdeu 7 casas.");
                Posicao -= 7;
            }

            Console.WriteLine($"[{Nome}] A nova posição do BOT é: {Posicao}");

            if (valorSorteado == 6)
            {
                Console.WriteLine($"Alerta: O {Nome} tirou 6 e ganhou uma rodada extra!");
                return true;
            }

            return false;
        }
    }
}