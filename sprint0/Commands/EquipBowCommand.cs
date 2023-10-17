﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;
using sprint0.Items;

namespace sprint0.Commands
{
    public class EquipBowCommand : ICommand
    {
        Sprint0 Game;
        IItemSystem Item;

        public EquipBowCommand(Sprint0 game, IItemSystem item)
        {
            this.Game = game;
            this.Item = item;
            
        }

        public void execute()
        {
            Item.EquipBow();
          
        }
    }
}
