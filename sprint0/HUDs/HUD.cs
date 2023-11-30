﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//using sprint0.AnimatedSpriteFactory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata;
//using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static sprint0.HUDs.Inventory;


namespace sprint0.HUDs
{
    public class HUD
    {

        

        static Texture2D hudBackground;
        static Texture2D heart, miniMap, linkLocator, gem, itemA, itemB, triforce,link, xp,xpMonitor;
        SpriteBatch spriteBatch;
        SpriteFont font;
        private const int perImage = 3;
        private const float fontSize = 1.5f;
        private const int inititalState = 0;
      
        private int linkLevelX = 380;
        private int linkLevelY = 125;
        private int xpX = 410 ;
        private int xpY = 125;

        //Vars to change hud position - need for inventory screen
        public int HudXOffset { get; set; }
        public int HudYOffset { get; set; }

        //CHANGE HUD CONSTRUCTOR SO IT DOESN"T HAVE TO PASS IN TH TEXTURE@D (Probably Level loader?)
        public HUD(SpriteBatch spriteBatch, SpriteFont font, Texture2D hudspriteSheet, Texture2D Hearttexture, Texture2D minimap, Texture2D linklocator)
        {
           
            this.spriteBatch = spriteBatch;
            this.font = font;
            hudBackground = hudspriteSheet;
            miniMap = minimap;
            linkLocator = linklocator;
            heart = Hearttexture;
            HudXOffset = 0;
            HudYOffset = 0;
        }


        private void BackgroundDisplay()
        {
            {
                hudBackground = Inventory.hudSpritSheet[Inventory.HUDSpriteSheet.BACKGROUNDSHEET];
                const float scaledWidth = 0.95f;
                const float scaledHeight = 0.7f;
                //int x = 0;
                //int y = 0;
                int x = 0 + HudXOffset;
                int y = 0 + HudYOffset;


                int width = (int)(hudBackground.Width * scaledWidth);
                int height = (int)(hudBackground.Height * scaledHeight);
                



                Rectangle destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(hudBackground, destinationRectangle, Color.White);


            }

        }
        

        private void HeartDisplay()
        {
            //Each heart is count of 2. If it's an odd number, that means it's an half heart
            heart = Inventory.hudSpritSheet[Inventory.HUDSpriteSheet.HEARTSHEET];
            int heartSpacing = 40;
            int j = 0;
           
            int heartChecker = 2;
            int heartNum = Inventory.items[Inventory.ItemTypes.HEART]; //up to max 10
            int heartWidth = heart.Width / perImage;
            int heartHeight = heart.Height;
            Rectangle fullHeartsheet = new Rectangle(inititalState, inititalState, heartWidth, heartHeight); // first full Heart
            Rectangle halfHeartsheet = new Rectangle(heartWidth, inititalState, heartWidth, heartHeight);
           

            for (int i = 1; i <= heartNum; i++) //Loops the amount of hearts from enum HEART in the inventory
            {
               
                if (i == heartNum && i % heartChecker != 0) { //checks if i is at the last heart and if the last heart is odd

                    //if odd draw a half heart
                    spriteBatch.Draw(heart, new Vector2(590 + j + HudXOffset, 90 + HudYOffset), halfHeartsheet, Color.White);
                    j += heartSpacing; 
                }
                else if (i % heartChecker == 0) //if the the last heart is even, or if not the last heart, draw a full heart
                {
                    spriteBatch.Draw(heart, new Vector2(590 + j + HudXOffset, 90 +HudYOffset), fullHeartsheet, Color.White);
                    j += heartSpacing; //I still have to look into why there has to be two j +=heartSpacing.
                }

               

            }

        }


