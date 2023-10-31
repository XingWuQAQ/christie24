﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using sprint0.AnimatedSpriteFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0.Blocks
{
    internal class StairBlock : IBlock
    {

        
        int scaledWidth;
        int scaledHeight;
        int RoomId;
        ISprite blockSprite;
        IBlock iblock;
        SpriteFactory blockSpriteFactory;
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int XValue { get; set; }
        private int YValue { get; set; }




        public StairBlock(int x, int y, int roomId, SpriteFactory spriteFactory)
        {
            blockSprite = spriteFactory.getAnimatedSprite("StairBlock");
            blockSpriteFactory = spriteFactory;
            XValue = x; YValue = y;
            iblock = this;
            RoomId = roomId;
        }
        public StairBlock(Texture2D texture, int rows, int columns)
        {
            this.Texture = texture;
            Rows = rows;
            Columns = columns;

        }

       /* public void Draw(SpriteBatch spriteBatch, int x, int y)
        {

            int width = this.Texture.Width / Columns;
            int height = this.Texture.Height / Rows;
            int blockRow = 1;
            int blockColumn = 3;

            Rectangle sourceLocation = new Rectangle(width * blockColumn, height * blockRow, width, height);

            //resize block image
            double scale = 0.2; //40% of the orignal size image
            scaledWidth = (int)(width * scale);
            scaledHeight = (int)(height * scale);


            Rectangle destinationRectangle = new Rectangle(x, y, scaledWidth, scaledHeight);


            spriteBatch.Draw(this.Texture, destinationRectangle, sourceLocation, Color.White);

        }*/
        public void Draw(SpriteBatch spriteBatch)
        {
            blockSprite.Draw(spriteBatch, XValue, YValue);
        }

        public void Explode() { }
        public void Update() { }

        //hard code for now (make new class for these?)
        public int xPosition() { return XValue; } // returns X pos of object
        public int yPosition() { return YValue; } // returns Y pos of object
        public int width() { return blockSprite.GetWidth(); } // (i.e.) "how big are you?"
        public int height() { return blockSprite.GetHeight(); } // (i.e.) "how big are you?"
        public bool isDynamic() { return false; } // does this object move? 
        public bool isUpdateable() { return true; }
        public bool isInPlay() { return true; }
        public bool isDrawable() { return true; }
        public void SetRoomId(int roomId) { RoomId = roomId; }
        public int GetRoomId() { return RoomId; }
        
    }
}
