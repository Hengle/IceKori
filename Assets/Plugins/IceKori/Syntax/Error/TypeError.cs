﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Error
{
    public class TypeError : Error
    {
        public TypeError()
        {

        }

        public TypeError(string msg)
        {
            Msg = msg;
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            throw new NotImplementedException();
        }
    }
}