        //Rupee
        private void RupeeDisplay()
        {
            int rupeeCount = Inventory.items[Inventory.ItemTypes.RUPEE];
            int rupeeX = 340 + HudXOffset;
            int rupeeY = 35 + HudYOffset;
            
            //draw rupee number            
            spriteBatch.DrawString(font, rupeeCount.ToString(), new Vector2(rupeeX, rupeeY), Color.White, inititalState, Vector2.Zero, fontSize, SpriteEffects.None, inititalState);

        }
        //Key display
        protected void KeyDisplay()
        {
            int keyCount = Inventory.items[Inventory.ItemTypes.KEY];
            int keyX = 340 + HudXOffset;
            int keyY = 75 + HudYOffset;
            spriteBatch.DrawString(font, keyCount.ToString(), new Vector2(keyX, keyY), Color.White, inititalState, Vector2.Zero, fontSize, SpriteEffects.None, inititalState);
        }

        protected void BombDisplay()
        {
            int bombCount = Inventory.items[Inventory.ItemTypes.BOMB];
            int bombX = 340 + HudXOffset;
            int bombY = 110 + HudYOffset;

            spriteBatch.DrawString(font, bombCount.ToString(), new Vector2(bombX, bombY), Color.White, inititalState, Vector2.Zero, fontSize, SpriteEffects.None, inititalState);
        }

        //slot A item
        public void SlotADisplay()
        {
            itemA = Inventory.LocateCurrentAItemSheet();
            //get currentA item if not null
            if (Inventory.slotA != Globals.ItemsInSlots.EMPTY && itemA != null) {
                float scaledWidth = 2f;
                float scaledHeight = 2f;
                int x = 500;
                int y = 60;

                int width = (int)(itemA.Width * scaledWidth);
                int height = (int)(itemA.Height * scaledHeight);


                Rectangle destinationRectangle = new Rectangle(x+HudXOffset, y+HudYOffset, width, height);
                spriteBatch.Draw(itemA, destinationRectangle, Color.White);

            }

        }
        //slot B item
        public void SlotBDisplay()
        {

            itemB = Inventory.LocateCurrentBItemSheet();
            //get current B item if not null
            if (Inventory.slotB != Globals.ItemsInSlots.EMPTY && itemB !=null) {

                float scaledWidth = 2f;
                float scaledHeight = 2f;
                int x = 415;
                int y = 65;

                int width = (int)(itemB.Width * scaledWidth);
                int height = (int)(itemB.Height * scaledHeight);




                Rectangle destinationRectangle = new Rectangle(x+HudXOffset, y+HudYOffset, width, height);
                spriteBatch.Draw(itemB, destinationRectangle, Color.White);
            }
        }
        //miniMap
        private void MiniMapDisplay()
        {
            miniMap = Inventory.hudSpritSheet[Inventory.HUDSpriteSheet.MINIMAPSHEET];

            int miniMapInitalX = 30;
            int miniMapInitalY = 40;

            if (Inventory.PageResult())
            {
               
                float scaledWidth = 1f;
                float scaledHeight = 1f;
              

                int width = (int)(miniMap.Width * scaledWidth);
                int height = (int)(miniMap.Height * scaledHeight);
            
            int x = miniMapInitalX + HudXOffset;
            int y = miniMapInitalY + HudYOffset;




                Rectangle destinationRectangle = new Rectangle(x+HudXOffset, y+HudYOffset, width, height);
                spriteBatch.Draw(miniMap, destinationRectangle, Color.White);
            }

        }

        //Will change the logic. Just wanted to display
        private void LinkLocatorDisplay()
        {
            linkLocator = Inventory.hudSpritSheet[Inventory.HUDSpriteSheet.LINKLOCATORSHEET];
            if (Inventory.CompassResult())
            {
                float scaledWidth = 0.55f;
                float scaledHeight = 0.40f;
                int x = 40;
                int y = 90;

                int width = (int)(linkLocator.Width * scaledWidth);
                int height = (int)(linkLocator.Height * scaledHeight);


                Rectangle destinationRectangle = new Rectangle(x, y, width, height);
                spriteBatch.Draw(linkLocator, destinationRectangle, Color.White);
            }

        }

