using VerticalGame.Engine;
using VerticalGame.States;
using System;
using Microsoft.Xna.Framework.Graphics;

using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using System.Xml;
using Engine2DPipelineExtension.Animation;

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
            trash();
            using (var game = new MainGame(WIDTH, HEIGHT, new SplashState()))
            {
                game.IsFixedTimeStep = true;
                game.TargetElapsedTime = TimeSpan.FromMilliseconds(1000.0f / 60);
                game.Run();
            }
        }

        private static void trash()
        {
            AnimationData data = new AnimationData()
            {
                AnimationSpeed = 1,
                IsLooping = true,
                Frames = new System.Collections.Generic.List<AnimationFrameData>()
                {
                    new AnimationFrameData()
                    {
                        X = 1,
                        Y = 1,
                        CellWidth = 1,
                        CellHeight = 1
                    },
                    new AnimationFrameData()
                    {
                        X = 2,
                        Y = 2,
                        CellWidth = 2,
                        CellHeight = 2
                    }
                }
            };


            using(XmlWriter writer = XmlWriter.Create("animation.xml", new XmlWriterSettings(){Indent = true}))
            {
                IntermediateSerializer.Serialize(writer, data, null);
            }
        }
    }
}
