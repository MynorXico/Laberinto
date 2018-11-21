using System;

namespace JuegoVs
{
    class Juego : IJuego
    {
        //Datos que usaremos publicos para que todo tenga acesso
        public int Altura { get; }
        public int Ancho { get; }
        public char JugadorS { get; }
        public int Genvelocidad { get; }
        public int NEnemigos { get; }
        public string Nombre { get; }
        Laberinto laberinto;
        Jugador jugador;

        Celdas Comienzo { get; }
        public static Celdas Final;

        public Juego(int alto, int ancho, char jugadors, int genvelocidad, int nEnemigos, string nombre)
        {
            Altura = alto;
            Ancho = ancho;
            JugadorS = jugadors;
            Genvelocidad = genvelocidad;
            NEnemigos = nEnemigos;
            Nombre = nombre;
            Initialize();

            Comienzo = new Celdas(1, 1);
            Final = new Celdas(Altura - 2, Ancho - 2);
        }

        public void Initialize()
        {
            
            laberinto = new Laberinto(Altura, Ancho, ConsoleColor.Black, ConsoleColor.DarkGray); //Color del laberinto
            jugador = new Jugador(JugadorS, laberinto.Muros, laberinto.Celdas, Nombre);
        }

       

        // Mostrara en tiempo como se genera un metodo
        public void DisplayField()
        {
            laberinto.Generate(Genvelocidad);

            Comienzo.Display(ConsoleColor.Red, ConsoleColor.Red); //Color de la salida
            Final.Display(ConsoleColor.Yellow, ConsoleColor.Yellow);// Color de la meta
        }

       
        // pantalla del jugador
        public void DisplayPlayer()
        {
            jugador.Display(ConsoleColor.White, ConsoleColor.White); //Color de jugador
        }

        // Movimiento de jugador
        public void HandleKey(ConsoleKeyInfo cki)
        {
            jugador.Erase(laberinto.FieldColor, laberinto.FieldColor);
            jugador.HandleKey(cki);
        }

       
        // El juego acabara cuando el jugador llega a la casilla marcada
        public bool Hazganado()
        {
            
            return jugador.IsCollidingWith(Final);
            
        }
    }
}
