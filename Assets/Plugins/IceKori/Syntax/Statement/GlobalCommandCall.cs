using System;
using System.Collections.Generic;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class GlobalCommandCall : BaseStatement
    {
        public string Name;

        public GlobalCommandCall()
        {

        }

        public GlobalCommandCall(string name)
        {
            Name = name;
        }

        public override BaseStatement Reduce(Enviroment env)
        {
            return new SequenceStatment(env.GlobalCommands[Name]);

        }
    }
}
