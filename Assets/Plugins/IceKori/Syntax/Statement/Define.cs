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

        }

        public Define(string name, BaseExpression value)
        {
            Name = name;
            Value = value;
        }

        public override BaseStatement Reduce(Enviroment env)
        {
            if (Value.Reducible) return new Define(Name, Value.Reduce(env));
            if (env.ContainsKey(Name)) return new Throw(new TypeError($"Identifier \"{Name}\" has already been declared"));
            env.Add(Name, Value);
            return new DoNothing();
        }
    }
}
