using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace isometric
{
    class Map
    {
        private List<Tile> tiles;
        private Vector2 size;
        private Dictionary<string, Texture2D> spriteSheet;
        private int windowWidth, windowHeight;

        public Map(Vector2 size, Dictionary<string, Texture2D> spriteSheet,
            int windowWidth, int windowHeight)
        {
            this.size = size;
            this.spriteSheet = spriteSheet;
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
            tiles = new List<Tile>();
        }

        public void Generate(string spriteName)
        {
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    Texture2D sprite;
                    spriteSheet.TryGetValue(spriteName, out sprite);
                    tiles.Add(new Tile(sprite, new Vector2(i, j)));
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, Camera camera)
        {
            foreach (Tile tile in tiles)
            {
                int width = (int) (((float) windowWidth / size.X) * camera.zoom);
                int height = (int) (width/Math.Sqrt(3));
                int x = windowWidth / 2 + (int) tile.coordinate.X * width / 2 - (int) tile.coordinate.Y * width / 2 - width / 2;
                int y = (int)(tile.coordinate.X + tile.coordinate.Y) * height / 2;
                Rectangle drawRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(tile.sprite, drawRectangle, Color.White);
            }
        }
    }
}