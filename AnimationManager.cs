using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Leaf
{
    public class AnimationManager
    {
        private Animation _animation;
        private float _timer;
        private SpriteEffects _spriteEffects;
        public SpriteEffects SpriteEffects { get => _spriteEffects; set => _spriteEffects = value; }
        public Vector2 position { get; set; }

        public AnimationManager(Animation animation)
        {
            _animation = animation;
            SpriteEffects = SpriteEffects.None;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                _animation.Texture,
                position,
                new Rectangle(_animation.CurrentFrame * _animation.FrameWidth, _animation.CurrentRow * _animation.FrameHeight, _animation.FrameWidth, _animation.FrameHeight),
                Color.White,
                0.0f,
                new Vector2(0, 0),
                2.0f,
                SpriteEffects,
                1.0f);
        }

        public void Play(Animation animation)
        {
            if (_animation == animation)
                return;

            _animation = animation;
            _animation.CurrentFrame = 0;
            _timer = 0;
        }

        public void Stop()
        {
            _timer = 0f;
            _animation.CurrentFrame = 0;
        }

        public void Update(GameTime gameTime, SpriteEffects spriteEffects)
        {   
            SpriteEffects = spriteEffects;
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer > _animation.FrameSpeed)
            {
                _timer = 0f;
                _animation.CurrentFrame++;

                if (_animation.CurrentFrame >= _animation.FrameCount)
                {
                    _animation.CurrentFrame = 0;
                }
            }
        }
    }
}