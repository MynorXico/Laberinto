using System;
using System.Diagnostics;
using System.Threading;

namespace JuegoVs
{
    //Clase Bucle de juego
    class BucleJuego : IBucleJuego
    {
        Stopwatch stopwatch;
        public static bool conVida=true;
        public void correr(IJuego juego)
        {
            stopwatch = new Stopwatch();

            // Mostrar el diseño del juego
            juego.DisplayField();

            // empezar contador
            stopwatch.Start();

            do
            {
                if (Console.KeyAvailable == true)
                {
                    juego.HandleKey(Console.ReadKey(true));
                    juego.DisplayPlayer();
                }
            } while (!juego.Hazganado() && conVida);

            

            // Mostrara un mensaje luego de un tiempo de haber llegado a la meta
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.SetCursorPosition(10, 15);
            if (conVida)
                Console.WriteLine("OBJETIVO ENCONTRADO :D");
            else
                Console.WriteLine("GAME OVER :(");
            Console.SetCursorPosition(10, 16);
            Console.WriteLine("Presione cualquier tecla:");
            

            ConsoleKeyInfo cki = Console.ReadKey(true);
            Console.Clear();
           


            if (cki.Key != ConsoleKey.Escape)
            {
                IInterfaceUsuario usuario = new InterfaceDeUsuario();
                IBucleJuego buclejuego = new BucleJuego();
                usuario.ComenzarJuego(buclejuego);
            }
            
        }
    }
}