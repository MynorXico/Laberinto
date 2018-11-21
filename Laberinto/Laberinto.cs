using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace JuegoVs
{
    class Laberinto
    {
        // parametros a usar
        public int Alto { get; } 
        public int Ancho { get; }

        // Celdas que permiten el movimiento del jugador
        public List<Celdas> Celdas { get; }
       
        //muros de la forma actual del laberinto
        public List<Celdas> Muros { get; }

        // Empezara la generacio de celdas
        Celdas currentCell;

    
        // stack para el algoritmo 
        Stack<Celdas> stack = new Stack<Celdas>();

        // Colores
        public ConsoleColor FieldColor { get; }
        public ConsoleColor ColorMuros { get; }

        public Laberinto(int alto, int ancho, ConsoleColor fieldColor, ConsoleColor Colormuros)
        {
            Celdas = new List<Celdas>();
            Muros = new List<Celdas>();


            //ajustes del tamaño del parametro
            Alto = alto % 2 == 0 ? alto - 1 : alto;
            Ancho = ancho % 2 == 0 ? ancho - 1 : ancho;

            // Agregar celdas por medio de un ciclo
            for (int i = 1; i < Alto; i += 2)
            {
                for (int j = 1; j < Ancho; j += 2)
                {
                    Celdas.Add(new Celdas(i, j));
                }
            }

            // Agregar paredes o muros
            for (int i = 0; i < Alto; i++)
            {
                for (int j = 0; j < Ancho; j++)
                {
                    Muros.Add(new Celdas(i, j));
                }
            }

            // Agregar color a los muros
            FieldColor = fieldColor;
            ColorMuros = Colormuros;

            
            //Siempre que inicie se generara una primer celda (1,1)
            currentCell = Celdas.First();
        }

        
        //Genera mediante el proceso
        public void Generate(int latency)
        {
            do
            {
            
                //siempre se marcara la celda en la que se fija
                currentCell.Actual = true;

               
                //se genera aleatoriemante una celda con la siguiente
                Celdas nextCell = Linea(currentCell);

           
                if (nextCell != null)
                    RemoveWalls(currentCell, nextCell);

           
                //removor el muro si es igual a la celda frente
                foreach (Celdas muro in Muros)
                {
                    if (muro.X == currentCell.X && muro.Y == currentCell.Y)
                    {
                        Muros.Remove(muro);
                        break;
                    }
                }

                currentCell.Display(FieldColor);


                //Si es habilitada la siguiente celda - al presionar la celda el stack asignara la que le sigue 
             
                // si no - se regresara hasta que la celda encuentre una posicion valible
                if (nextCell != null)
                {
                    stack.Push(currentCell);
                    currentCell = nextCell;
                }
                else if (stack.Count > 0)
                    currentCell = stack.Pop();

           
                //linea de la celda 
                currentCell.Display(ConsoleColor.White, ConsoleColor.White); //Color de creacion de laberinto

                Thread.Sleep(latency);

                
              
                //Algoritmo donde la celda regresara al comienzo
            } while (!completo());

   
            //Mostrara los muros
            foreach (Celdas c in Muros)
            {
                c.Display(ColorMuros, ColorMuros);
            }

            Random r = new Random();
            List<Celdas> RandomEnemies = new List<Celdas>();
            for (int i = 0; i < 15; i++)
            {
                int pos = r.Next(Celdas.Count);
                while (RandomEnemies.Contains(Celdas[pos]))
                {
                    pos = r.Next(Celdas.Count);
                }
                RandomEnemies.Add(Celdas[pos]);
                Celdas[pos].IsEnemy = true;
            }
            foreach(Celdas c in RandomEnemies)
            {
                c.Display(ConsoleColor.Green, ConsoleColor.Green);
                c.IsEnemy = true;
            }

            int pos1 = r.Next(Celdas.Count);
            while (RandomEnemies.Contains(Celdas[pos1]))
            {
                pos1 = r.Next(Celdas.Count);
            }
            Juego.Final = Celdas[pos1];
        }

        void RemoveWalls(Celdas a, Celdas b)
        {

            //Asignara las coordenadas de los muros de frente a y b
            int x = (a.X != b.X) ? (a.X > b.X ? a.X - 1 : a.X + 1) : a.X;
            int y = (a.Y != b.Y) ? (a.Y > b.Y ? a.Y - 1 : a.Y + 1) : a.Y;

 
            //Remover muros o paredes
            foreach (Celdas wall in Muros)
            {
                if (wall.X == x && wall.Y == y)
                {
                    Muros.Remove(wall);
                    break;
                }
            }

 
            //Muestra un correspondiente de un muro con la celda
            if (a.X - b.X == 2)
            {
                a.Muro[(int)Controles.Arriba] = false;
                b.Muro[(int)Controles.Abajo] = false;
            }
            else if (a.X - b.X == -2)
            {
                a.Muro[(int)Controles.Abajo] = false;
                b.Muro[(int)Controles.Arriba] = false;
            }

            if (a.Y - b.Y == 2)
            {
                a.Muro[(int)Controles.Izquierda] = false;
                b.Muro[(int)Controles.Derecha] = false;
            }
            else if (a.Y - b.Y == -2)
            {
                a.Muro[(int)Controles.Derecha] = false;
                b.Muro[(int)Controles.Izquierda] = false;
            }
        }

        Celdas Linea(Celdas celda)
        {
            Random rand = new Random();

            List<Celdas> linea = new List<Celdas>();

         
            //Asiganra un lado valible de la celda
            Celdas arriba = (celda.X + 1 > 0) ? Celdas.Find(c => c.X == celda.X - 2 && c.Y == celda.Y) : null;
            Celdas derecha = (celda.Y + 2 < Ancho - 1) ? Celdas.Find(c => c.Y == celda.Y + 2 && c.X == celda.X) : null;
            Celdas abajo = (celda.X + 2 < Alto - 1) ? Celdas.Find(c => c.X == celda.X + 2 && c.Y == celda.Y) : null;
            Celdas izquierda = (celda.Y + 2 > 0) ? Celdas.Find(c => c.Y == celda.Y - 2 && c.X == celda.X) : null;

            if (arriba != null && !arriba.Actual)
            {
                linea.Add(arriba);
            }
            if (derecha != null && !derecha.Actual)
            {
                linea.Add(derecha);
            }
            if (abajo != null && !abajo.Actual)
            {
                linea.Add(abajo);
            }
            if (izquierda != null && !izquierda.Actual)
            {
                linea.Add(izquierda);
            }

          
            //Retornara aleatoriamente de la linea
            if (linea.Count > 0)
            {
                int index = rand.Next(linea.Count);
                return linea[index];
            }
            
            // si no regresa 
            return null;
        }

       
        //Si el stack esta vacio se cumplira la funcion del labyrith
        bool completo()
        {
            return stack.Count == 0;
        }
    }
}