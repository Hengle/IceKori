using System;
using System.Collections.Generic;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class GlobalVariableUpdate : BaseStatement
    {
        public string Name;
        public BaseExpression Value;

        public GlobalVariableUpdate()
        {
            Reducible = true;
        }

        public GlobalVariableUpdate(string name, BaseExpression value)
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
            if (Value.Reducible) return new object[] { new GlobalVariableUpdate(Name, Value.Reduce(env)), env, errorHandling };
            if (!env.GlobalVariables.ContainsKey(Name)) return new object[]
            {
                new Throw(new TypeError($"Global identifier \"{Name}\" does not defined")),
                env,
                errorHandling
            };
            env.Variables[Name] = (IceKoriBaseType)Value;
            return new object[] { new DoNothing(), env, errorHandling };
        }
    }
}
