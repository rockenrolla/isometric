using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace isometric
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Dictionary<string, Texture2D> spriteSheet = new Dictionary<string, Texture2D>();
        Map map;
        Camera camera;

        const int WINDOW_WIDTH = 1024;
        const int WINDOW_HEIGHT = 768;

        int prevScroll = 0;

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            graphics.IsFullScreen = false;
            IsMouseVisible = true;
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            map = new Map(new Vector2(50, 50), spriteSheet, WINDOW_WIDTH, WINDOW_HEIGHT);

            camera = new Camera();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // adding sprites to sprite sheet
            spriteSheet.Add("grass", Content.Load<Texture2D>("grass2"));
            spriteSheet.Add("sand", Content.Load<Texture2D>("sand"));
            spriteSheet.Add("water", Content.Load<Texture2D>("water"));
            spriteSheet.Add("empty", Content.Load<Texture2D>("empty"));
            map.Generate("grass");

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            updateCamera();

            base.Update(gameTime);
        }

        public void updateCamera()
        {
            int scroll = Mouse.GetState().ScrollWheelValue;
            if (scroll-prevScroll > 0)
            {
                camera.zoom *= 1.1;
            }
            else if (scroll - prevScroll < 0)
            {
                camera.zoom = camera.zoom <= 1 ? 1 : camera.zoom * 0.9;
            }
            prevScroll = scroll;
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();

            map.Draw(spriteBatch, camera);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
