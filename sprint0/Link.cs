﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sprint0
{
    using global::sprint0.Factory;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using System;
    using System.Collections.Generic;

    namespace sprint0
    {
        public class Link
        {
            SpriteFactory LinkSpriteFactory;
            private int HealthVal { get; set; }

            private int XVal { get; set; }
            private int YVal { get; set; }

            private enum Direction { Left, Right, Up, Down };
            Direction LinkDirection = Direction.Down;

            SpriteBatch SpriteBatch;


            /*Edited to have a texture, row, and column input for the purpose of drawing*/
            public Link(SpriteBatch spriteBatch)
            {
                /*This number is arbitrary*/
                HealthVal = 10;
                LinkSpriteFactory = new LinkFactory();
                SpriteBatch = spriteBatch;
            }

            public void LinkAttack()
            {
                /*This may need altered to fit sprite animation length*/
                LinkSpriteFactory.attack();

                LinkSpriteFactory.walk();
            }

            public void LinkUseItem()
            {
                /*This may need altered to fit sprite animation length*/
                LinkSpriteFactory.useItem();
                LinkSpriteFactory.walk();
            }


            /*The directions just change what position he is in, we have these defined already.*/
            public void LinkUp()
            {

                if (LinkDirection != Direction.Up)
                {
                    LinkSpriteFactory.changeDirection("up");
                }
                YVal++;
                LinkSpriteFactory.Draw(SpriteBatch, XVal, YVal);
            }

            public void LinkDown()
            {
                if (LinkDirection != Direction.Down)
                {
                    LinkSpriteFactory.changeDirection("down");
                }
                YVal--;
                LinkSpriteFactory.Draw(SpriteBatch, XVal, YVal);
            }

            public void LinkRight()
            {
                if (LinkDirection != Direction.Right)
                {
                    LinkSpriteFactory.changeDirection("right");
                }
                XVal++;
                LinkSpriteFactory.Draw(SpriteBatch, XVal, YVal);
            }

            public void LinkLeft()
            {
                if (LinkDirection != Direction.Left)
                {
                    LinkSpriteFactory.changeDirection("left");
                }
                XVal--;
                LinkSpriteFactory.Draw(SpriteBatch, XVal, YVal);
            }

            public void LinkGetDamage()
            {
                HealthVal--;
                /*Will need to add a way to make link invulnerable */
            }

            public void Update()
            {
                LinkSpriteFactory.Update();
            }

            public int GetXVal()
            {
                return XVal;
            }
            public int GetYVal()
            {
                return YVal;
            }
            public int GetHealth()
            {
                return HealthVal;
            }
            public String GetDirection()
            {
                String direction = "";
                switch(LinkDirection)
                {
                    case Direction.Left:
                        direction = "left";
                        break;
                    case Direction.Right:
                        direction = "right";
                        break;
                    case Direction.Up:
                        direction = "up";
                        break;
                    case Direction.Down:
                        direction = "down";
                        break;
                }
                return direction;
            }
        }
    }
}
