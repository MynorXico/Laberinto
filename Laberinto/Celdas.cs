using System;

namespace JuegoVs
{
    class Celdas : Punto
    {
      
        public bool[] Muro;

        public bool Actual;

        public Celdas(int x, int y) : base(' ', x, y)
        {
            Muro = new bool[] { true, true, true, true}; // Si borrase algun "true" el juego no correria conforme a la creacion de los muros, ya que cada true es verdadero la creacion de cada muro

            Actual = false;
        }

        public void Display(ConsoleColor bgColor)
        {
           
            if (Actual)
                Display(Console.ForegroundColor, bgColor);
            else
                Display(Console.ForegroundColor, Console.BackgroundColor);

            // se mostrara si son validados los muros respecto a las celdas
            DisplayWalls(bgColor);
        }

        void DisplayWalls(ConsoleColor bgColor)
        {
            Celdas c = null;

            for (int i = 0; i < Muro.Length; i++)
            {
                if (i == (int)Controles.Arriba)
                    c = new Celdas(X - 1, Y);
                else if (i == (int)Controles.Derecha)
                    c = new Celdas(X, Y + 1);
                else if (i == (int)Controles.Abajo)
                    c = new Celdas(X + 1, Y);
                else if (i == (int)Controles.Izquierda)
                    c = new Celdas(X, Y - 1);

               
                // si el muro se habilita entonces no se mostrara nada
                // si el muro se deshabiiitara se mostrara un celda normal
                if (Muro[i])
                    c.Display(Console.ForegroundColor, Console.BackgroundColor);
                else
                    c.Display(Console.ForegroundColor, bgColor);
            }
        }

        public void Highlight()
        {
            Display(ConsoleColor.White, ConsoleColor.White); //Color de linea altura
        }
    }
}