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

        }

        public GlobalDefine(string name, BaseExpression value)
        {
            Name = name;
            Value = value;
        }

        public override BaseStatement Reduce(Enviroment env)
        {
            if (Value.Reducible) return new GlobalDefine(Name, Value.Reduce(env));
            if (env.GlobalVariables.ContainsKey(Name))
            {
                return new Throw(new TypeError($"Identifier \"{Name}\" has already been declared"));
            }
            env.GlobalVariables.Add(Name, Value);
            return new DoNothing();
        }
    }
}
