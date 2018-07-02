using System;
using System.Collections.Generic;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class VariableUpdate : BaseStatement
    {
        public string Name;
        public BaseExpression Value;

        public VariableUpdate()
        {
            Reducible = true;
        }

        public VariableUpdate(string name, BaseExpression value)
        {
            Reducible = true;
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Name} = {Value}";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            if (Value.Reducible) return new object[] { new VariableUpdate(Name, Value.Reduce(env)), env, errorHandling };
            if (!env.Variables.ContainsKey(Name)) return new object[]
            {
                new Throw(new TypeError($"Identifier \"{Name}\" does not defined")),
                env,
                errorHandling
            };
            env.Variables[Name] = (IceKoriBaseType)Value;
            return new object[] { new DoNothing(), env, errorHandling };
        }
    }
}
