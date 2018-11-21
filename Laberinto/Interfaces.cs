using System;

namespace JuegoVs
{

    // Menu e inicio del juego
    public interface IInterfaceUsuario
    {
        void ComenzarJuego(IBucleJuego buclejuego);
    }

    // progreso del juego
    public interface IBucleJuego
    {
        void correr(IJuego juego);
    }

    // Esto mostrara la interfaz de objetos del juego
    public interface IJuego
    {
        void Initialize();
        void DisplayField();
        void DisplayPlayer();
        void HandleKey(ConsoleKeyInfo cki);
        bool Hazganado();
    }
}