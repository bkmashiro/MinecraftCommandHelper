﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftCommandHelper
{
    class Selectors
    {
        enum SelectorType
        {
            p,
            r,
            a,
            s,
            e,
        }

        string[] selectors = new string[] {"p","r","a","s","e" };

        SelectorType Type = SelectorType.p;

        public string GetSeletor()
        {
            return string.Empty;
        }

    }
}
