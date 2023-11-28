using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorresHanoi_ArqSoft
{
    class Disc
    {
        private int tamanio;
        private int left;
        private int top;
        private ConsoleColor color;

        // Constructor toma tamaño, izquierda, parte superior y color.
        // el tamaño puede estar entre 1 y 5
        public Disc(int tamanio, int left, int top, ConsoleColor color)
        {
            this.tamanio = tamanio;
            this.left = left;
            this.top = top;
            this.color = color;
        }

        // Devuelve el tamaño del disco
        // esta es una propiedad con el método get solamente
        public int Tamanio
        {
            get
            {
                return tamanio;
            }
        }
        // Dibuja el disco imprimiendo 2 * espacios de tamaño comenzando
        // desde la posición <left-size + 1, top>, y luego dibujando
        // 2 dos tubos ("||") en la posición <left, top>
        public void Draw()
        {
            Console.BackgroundColor = color;
            Console.SetCursorPosition(left - tamanio * 2 + 1, top);

            for (int s = 0; s < tamanio * 4; s++)
            {
                Console.Write(" ");
            }

            Console.SetCursorPosition(left, top);
            Console.Write("||");

            Console.ResetColor();
        }

        // Establece la coordenada del disco en <left, top>
        // sin realmente dibujar el disco en la pantalla
        public void Move(int left, int top)
        {
            this.left = left;
            this.top = top;
        }
    }
}
