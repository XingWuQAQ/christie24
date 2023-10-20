﻿using System;
namespace sprint0.Items.groundItems
{
    using System;
    namespace sprint0.Items.groundItems
    {
        using System;
        using Microsoft.Xna.Framework.Graphics;

        namespace sprint0.Items.groundItems
        {
            public class GroundCompass : IGroundItem
            {
                public SpriteBatch itemSpriteBatch;
                private IGroundSprite itemSprite;
                public int xPos;
                public int yPos;

                // Does Level Loader like this signature?
                public GroundCompass(SpriteBatch incomingSpriteBatch, Texture2D incomingSpriteSheet, int xPos, int yPos)
                {
                    this.itemSpriteBatch = incomingSpriteBatch;
                    this.itemSprite = new GroundNonAnimatedSprite(incomingSpriteSheet, 1, 1);
                }

                public void Draw()
                {
                    this.itemSprite.Draw(this.itemSpriteBatch, this.xPos, this.yPos);
                }

                public int height()
                {
                    return this.itemSprite.itemHeight();
                }

                public bool isDynamic()
                {
                    return false;
                }

                public void Update()
                {

                }

                public int width()
                {
                    return this.itemSprite.itemWidth();
                }

                public int xPosition()
                {
                    return this.xPos;
                }

                public int yPosition()
                {
                    return this.yPos;
                }
            }
        }


    }


}

