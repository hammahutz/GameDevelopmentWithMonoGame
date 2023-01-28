using VerticalGame.Engine.Objects;
using Microsoft.Xna.Framework.Graphics;

namespace VerticalGame.Objects.Text
{
    public class GameOverText : BaseTextObject
    {
        public GameOverText(SpriteFont font)
        {
            _font = font;
            Text = "Game Over";
        }
    }
}
