using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Leaf
{
    public class MenuState : State
    {
        private List<Component> _components;
        
        public MenuState(LeafGame game, GraphicsDevice graphicsDevice, ContentManager contentManager) : base(game, graphicsDevice, contentManager)
        {
            Texture2D texture = _contentManager.Load<Texture2D>("controls/button");
            SpriteFont font = _contentManager.Load<SpriteFont>("fonts/menu");
            Button newGameButton = new Button(texture, font)
            {
                Position = new Vector2(300, 200),
                Text = "New Game",
            };
            newGameButton.Click += newGameButton_Click;

            Button loadButton = new Button(texture, font)
            {
                Position = new Vector2(300, 300),
                Text = "Load",
            };
            loadButton.Click += loadButton_Click;

            Button quitButton = new Button(texture, font)
            {
                Position = new Vector2(300, 400),
                Text = "Quit",
            };
            quitButton.Click += quitButton_Click;

            _components = new List<Component>()
            {
                newGameButton,
                loadButton,
                quitButton,
            };
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Loading...");
        }

        private void newGameButton_Click(object sender, EventArgs e)
        {
            _game.ChangeState(new GameState(_game, _graphicsDevice, _contentManager));
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach(Component component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
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
            // Remove unnecessary sprites
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override void Update(GameTime gameTime)
        {
            foreach(Component component in _components)
            {
                component.Update(gameTime);
            }
        }
    }
}