using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutorial.Framework
{
    public class Camera : GameObject
    {
        public double zoom = 1;

        public bool disableUpdate;

        public Vector2 getFoco()
        {
            return new Vector2(position.X + center.X, position.Y + center.Y);
        }

        public override void update(GameTime gameTime)
        {
            float deltaMov = 100;
            float deltaZoom = 1; 
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (!disableUpdate)
            {
                Keys[] keys = Keyboard.GetState().GetPressedKeys();
                foreach (Keys k in keys)
                {
                    if (k.Equals(Keys.I))
                    {
                        position.Y -= deltaMov * deltaTime;
                    }
                    if (k.Equals(Keys.O))
                    {
                        position.Y += deltaMov * deltaTime;
                    }
                    if (k.Equals(Keys.K))
                    {
                        position.X += deltaMov * deltaTime;
                    }
                    if (k.Equals(Keys.L))
                    {
                        position.X -= deltaMov * deltaTime;
                    }
                    if (k.Equals(Keys.U))
                    {
                        zoom += deltaZoom * deltaTime;
                    }
                    if (k.Equals(Keys.J))
                    {
                        zoom -= deltaZoom * deltaTime;
                    }
                }
            }
        }
    }
}
