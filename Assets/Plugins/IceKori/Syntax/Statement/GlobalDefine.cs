using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class GlobalDefine : BaseStatement
    {
        public string Name;
        public BaseExpression Value;

        public GlobalDefine()
        {
            Reducible = true;
        }

        public GlobalDefine(string name, BaseExpression value)
        {
            Reducible = true;
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"${Name} = {Value}";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            if (Value.Reducible) return new object[]{ new GlobalDefine(Name, Value.Reduce(env)), env, errorHandling };
            if (env.GlobalVariables.ContainsKey(Name))
            {
                return new object[]{ new Throw(new TypeError($"Identifier \"{Name}\" has already been declared")), env, errorHandling };
            }
            env.GlobalVariables.Add(Name, (IceKoriBaseType)Value);
            return new object[] { new DoNothing(), env, errorHandling };
        }
    }
}
