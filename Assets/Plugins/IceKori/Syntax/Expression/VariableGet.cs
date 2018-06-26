using Assets.Plugins.IceKori.Syntax.Error;

namespace Assets.Plugins.IceKori.Syntax.Expression
{
    [System.Serializable]
    public class VariableGet : BaseExpression
    {
        public string Name;

        public VariableGet()
        {

        }

        public VariableGet(string name)
        {
            Name = name;
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            if(!env.ContainsKey(Name)) return new ReferenceError($"{Name} is not defined");
            return env[Name];
        }
    }
}
