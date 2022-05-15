using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Leaf
{
    public class Sprite
    {
        #region Fields

        protected Texture2D _texture;
        protected AnimationManager _animationManager;
        protected Dictionary<string, Animation> _animations;
        protected Vector2 _position;

        #endregion

        #region Properties 

        public Input input;
        public Vector2 position
        {
            get { return _position; }
            set
            {
                _position = value;

                if (_animationManager != null)
                    _animationManager.position = _position;
            }

        }
        public float speed = 2.5f;
        public Vector2 velocity;

        protected float linearVelocity = 3f;
        protected float rotationVelocity = 4f;
        protected float _rotationAngle = 0f;

        #endregion

        #region Constructors

        public Sprite(Dictionary<string, Animation> animations)
        {
            _animations = animations;
            _animationManager = new AnimationManager(_animations.First().Value);
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;
        }

        #endregion

        #region Methods

        public int getFrameWidth()
        {
            return this._animations.First().Value.FrameWidth;
        }

        public int getFrameHeight()
        {
            return this._animations.First().Value.FrameHeight;
        }


        public virtual void Draw(SpriteBatch spriteBatch)
        {

            // var origin = new Vector2(_texture.Width / 2, _texture.Height / 2);
            // spriteBatch.Draw(_texture, position, null, Color.White, _rotationAngle, origin, 1.0f, SpriteEffects.None, 1.0f);

            if (_texture != null)
            {
                spriteBatch.Draw(_texture, position, Color.White);
            }
            else if (_animationManager != null)
            {
                _animationManager.Draw(spriteBatch);
            }
            else
            {
                throw new System.Exception("Couldn't draw sprite (no texture or animationManager).");
            }
        }

        protected virtual void Move()
        {
            if (Keyboard.GetState().IsKeyDown(input.Up))
            {
                velocity.Y -= speed;
            }

            if (Keyboard.GetState().IsKeyDown(input.Down))
            {
                velocity.Y += speed;
            }
            if (Keyboard.GetState().IsKeyDown(input.Left))
            {
                velocity.X -= speed;
            }
            if (Keyboard.GetState().IsKeyDown(input.Right))
            {
                velocity.X += speed;
            }
        }

        protected void SetAnimations()
        {
            if (velocity.X < 0)
            {
                _animationManager.Play(_animations["run_left"]);
            }
            else if (velocity.X > 0)
            {
                _animationManager.Play(_animations["run_right"]);
            }
            else if (velocity.X > 0)
            {
                _animationManager.Play(_animations["run_left"]);
            }
            else if (velocity.X > 0)
            {
                _animationManager.Play(_animations["run_left"]);
            }
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Move();

            // if (Keyboard.GetState().IsKeyDown(input.Left))
            //     _rotationAngle -= MathHelper.ToRadians(rotationVelocity);
            // else if (Keyboard.GetState().IsKeyDown(input.Right))
            //     _rotationAngle += MathHelper.ToRadians(rotationVelocity);
            
            // var direction = new Vector2((float)System.Math.Cos(MathHelper.PiOver2 - _rotationAngle), -(float)System.Math.Sin(MathHelper.PiOver2 - _rotationAngle));

            // if (Keyboard.GetState().IsKeyDown(input.Up))
            //     position += direction * linearVelocity;
            // else if (Keyboard.GetState().IsKeyDown(input.Down))
            //     position -= direction * linearVelocity;

                SetAnimations();

                _animationManager.Update(gameTime);

                position += velocity;
            velocity = Vector2.Zero;
        }

        #endregion

    }
}