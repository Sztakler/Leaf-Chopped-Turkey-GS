using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Leaf
{
    public abstract class State
    {
        #region Fields

        protected ContentManager _contentManager;
        protected GraphicsDevice _graphicsDevice;
        protected LeafGame _game;

        #endregion

        #region Constructors
        
        public State(LeafGame game, GraphicsDevice graphicsDevice, ContentManager contentManager)
        {
            _game = game;
            _graphicsDevice = graphicsDevice;
            _contentManager = contentManager;
        }

        #endregion

        #region Methods

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public abstract void PostUpdate(GameTime gameTime);
        public abstract void Update(GameTime gameTime);

        #endregion
    }
}