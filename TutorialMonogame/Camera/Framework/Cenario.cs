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
            obj.content = content;
            obj.start();
            obj.texture = content.Load<Texture2D>(obj.image);
        }

        private bool verificarColisao(GameObject a, GameObject b)
        {
            Color[] bitsA = new Color[a.texture.Width * a.texture.Height];
            a.texture.GetData(bitsA);
            Color[] bitsB = new Color[b.texture.Width * b.texture.Height];
            b.texture.GetData(bitsB);

            int x1 = Math.Max(a.rectangle.X, b.rectangle.X);
            int x2 = Math.Min(a.rectangle.X + a.rectangle.Width, b.rectangle.X + b.rectangle.Width);

            int y1 = Math.Max(a.rectangle.Y, b.rectangle.Y);
            int y2 = Math.Min(a.rectangle.Y + a.rectangle.Height, b.rectangle.Y + b.rectangle.Height);

            for (int y = y1; y < y2; ++y)
            {
                for (int x = x1; x < x2; ++x)
                {
                    Color ca = bitsA[(x - a.rectangle.X) + (y - a.rectangle.Y) * a.rectangle.Width];
                    Color cb = bitsB[(x - b.rectangle.X) + (y - b.rectangle.Y) * b.rectangle.Width];

                    if (ca.A != 0 && cb.A != 0) 
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        private void detectarColisao()
        {
            foreach(GameObject o in objetos)
            {
                o.colidiu = false;
            }

            for(int i = 0; i < objetos.Count; i++)
            {
                GameObject obj1 = objetos[i];
                for(int j = i + 1; j < objetos.Count; j++)
                {
                    GameObject obj2 = objetos[j];
                    if(verificarColisao(obj1, obj2))
                    {
                        obj1.colidiu = true;
                        obj2.colidiu = true;
                        obj1.colisaoDetectada(obj2);
                        obj2.colisaoDetectada(obj1);
                    }
                }
                if (!obj1.colidiu)
                {
                    obj1.colisaoNaoDetectada();
                }
            }
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


            Rectangle rect = new Rectangle(
                (int)x,
                (int)y,
                (int)newWidth,
                (int)newHeigth);
            gameObject.rectangle = rect;
            return rect;
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
            detectarColisao();
        }
    }
}
