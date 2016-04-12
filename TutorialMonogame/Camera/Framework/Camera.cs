using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutorial.Framework
{
    public class Camera
    {
        public double zoom = 1;

        public Vector2 foco = new Vector2(0, 0);

        public bool disableUpdate;

        public virtual void update(GameTime gameTime)
        {
            float deltaMov = 40;
            float deltaZoom = 1; 
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (!disableUpdate)
            {
                Keys[] keys = Keyboard.GetState().GetPressedKeys();
                foreach (Keys k in keys)
                {
                    if (k.Equals(Keys.I))
                    {
                        foco.Y -= deltaMov * deltaTime;
                    }
                    if (k.Equals(Keys.O))
                    {
                        foco.Y += deltaMov * deltaTime;
                    }
                    if (k.Equals(Keys.K))
                    {
                        foco.X += deltaMov * deltaTime;
                    }
                    if (k.Equals(Keys.L))
                    {
                        foco.X -= deltaMov * deltaTime;
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
