using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace VerticalGame.Engine.Objects;

public class StatsObject : BaseTextObject
{
    public const int ROLLING_SIZE = 60;
    private Queue<float> _rollingFPS = new Queue<float>();

    public float FPS { get; set; }
    public float MinFPS { get; private set; }
    public float MaxFPS { get; private set; }
    public float AverageFPS { get; private set; }
    public bool IsRunningSlowly { get; set; }
    public int NbUpdateCalled { get; set; }
    public int NbDrawCalled { get; set; }


    public StatsObject(SpriteFont spriteFont)
    {
        _font = spriteFont;
        NbUpdateCalled = 0;
        NbDrawCalled = 0;
    }

    public void Update(GameTime gameTime)
    {
        NbUpdateCalled++;
        CalculateFPS(gameTime);
        Text = GetStatString();
    }

    private string GetStatString()
    {
        string output = "--STATS--";
        output += $"FPS: {FPS}\n";
        output += $"MIN FPS: {MinFPS}\n";
        output += $"MAX FPS: {MaxFPS}\n";
        output += $"Average FPS: {AverageFPS}\n";
        output += $"Is Running Slowly?: {IsRunningSlowly}\n";
        output += $"Update count: {NbUpdateCalled}\n";
        output += $"Draw count: {NbDrawCalled}";
        return output;
    }

    private void CalculateFPS(GameTime gameTime)
    {
        FPS = 1.0f / (float)gameTime.ElapsedGameTime.TotalSeconds;
        _rollingFPS.Enqueue(FPS);
        if (_rollingFPS.Count > ROLLING_SIZE)
        {
            _rollingFPS.Dequeue();
            var sum = 0f;
            MaxFPS = int.MinValue;
            MinFPS = int.MaxValue;

            foreach (var fps in _rollingFPS.ToArray())
            {
                sum += fps;
                if (fps > MaxFPS)
                {
                    MaxFPS = fps;
                }
                if (fps < MinFPS)
                {
                    MinFPS = fps;
                }
            }
            AverageFPS = sum / _rollingFPS.Count;
        }
        else
        {
            AverageFPS = FPS;
            MinFPS = FPS;
            MaxFPS = FPS;
        }
    }

    public override void Render(SpriteBatch spriteBatch)
    {
        NbDrawCalled++;
        base.Render(spriteBatch);
    }
}
