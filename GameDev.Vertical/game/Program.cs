using VerticalGame.Engine;
using VerticalGame.States;
using System;

namespace VerticalGame
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        private const int WIDTH = 1280;
        private const int HEIGHT = 720;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new MainGame(WIDTH, HEIGHT, new SplashState()))
            {
                game.IsFixedTimeStep = true;
                game.TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0f / 60);
                game.Run();
            }
        }
    }
}
