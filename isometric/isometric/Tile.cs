using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace isometric
{
    class Tile
    {
        public Texture2D sprite;
        public Vector2 coordinate;

        public Tile(Texture2D sprite, Vector2 coordinate)
        {
            this.sprite = sprite;
            this.coordinate = coordinate;
        }
    }
}
