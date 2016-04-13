using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tutorial.Framework
{
    public class Cenario
    {
        private ContentManager content;

        private GameObject fundo = new GameObject();

        public List<GameObject> objetos = new List<GameObject>();

        public Camera camera = new Camera();

        public Cenario(ContentManager content, String fundo){
            this.fundo.texture = content.Load<Texture2D>(fundo);
            this.fundo.center.X = this.fundo.texture.Width / 2;
            this.fundo.center.Y = this.fundo.texture.Height / 2;
            this.content = content;
        }

        public void addGameObject(GameObject obj){
            objetos.Add(obj);
            obj.start();
            obj.texture = content.Load<Texture2D>(obj.image);
        }

        private Rectangle getRectangle(GameObject gameObject)
        {
            

            double width = gameObject.texture.Width;
            double newWidth = width * camera.zoom;
            double height = gameObject.texture.Height;
            double newHeigth = height * camera.zoom;

            double x, y;
            if (gameObject != fundo)
            {
                double widthFundo = fundo.texture.Width;
                double heightFundo = fundo.texture.Height;
                double widthFundoZoom = fundo.texture.Width * camera.zoom;
                double heightFundoZoom = fundo.texture.Height * camera.zoom;
                double deltaX = (widthFundoZoom - widthFundo) / 2;
                double deltaY = (heightFundoZoom - heightFundo) / 2;


                x = (gameObject.position.X - gameObject.center.X) * camera.zoom - deltaX + camera.position.X;

                y = (gameObject.position.Y + gameObject.center.Y) * camera.zoom - deltaY - camera.position.Y;
                y = fundo.texture.Height - y;
            }
            else
            {
                x = (gameObject.position.X + camera.position.X) - (newWidth - width) / 2;
                y = (gameObject.position.Y + camera.position.Y) - (newHeigth - height) / 2;
            }


            return new Rectangle(
                (int)x,
                (int)y,
                (int)newWidth,
                (int)newHeigth);
        }

        public void update(GameTime gameTime){
            camera.update(gameTime);
            foreach(GameObject obj in objetos)
            {
                obj.update(gameTime);
            }
        }

        public void draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(fundo.texture, getRectangle(fundo), Color.White);
            foreach (GameObject obj in objetos)
            {
                spriteBatch.Draw(obj.texture, getRectangle(obj), Color.White);
            }
        }
    }
}
