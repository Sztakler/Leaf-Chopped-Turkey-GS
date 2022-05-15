using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Leaf
{
    public class Button : Component
    {
        #region Fields

        private MouseState _currentMouseState;
        private MouseState _previousMouseState;
        private SpriteFont _font;
        private bool _isHovering;
        private Texture2D _texture;

        #endregion

        #region Properties

        public event EventHandler Click;
        public bool Clicked { get; private set; }
        public Color PenColor { get; set; }
        public Vector2 Position { get; set; }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }
        public string Text { get; set; }
    
        #endregion

        #region Constructors

        public Button(Texture2D texture, SpriteFont font)
        {
            _texture = texture;
            _font = font;

            PenColor = Color.Black;
        }

        #endregion

        #region Methods

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            var color = Color.BlanchedAlmond;

            if (_isHovering)
                color = Color.Wheat;

            spriteBatch.Draw(_texture, Rectangle, color);

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2) - (_font.MeasureString(Text).X) / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2) - (_font.MeasureString(Text).Y) / 2);
            
                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColor);
            }

        }

        public override void Update(GameTime gameTime)
        {
            _previousMouseState = _currentMouseState;
            _currentMouseState = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouseState.X, _currentMouseState.Y, 1, 1);

            _isHovering = mouseRectangle.Intersects(Rectangle);

            if (_isHovering && _currentMouseState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed)
            {
                Click?.Invoke(this, new EventArgs()); // If click event handler is not null, then use it.
            }
        }

         #endregion
    }
}