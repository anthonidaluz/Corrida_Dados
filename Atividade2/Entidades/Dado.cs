using System;

namespace Atividade2.Entidades
{
    public class Dado
    {
        private Random aleatorio;

        public Dado()
        {
            aleatorio = new Random();
        }

        public int Rolar()
        {
            return aleatorio.Next(1, 7);
        }
    }
}