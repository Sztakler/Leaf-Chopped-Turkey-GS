using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Leaf
{
    public class LeafGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont font;
        private int score;

        private List<Sprite> _sprites;
        private Sprite _player;

        private Color _backgroundColor = Color.AntiqueWhite;

        private Camera _camera;
        private List<Component> _gameComponents;

        private State _currentState;
        private State _nextState;
        public void ChangeState(State state)
        {
            _nextState = state;
        }

        public static int ScreenHeight;
        public static int ScreenWidth;

        public LeafGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            IsMouseVisible = true;
            
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _camera = new Camera();

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var animations = new Dictionary<string, Animation>()
            {
                {"idle", new Animation(Content.Load<Texture2D>("sprites/Owlet_Monster/Idle_4"), 4, 1, 0)},
                {"run", new Animation(Content.Load<Texture2D>("sprites/Owlet_Monster/Run_6"), 6, 1, 0)},
                {"attack1", new Animation(Content.Load<Texture2D>("sprites/Owlet_Monster/Attack1_4"), 4, 1, 0)},
                {"attack2", new Animation(Content.Load<Texture2D>("sprites/Owlet_Monster/Attack2_6"), 6, 1, 0)},
            };

            _sprites = new List<Sprite>()
            {
                new Sprite(animations)
                {
                    position = new Vector2(300, 300),
                    input = new Input()
                    {
                        Up = Keys.K,
                        Down = Keys.J,
                        Left = Keys.H,
                        Right = Keys.L
                    }
                },
                new Sprite(animations)
                {
                    position = new Vector2(200, 200),
                    input = new Input()
                    {
                        Up = Keys.Up,
                        Down = Keys.Down,
                        Left = Keys.Left,
                        Right = Keys.Right
                    }
                },
            };

            _player = new Sprite(animations)
                {
                    position = new Vector2(100, 100),
                    input = new Input()
                    {
                        Up = Keys.W,
                        Down = Keys.S,
                        Left = Keys.A,
                        Right = Keys.D
                    }
                };


            Button buttonChangeColor = new Button(Content.Load<Texture2D>("controls/button"), Content.Load<SpriteFont>("fonts/menu"))
            {
                Position = new Vector2(350, 200),
                Text = "Change color"
            };
            buttonChangeColor.Click += buttonChangeColor_Click;

            Button buttonQuit = new Button(Content.Load<Texture2D>("controls/button"), Content.Load<SpriteFont>("fonts/menu"))
            {
                Position = new Vector2(350, 250),
                Text = "Quit"
            };
            buttonQuit.Click += buttonQuit_Click;

            _gameComponents = new List<Component>()
            {
                buttonChangeColor,
                buttonQuit,
            };


            font = Content.Load<SpriteFont>("fonts/Menu");


            _currentState = new MenuState(this, _graphics.GraphicsDevice, Content);
        }

        private void buttonChangeColor_Click(object sender, System.EventArgs e)
        {
            var random = new Random();
            _backgroundColor = new Color(random.Next(0, 255), random.Next(0, 255), random.Next(0, 255));
        }

        private void buttonQuit_Click(object sender, System.EventArgs e)
        {
            Exit();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            // TODO: Add your update logic here
            score++;

            foreach (var sprite in _sprites)
            {
                sprite.Update(gameTime, _sprites);
            }

            _player.Update(gameTime, _sprites);

            // foreach (var component in _gameComponents)
            // {
            //     component.Update(gameTime);
            // }

            // _playerSprite.Update(gameTime, _sprites);

            if (_nextState != null)
            {
                _currentState = _nextState;
                _nextState = null;
            }

            _camera.Follow(_player);

            _currentState.Update(gameTime);
            _currentState.PostUpdate(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_backgroundColor);

            _spriteBatch.Begin(transformMatrix: _camera.Transform);

            // _spriteBatch.DrawString(font, "Menu", new Vector2(0, 0), Color.Black);
            // _spriteBatch.DrawString(font, "Score: " + score, new Vector2(680, 0), Color.Black);

            foreach (var sprite in _sprites)
            {
                sprite.Draw(_spriteBatch);
            }

            _player.Draw(_spriteBatch);

            // foreach (var component in _gameComponents)
            // {
            //     component.Draw(gameTime, _spriteBatch);
            // }


            _spriteBatch.End();

            _currentState.Draw(gameTime, _spriteBatch);

            // TODO: Add your drawing code here
            base.Draw(gameTime);
        }
    }
}
