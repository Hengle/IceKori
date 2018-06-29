using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class Define : BaseStatement
    {
        public string Name;
        public BaseExpression Value;

        public Define()
        {
            Reducible = true;
        }

        public Define(string name, BaseExpression value)
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
            if (Value.Reducible) return new object[] {new Define(Name, Value.Reduce(env)), env, errorHandling};
            if (env.Variables.ContainsKey(Name)) return new object[]
            {
                new Throw(new TypeError($"Identifier \"{Name}\" has already been declared")),
                env,
                errorHandling
            };
            env.Variables.Add(Name, (IceKoriBaseType)Value);
            return new object[] { new DoNothing(), env, errorHandling };
        }
    }
}
