using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorresHanoi_ArqSoft
{
    class Program
    {
        static void Main(string[] args)
        {
            //titulo de la consola
            Console.Title = "TORRES DE HANOI por LOERA & ALEMAN";
            Input inp = new Input();

            // lee el número de discos del juego (3, 4 o 5)
            int nDisc = inp.GetDiscCount();
            // crea un juego deTORRES DE HANOI
            Game game = new Game(nDisc);

            // Dibuja el tablero de juego
            game.Draw();

            do
            {
                /// **** JUEGO MANUAL ***** 
                // Obtener trazas de origen y destino
                game.SrcPegPrompt();
                int src = inp.GetPosition();
                if (src < 0)
                    break;

                game.DstPegPrompt();

               int dst = inp.GetPosition();
                if (dst < 0)
                    break;

                // Intenta mover un disco de src a dst
                bool success = game.Move(src, dst);

                //Redibujar el tablero de juego
                game.Draw();

                if (!success)
                {
                    game.Message("＼（〇_ｏ）／ Movimiento invalido  " + (src + 1) + " -> " + (dst + 1));
                }
            } while (!game.Win());

            game.MessageWin(" ░▒▓█▓▒░   F  E  L  I  C  T  A  C  I  O  N  E  S  ░▒▓█▓▒░\n" +
                         "\t--------------------Usted ha Ganado------------------\n\n" +
                                     "\t─▄▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▄  \t─▄▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▄\n" +
                                     "\t█░░░█░░░░░░░░░░▄▄░██░█ \t█░░░█░░░░░░░░░░▄▄░██░█\n" +
                                     "\t█░▀▀█▀▀░▄▀░▄▀░░▀▀░▄▄░█ \t█░▀▀█▀▀░▄▀░▄▀░░▀▀░▄▄░█\n" +
                                     "\t█░░░▀░░░▄▄▄▄▄░░██░▀▀░█ \t█░░░▀░░░▄▄▄▄▄░░██░▀▀░█\n" +
                                     "\t─▀▄▄▄▄▄▀─────▀▄▄▄▄▄▄▀  \t─▀▄▄▄▄▄▀─────▀▄▄▄▄▄▄▀\n\n" +


                                  "Presione enter para salir");

            Console.ReadLine();
        }
    }
}
