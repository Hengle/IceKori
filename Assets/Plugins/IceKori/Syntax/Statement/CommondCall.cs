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
            Reducible = true;
        }

        public CommandCall(string name)
        {
            Reducible = true;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name}.call()";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            return new object[]{ new Sequence(env.Commands[Name]), env, errorHandling };

        }
    }
}
