using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorresHanoi_ArqSoft
{
    class Input
    {
        // Lee una posición del usuario de la siguiente manera:
        // - las entradas válidas son 1, 2, 3 o q con valores de retorno 0, 1, 2 o -1, respectivamente.
        // - los caracteres escritos no se muestran en la pantalla hasta que el usuario escribe un carácter válido
        public int GetPosition()
        {
            while (true)
            {
                ConsoleKeyInfo keyInput = Console.ReadKey(true);

                switch (keyInput.Key)
                {
                    case ConsoleKey.NumPad1:
                    case ConsoleKey.D1:
                        Console.Write("1");
                        return 0;
                    case ConsoleKey.NumPad2:
                    case ConsoleKey.D2:
                        Console.Write("2");
                        return 1;
                    case ConsoleKey.NumPad3:
                    case ConsoleKey.D3:
                        Console.Write("3");
                        return 2;
                    case ConsoleKey.Q:
                        Console.Write("q");
                        return -1;
                }
            }
        }

        // Muestra mensage de bienvenida en consola
        // Lee el número de discos de la siguiente manera:
        // - Mensaje con "¿Cuántos discos (3 ... 5)?"
        // - La entrada válida está entre 3 y 5
        // - Debería ocuparse de la entrada inválida
        public int GetDiscCount()
        {
            int number = 0;

            while (true)
            {
                try
                {
                    Console.Write("\n│▒│ /▒/                                                                          ||\n");
                    Console.Write("│▒│/▒/       __^__                                             __^__            ▓||▓\n");
                    Console.Write("│▒ /▒/─┬─┐  ( ___ )-------------------------------------------( ___ )         ███||███\n");
                    Console.Write("│▒│▒|▒│▒│    |   |                                             |   |        ░░░░░||░░░░░\n");
                    Console.Write("┌┴─┴─┐-┘─┘   | / | Bienvenidos al juego de las torres de hanoi | / |      ▒▒▒▒▒▒▒||▒▒▒▒▒▒▒\n");
                    Console.Write("│▒┌──┘▒▒▒│   |___|                                             |___|    ▓▓▓▓▓▓▓▓▓||▓▓▓▓▓▓▓▓▓\n");
                    Console.Write("└┐▒▒▒▒┌┘    (_____)-------------------------------------------(_____) ███████████||███████████\n\n");
                    Console.Write("\t\t¿Cuantos discos quiere para jugar ?  (3...5): ");
                    number = Convert.ToInt32(Console.ReadLine());

                    if (number < 3 || number > 5)
                    {
                        throw new Exception();
                    }

                    return number;
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("\nNumero invalido \n");
                    Console.WriteLine(@" ¯\(°_o)/¯");
                    Console.WriteLine();
                    Console.WriteLine("Por favor ingrese un numero valido \n");

                }
            }
        }
    }
}
