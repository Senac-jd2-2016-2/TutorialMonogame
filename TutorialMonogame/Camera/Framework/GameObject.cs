using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutorial.Framework
{

    public class GameObject {

        public Vector2 position;

        public Vector2 center = new Vector2(0, 0);

        public Texture2D texture;

        public Vector2 transform;

        public String image;

        private Camera camera;

        public virtual void start()
        {

        }

        public void setCamera(Camera camera)
        {
            this.camera = camera;
            this.camera.disableUpdate = true;
        }

        public virtual void update(GameTime gameTime)
        {
            if(camera != null)
            {
                camera.update(gameTime);
            }
        }

    }
}
