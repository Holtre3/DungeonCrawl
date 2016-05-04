using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonCrawl
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D eye;
        Vector2 eyePos;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            eyePos = new Vector2(0.0f, 0.0f);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            eye = Content.Load<Texture2D>("eye");
            
        }

        protected override void UnloadContent()
        {
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            KeyboardState keyboardState = Keyboard.GetState();
            float time = (float)gameTime.ElapsedGameTime.TotalSeconds;
            float speed = 100.0f;
            float moveAmount = time * speed;
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                eyePos.Y += moveAmount;
            }
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                eyePos.Y -= moveAmount;
            }
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                eyePos.X -= moveAmount;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                eyePos.X += moveAmount;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            spriteBatch.Draw(eye, eyePos, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
