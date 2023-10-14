﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sprint0;
using sprint0.Items.groundItems;

namespace sprint0.Commands
{
    public class NextItemCommand : ICommand
    {
        Sprint0 Game;
        IGroundItemSystem Weapon;

        public NextItemCommand(Sprint0 game, IGroundItemSystem weapon)
        {
            this.Game = game;
            this.Weapon = weapon;
        }

        public void execute()
        {
            Weapon.NextItem();
        }
    }
}