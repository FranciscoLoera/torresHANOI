using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorresHanoi_ArqSoft
{
    class Peg
    {
        private Disc[] discs;
        private int left;
        private int top;
        private int bot;
        private int index;
        private int tamanio;

        // Crea una clavija con los siguientes parámetros:
        // maxDisc: el número máximo de discos en el juego
        // izquierda, arriba, bot:
        // la clavija se dibuja como una línea de dos tubos (||)
        // de <left, top> a <left, bot>
        public Peg(int maxDisc, int left, int top, int bot)
        {
            discs = new Disc[maxDisc];
            index = -1;
            this.left = left;
            this.top = top;
            this.bot = bot;
            tamanio = maxDisc;
        }

        // Empuja dsc en la clavija
        // si la clavija está vacía
        // o dsc.Size <tamaño del disco superior en clavija>
        public bool Push(Disc dsc)
        {
            if (DiscCount() == 0 || dsc.Tamanio < Peek().Tamanio)
            {
                index++;
                discs[index] = dsc;

                return true;
            }
            else
            {
                return false;
            }
        }

        // Saca un disco de la clavija y regresa
        public Disc Pop()
        {
            if (tamanio > 0)
            {
                Disc disc = discs[index];
                discs[index] = null;

                index--;

                return disc;
            }

            return null;
        }
        // Devuelve el disco más alto sin hacer estallar
        public Disc Peek()
        {
            if (index >= 0)
            {
                return discs[index];
            }

            return null;
        }

        // Dibuja la clavija y todos los discos que contiene.
        public void Draw()
        {
            // dibuja el poste
            for (int row = 0; row < 8; row++)
            {
                Console.SetCursorPosition(left, top + row);
                Console.Write("{0}", "||");
            }

            // dibuja el disco
            for (int row = index; row >= 0; row--)
            {
                discs[row].Draw();
            }
        }

        //Devuelve el número de discos en la clavija.
        public int DiscCount()
        {
            return index + 1;
        }
    }
}
