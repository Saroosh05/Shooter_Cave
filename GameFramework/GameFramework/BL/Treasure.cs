﻿using Movement;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public class Treasure : GameObject
    {
        public Treasure(Image img, int X, int Y, IMovement Controller, GameObjectType objectType) : base(img, X, Y, Controller, objectType)
        {
        }
    }
}
