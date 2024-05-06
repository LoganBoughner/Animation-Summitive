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
        Texture2D caught;
        Rectangle caughtRect;
        Texture2D hook;
        Rectangle hookRect;
        Texture2D water;

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
            caughtRect = new Rectangle (0,0,100,100);
            hookRect = new Rectangle(700,290,50,50);
           
            screen = Screen.Intro;
            //Speed
            fishSpeed = new Vector2 (1,0);
            if (fishRect.X == hookRect.X)
                fishSpeed = new Vector2(0,0);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            fish = Content.Load<Texture2D>("Fish");          
            caught = Content.Load<Texture2D>("Caught");
            hook = Content.Load<Texture2D>("Hook");
            water = Content.Load<Texture2D>("Water");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            fishRect.X += (int) fishSpeed.X; 
            fishRect.Y += (int)fishSpeed.Y;
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(); 
            _spriteBatch.Draw(fish, fishRect, Color.White);
            _spriteBatch.Draw(hook, hookRect, Color.White);
            if (screen ==  Screen.End)
            _spriteBatch.Draw(caught, caughtRect, Color.White);
            if (screen == Screen.Water)
            _spriteBatch.Draw(water, new Rectangle(0,0,800,500), Color.White);
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