        //triforce
        private void TriforceDisplay()
        {
            triforce = Inventory.hudSpritSheet[HUDSpriteSheet.TRIFORCESHEET];
           

            if (Inventory.CompassResult())
            {
                float scaledWidth = .25f;
                float scaledHeight = .25f;
                int x = 234;
                int y = 72;

                int width = (int)(triforce.Width * scaledWidth);
                int height = (int)(triforce.Height * scaledHeight);




                Rectangle destinationRectangle = new Rectangle(x+HudXOffset, y+HudYOffset, width, height);
                spriteBatch.Draw(triforce, destinationRectangle, Color.White);
            }

        }



        private void LevelDisplay()
        {

            string level = "1";
            float scalingFont = 2;
            Vector2 levelFontPosition = new Vector2(210, 15 + HudYOffset);
         
            spriteBatch.DrawString(font, level, levelFontPosition, Color.White, inititalState, Vector2.Zero, scalingFont, SpriteEffects.None, inititalState);
        }

        //xp calculation
        // if Link attacks, gain xp (200)
        private void XPLinkLevel() {

            
            link = Inventory.hudSpritSheet[Inventory.HUDSpriteSheet.LINKLEVELSHEET];
                 
            int linkWidth = link.Width;
            int linkHeight = link.Height / perImage;
            int currentRow = inititalState;
            int secondColumn = 2;
            Vector2 vectorPositionLinkLevel = new Vector2(linkLevelX + HudXOffset, linkLevelY +HudYOffset);          
            Rectangle linkLevel = new Rectangle(inititalState, currentRow, linkWidth, linkHeight); //default is low link
            
          
           if (Inventory.CurrentTunic == Globals.LinkTunic.ICE) { currentRow = linkHeight; }
           else if (Inventory.CurrentTunic == Globals.LinkTunic.FIRE) { currentRow = linkHeight * secondColumn; }

            linkLevel = new Rectangle(0, currentRow, linkWidth, linkHeight);
           
            spriteBatch.Draw(link, vectorPositionLinkLevel, linkLevel, Color.White);

            
        
        }

        private void XPMonitorDisplay()
        {
            const int xpSpacing = 17;
            const int xpMonitorEdge = 119;
            const float perXPFrame = .375f;
            const int maxLoop = 8;
            int i = inititalState;
            int j = inititalState;
           
            float xpNum = Inventory.currentXP[Inventory.XPEnum.XP];
            xpMonitor = Inventory.hudSpritSheet[Inventory.HUDSpriteSheet.XPMONITORSHEET];
            xp = Inventory.hudSpritSheet[Inventory.HUDSpriteSheet.XPSHEET];
            Vector2 vectorPositionxp = new Vector2(xpX + HudXOffset, xpY + HudYOffset);

            spriteBatch.Draw(xp, vectorPositionxp, Color.White);
            
            
         
            while (i < maxLoop) {



                
                spriteBatch.Draw(xpMonitor, new Vector2((xpX + j) + HudXOffset, xpY +HudYOffset), Color.White);
                


                j += xpSpacing;
                xpNum -= perXPFrame;


                if (xpNum == 0 || (xpNum <= inititalState && xpNum > -perXPFrame)) { break; } //stop draw when xpNum is 0 or negative number less than -.375
                else if (xpNum <= -perXPFrame) {
                    xpNum = -xpNum; // make it positive               
                }

                else if (xpNum > inititalState && j > xpMonitorEdge) {

                    i = inititalState;
                    j = inititalState; // start back from 0
                    spriteBatch.Draw(xp, vectorPositionxp, Color.White);

                }
                if (i == maxLoop - 1) {

                    if (j > xpMonitorEdge || xpNum > inititalState) { i = inititalState; }
                } 

               

                i++;

            }



        }

            //Display all (called in Game1)
            public void Draw()
        {

            BackgroundDisplay();
            XPLinkLevel();
            XPMonitorDisplay();
            MiniMapDisplay();
            TriforceDisplay();
            LinkLocatorDisplay();
            HeartDisplay();
            RupeeDisplay();
            KeyDisplay();
            BombDisplay();
            LevelDisplay();
            SlotADisplay(); 
            SlotBDisplay(); 
            
           


        }



        public int ReturnHUDHeight() { return hudBackground.Height; }
    }

}
