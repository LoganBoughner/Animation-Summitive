using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Animation_Summitive
{
    //Logan
    enum Screen
    {
        Intro,
        Water,
        End
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D fish;
        Rectangle fishRect;
        Vector2 fishSpeed;
        Texture2D hook;
        Rectangle hookRect;
        Vector2 hookSpeed;
        Texture2D water;
        Texture2D intro;
        Texture2D end;
        MouseState mouseState;
        SpriteFont titleFont;
        SpriteFont endFont;

        Screen screen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        { _graphics.PreferredBackBufferWidth = 800; 
            _graphics.PreferredBackBufferHeight = 500; 
            _graphics.ApplyChanges();
            // TODO: Add your initialization logic here
            //rectangles
            fishRect = new Rectangle (0,250,150,100);
            hookRect = new Rectangle(700,290,50,50);
            screen = Screen.Intro;
            //Speed
            fishSpeed = new Vector2 (1,0);

            


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            fish = Content.Load<Texture2D>("Fish");          
            hook = Content.Load<Texture2D>("Hook");
            water = Content.Load<Texture2D>("Water");
            intro = Content.Load<Texture2D>("Intro");
            end = Content.Load<Texture2D>("End");
            titleFont = Content.Load<SpriteFont>("Title");
            endFont = Content.Load<SpriteFont>("Ending");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.Water;

            }
            else if (screen == Screen.Water)
            {
                fishRect.X += (int)fishSpeed.X; 
                fishRect.Y += (int)fishSpeed.Y;

                hookRect.X += (int)hookSpeed.X;
                hookRect.Y += (int)hookSpeed.Y;

                if (fishRect.X == 575)
                {
                    fishSpeed = new Vector2(0, -3);
                    hookSpeed = new Vector2(0, -3);
                }
                if (fishRect.Y == 1) 
                    screen = Screen.End;
            }
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(); 
            
            if (screen == Screen.Intro)
                _spriteBatch.Draw(intro, new Rectangle(0, 0, 800, 500), Color.White);
            _spriteBatch.DrawString(titleFont, "Press LMB to start.", new Vector2(10, 10), Color.Blue);
            if (screen == Screen.End)
            {
                _spriteBatch.Draw(end, new Rectangle(0, 0, 800, 500), Color.White);
                _spriteBatch.DrawString(endFont, "The end thanks for watching!", new Vector2(10, 10), Color.Blue);
            }
            if (screen == Screen.Water)
            {
                _spriteBatch.Draw(water, new Rectangle(0, 0, 800, 500), Color.White);
                _spriteBatch.Draw(fish, fishRect, Color.White);
                _spriteBatch.Draw(hook, hookRect, Color.White);
            }
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
