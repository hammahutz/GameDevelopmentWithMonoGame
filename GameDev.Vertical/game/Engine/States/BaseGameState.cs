using System;
using System.Collections.Generic;
using System.Linq;
using VerticalGame.Engine.Input;
using VerticalGame.Engine.Objects;
using VerticalGame.Engine.Sound;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Engine2DPipelineExtension.Animation;

namespace VerticalGame.Engine.States
{
    public abstract class BaseGameState
    {
        protected bool _debug = false;
        protected bool _indestructible = false;

        private ContentManager _contentManager;
        protected int _viewportHeight;
        protected int _viewportWidth;
        protected SoundManager _soundManager = new SoundManager();

        private readonly List<BaseGameObject> _gameObjects = new List<BaseGameObject>();

        protected InputManager InputManager {get; set;}

        public void Initialize(ContentManager contentManager, int viewportWidth, int viewportHeight)
        {
            _contentManager = contentManager;
            _viewportHeight = viewportHeight;
            _viewportWidth = viewportWidth;

            SetInputManager();
        }

        public abstract void LoadContent();
        public abstract void HandleInput(GameTime gameTime);
        public abstract void UpdateGameState(GameTime gameTime);

        public event EventHandler<BaseGameState> OnStateSwitched;
        public event EventHandler<BaseGameStateEvent> OnEventNotification;
        protected abstract void SetInputManager();

        public void UnloadContent()
        {
            _contentManager.Unload();
        }

        public void Update(GameTime gameTime) 
        {
            UpdateGameState(gameTime);
            _soundManager.PlaySoundtrack();
        }

        protected Texture2D LoadTexture(string textureName) => _contentManager.Load<Texture2D>(textureName);
        protected AnimationData LoadAnimation(string animationName) => _contentManager.Load<AnimationData>(animationName);

        protected SpriteFont LoadFont(string fontName) => _contentManager.Load<SpriteFont>(fontName);

        protected SoundEffect LoadSound(string soundName) => _contentManager.Load<SoundEffect>(soundName);

        protected void NotifyEvent(BaseGameStateEvent gameEvent)
        {
            OnEventNotification?.Invoke(this, gameEvent);

            foreach (var gameObject in _gameObjects)
            {
                if (gameObject != null)
                    gameObject.OnNotify(gameEvent);
            }

            _soundManager.OnNotify(gameEvent);
        }

        protected void SwitchState(BaseGameState gameState)
        {
            OnStateSwitched?.Invoke(this, gameState);
        }

        protected void AddGameObject(BaseGameObject gameObject)
        {
            _gameObjects.Add(gameObject);
        }

        protected void RemoveGameObject(BaseGameObject gameObject)
        {
            _gameObjects.Remove(gameObject);
        }

        public virtual void Render(SpriteBatch spriteBatch)
        {
            foreach (var gameObject in _gameObjects.Where(a => a != null).OrderBy(a => a.zIndex))
            {
                if (_debug)
                {
                    gameObject.RenderBoundingBoxes(spriteBatch);
                }

                gameObject.Render(spriteBatch);
            }
        }
    }
}