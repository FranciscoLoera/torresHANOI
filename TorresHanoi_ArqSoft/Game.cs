using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorresHanoi_ArqSoft
{
    class Game
    {
        private int moves;
        private int nDisc;
        private Peg[] pegs;

        // Constructor:
        // toma el número de discos (nDisc) del juego.
        // 1. Crea 3 clavijas
        // 2. Crea n discos con tamaño 1, 2, 3, etc. y los empuja a la Peg 0
        // 3. Establece el tamaño de la consola en Map.MaxLeft y Map.MaxTop
        // 4. Empuje los discos en Peg [0]
        public Game(int nDisc)
        {
            pegs = new Peg[3];
            pegs[0] = new Peg(nDisc, Map.PegLeft[0], Map.PegTop, Map.PegBot);
            pegs[1] = new Peg(nDisc, Map.PegLeft[1], Map.PegTop, Map.PegBot);
            pegs[2] = new Peg(nDisc, Map.PegLeft[2], Map.PegTop, Map.PegBot);

            for (int i = nDisc - 1, index = 0; i >= 0; i--, index++)
            {
                pegs[0].Push(new Disc(i + 1, Map.PegLeft[0], Map.PegBot - index, Map.DiskColors[i]));
            }

            Console.SetWindowSize(Map.MaxLeft, Map.MaxTop);

            this.nDisc = nDisc;
            moves = 0;
        }

        // Computadora resuelve el juego
        public void ComputerPlays(int discs, int src, int aux, int dst)
        {
            if (discs > 0)
            {
                ComputerPlays(discs - 1, src, dst, aux);
                Move(src, dst);
                ComputerPlays(discs - 1, aux, src, dst);
            }
        }

        // Mueve el disco superior de Pegs [src] a Pegs [dst] si
        // SI src y dst están en [0 ... 2] y
        // Pegs [src] tiene un disco y
        // (Pegs [dst] está vacío o
        // disco superior en Pegs [dst]> disco superior en Pegs [src])
        // devuelve verdadero si se hizo el movimiento
        // No vuelve a dibujar el tablero
        public bool Move(int src, int dst)
        {
            try
            {
                // actualiza los numeros de movimientos
                moves++;

                // Procesa los movimientos
                if (src >= 0 && src <= 2 && dst >= 0 && dst <= 2 && pegs[src].DiscCount() > 0)
                {
                    if (pegs[dst].Push(pegs[src].Peek()))
                    {
                        pegs[dst].Peek().Move(Map.PegLeft[dst], Map.PegBot - pegs[dst].DiscCount() + 1);

                        pegs[src].Pop();

                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        // Imprime el mensaje de error en la ubicación Map.MsgLeft, Map.MsgTop
        // en texto amarillo sobre fondo rojo oscuro
        public void Message(string msg)
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(Map.MsgLeft, Map.MsgTop);

            Console.Write(msg);

            Console.ResetColor();
        }
        // Imprime el mensaje al ganar en la ubicación Map.MsgLeft, Map.MsgTop
        // en texto verde
        public void MessageWin(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(Map.MsgLeft, Map.MsgTop);

            Console.Write(msg);

            Console.ResetColor();
        }

        // Dibuja lo siguiente:
        // 0. Limpia la pantalla primero
        // 1. Línea base desde <Map.Baseleft, Map.BaseTop> hasta
        // <Map.BaseRight, Map.BaseTop>
        // 2. Tres clavijas y los discos en ellas
        // 3. Número de movimientos en <Map.MovesLeft, Map.MovesTop>
        public void Draw()
        {
            Console.Clear();

            // crea la base 
            Console.SetCursorPosition(Map.BaseLeft, Map.BaseTop);
            for (int i = Map.BaseLeft; i <= Map.BaseRight; i++)
            {
                Console.Write("=");
            }

            // crea las clavijas
            for (int i = 0; i < pegs.Length; i++)
            {
                pegs[i].Draw();
            }

            // crea los movimientos 
            Console.SetCursorPosition(Map.MovesLeft, Map.MovesTop);
            Console.Write("Movimientos hechos : {0}", moves);
        }

        // Comprueba si el juego ha terminado,
        // es decir, la clavija derecha tiene todos los discos
        public bool Win()
        {
            return (pegs[2].DiscCount() == nDisc);
        }

        // Imprime el indicador de la clavija de origen "Src peg (1,2,3, q):"
        // en la posición <Map.SrcLeft, Map.SrcTop>
        public void SrcPegPrompt()
        {
            Console.SetCursorPosition(Map.SrcLeft, Map.SrcTop);
            Console.Write("Disco a mover (1,2,3,) q= salir: ");


        }
        // Imprime el mensaje de la clavija de destino "Peg dst (1,2,3, q):"
        // en la posición <Map.DstLeft, Map.DstTop>
        public void DstPegPrompt()
        {
            Console.SetCursorPosition(Map.DstLeft, Map.DstTop);
            Console.Write("\nA que torre quieres moverlo?(1,2,3,) q= salir:");

        }
    }
}
