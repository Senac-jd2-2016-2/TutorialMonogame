using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FinalBreath
{
    public class SpriteSheet
    {

        public Texture2D Texture;
        public Rectangle Rectangle;
        public int CurrentFrame;
        public int RefreshTime;
        public Point frameSize;
        public int sheetSize;

        public SpriteSheet( int frameSizeX, int frameSizeY, int size)
        {
            frameSize = new Point(frameSizeX, frameSizeY);
            sheetSize = size;
            RefreshTime = 0;
        }

        public void LoadContent(ContentManager Content, String dir)
        {
            Texture = Content.Load<Texture2D>(dir);
            Rectangle = new Rectangle(CurrentFrame * frameSize.X, 0, frameSize.X, frameSize.Y);
        }

        public void SetFrame(int frame)
        {
            Rectangle = new Rectangle(CurrentFrame * frameSize.X, frame, frameSize.X, frameSize.Y);
        }

        public void Update(GameTime gameTime)
        {
            RefreshTime += gameTime.ElapsedGameTime.Milliseconds;

            if (RefreshTime > 70)
            {
                RefreshTime = 0;
                CurrentFrame++;

                if (CurrentFrame >= sheetSize)
                    CurrentFrame = 0;
            }
        }
    }
}
