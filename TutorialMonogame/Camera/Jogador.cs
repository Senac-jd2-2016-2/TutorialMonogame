using Tutorial.Framework;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutorial
{
    public class Jogador : GameObject
    {
        public override void start()
        {
            image = "nave.png";
        }

        public override void update(GameTime gameTime)
        {
            Keys[] keys = Keyboard.GetState().GetPressedKeys();
            foreach (Keys k in keys)
            {
                if (k.Equals(Keys.Up))
                {
                    position.Y -= 2;
                }
                if (k.Equals(Keys.Down))
                {
                    position.Y += 2;
                }
                if (k.Equals(Keys.Right))
                {
                    position.X += 2;
                }
                if (k.Equals(Keys.Left))
                {
                    position.X -= 2;
                }
            }
        }
    }
}
