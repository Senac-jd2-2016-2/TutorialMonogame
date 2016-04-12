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
            this.content = content;
        }

        public void addGameObject(GameObject obj){
            objetos.Add(obj);
            obj.start();
            obj.texture = content.Load<Texture2D>(obj.image);
        }

        private Rectangle getRectangle(GameObject gameObject){

            double width = gameObject.texture.Width;
            double newWidth = width * camera.zoom;
            double height = gameObject.texture.Height;
            double newHeigth = height * camera.zoom;
            double x = (gameObject.position.X + camera.foco.X) - (newWidth - width) / 2;
            double y = (gameObject.position.Y + camera.foco.Y) - (newHeigth - height) / 2;

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
