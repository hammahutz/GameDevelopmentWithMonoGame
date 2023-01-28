using VerticalGame.Engine.Input;
using VerticalGame.Engine.States;
using VerticalGame.Input;
using VerticalGame.Objects;
using Microsoft.Xna.Framework;

namespace VerticalGame.States
{
    public class SplashState : BaseGameState
    {
        public override void LoadContent()
        {
            AddGameObject(new SplashImage(LoadTexture("Images/splash")));
        }

        public override void HandleInput(Microsoft.Xna.Framework.GameTime gameTime)
        {
            InputManager.GetCommands(cmd =>
            {
                if (cmd is SplashInputCommand.GameSelect)
                {
                    SwitchState(new GameplayState());
                }
            });
        }

        public override void UpdateGameState(GameTime _) { }

        protected override void SetInputManager()
        {
            InputManager = new InputManager(new SplashInputMapper());
        }
    }
}