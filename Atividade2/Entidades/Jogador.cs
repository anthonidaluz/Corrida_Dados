using System;
using System.Threading;

namespace Atividade2.Entidades
{
    public class Jogador
    {
        public string Nome { get; set; }
        public int Posicao { get; set; }

        public Jogador(string nome)
        {
            Nome = nome;
            Posicao = 0;
        }

        public bool ExecutarRodada(Dado dado)
        {
            Console.WriteLine($"\n[{Nome}] O seu Dado está rolando...");
            Thread.Sleep(1500);

            int valorSorteado = dado.Rolar();
            Console.WriteLine($"[{Nome}] Dado sorteado: {valorSorteado}");

            Posicao += valorSorteado;

            if (Posicao == 7)
            {
                Console.WriteLine($"=> Sorte grande, {Nome}! Casa 7 premiada, avance 3 casas!");
                Posicao += 3;
            }
            else if (Posicao == 21)
            {
                Console.WriteLine($"=> Cuidado, {Nome}! Armadilha na casa 21, volte 7 casas!");
                Posicao -= 7;
            }

            Console.WriteLine($"[{Nome}] Sua nova posição é: {Posicao}");

            if (valorSorteado == 6)
            {
                Console.WriteLine($"=> Que sorte, {Nome} tirou 6! Vai jogar novamente!");
                return true;
            }

            return false;
        }
    }
}