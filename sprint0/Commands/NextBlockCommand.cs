﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;
using sprint0.Blocks;
namespace sprint0.Commands
{
    public class NextBlockCommand : ICommand
    {
        Sprint0 Game;
        IBlock Bl;

        public NextBlockCommand(Sprint0 game, IBlock block)
        {
            this.Game = game;
            this.Bl = block;
        }

        public void execute()
        {
            Bl.NextBlock();
        }
   }
}
