using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace isometric
{
    class Camera
    {
        public Vector2 location = new Vector2(0,0);
        public double zoom = 1;

        public Camera() { }

    }
}
