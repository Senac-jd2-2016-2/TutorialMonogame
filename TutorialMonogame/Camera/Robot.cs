using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tutorial.Framework;

namespace Tutorial
{
    class Robot : GameObject
    {
        public override void colisaoDetectada(GameObject obj)
        {
            texture = content.Load<Texture2D>("robot_colidido.png");
        }

        public override void colisaoNaoDetectada()
        {
            texture = content.Load<Texture2D>("robot.png");
        }

    }
}
