using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Plugins.IceKori.Syntax.Expression;
using Assets.Plugins.IceKori.Syntax.Statement;

namespace Assets.Plugins.IceKori.Syntax
{
    public class Enviroment : Dictionary<string, BaseExpression>
    {
        public Dictionary<string, List<BaseStatement>> Commands;
        public Dictionary<string, BaseExpression> GlobalVariables;
        public Dictionary<string, List<BaseStatement>> GlobalCommands;
    }
}
