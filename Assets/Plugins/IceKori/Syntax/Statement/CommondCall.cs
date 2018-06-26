using System;
using System.Collections.Generic;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class CommandCall : BaseStatement
    {
        public string Name;

        public CommandCall()
        {

        }

        public CommandCall(string name)
        {
            Name = name;
        }

        public override BaseStatement Reduce(Enviroment env)
        {
            return new SequenceStatment(env.Commands[Name]);

        }
    }
}
