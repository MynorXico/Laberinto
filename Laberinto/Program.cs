using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoVs
{
    class Program
    {
        static void Main()
        {
            Random r = new Random();
            int[] arr = new int[200];
            for (int i = 0; i < arr.Length; i++) {
                arr[i] = (r).Next(200);
            }
            List<int> RandomEnemies = new List<int>();
            for(int i = 0; i < 15; i++)
            {
                int pos = r.Next(arr.Length);
                while (RandomEnemies.Contains(arr[pos]))
                {
                    pos = r.Next(arr.Length);
                }
                RandomEnemies.Add(arr[pos]);
            }


            Console.CursorVisible = true; //Mostrar cursor estara en "falso" lo que hara que no
            IInterfaceUsuario usuario = new InterfaceDeUsuario();
            
            IBucleJuego buclejuego = new BucleJuego();
            //IJuego juego = new Juego(15, 35, '@', 6); //Cambiando valores se incrementa el tamaño del mapa x,y
           

            usuario.ComenzarJuego(buclejuego);
        }
    }
}
