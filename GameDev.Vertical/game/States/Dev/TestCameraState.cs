
using Microsoft.Xna.Framework;
using MonoGame.Extended;
using MonoGame.Extended.ViewportAdapters;
using VerticalGame.Engine.States;
using VerticalGame.Objects;

namespace VerticalGame.States;

public class TestCameraState : BaseGameState
{
    private const string PlayerFighter = "Sprites/Animations/FighterSpriteSheet";
    private const string PlayerAnimationTurnLeft = "Sprites/Animations/turn-left";
    private const string PlayerAnimationTurnRight = "Sprites/Animations/turn-right";

    private PlayerSprite _playerSprite;
    private OrthographicCamera _camera;
    public override void HandleInput(GameTime gameTime)
    {
    }

    public override void LoadContent()
    {
        var viewPortAdapter = new DefaultViewportAdapter(_graphicsDevice);
        _camera = new OrthographicCamera(viewPortAdapter);
        _playerSprite = new PlayerSprite(LoadTexture(PlayerFighter), LoadAnimation(PlayerAnimationTurnLeft), LoadAnimation(PlayerAnimationTurnRight))
        {
            Position = Vector2.Zero
        };
    }


    public override void UpdateGameState(GameTime gameTime)
    {
    }

    protected override void SetInputManager()
    {
    }
}