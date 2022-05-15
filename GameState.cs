using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Leaf
{
    public class GameState : State
    {
        public GameState(LeafGame game, GraphicsDevice graphicsDevice, ContentManager contentManager) : base(game, graphicsDevice, contentManager)
        {

        }
        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void Update(GameTime gameTime)
        {
        }
    }
}