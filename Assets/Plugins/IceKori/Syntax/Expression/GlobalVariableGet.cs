using Assets.Plugins.IceKori.Syntax.Error;

namespace Assets.Plugins.IceKori.Syntax.Expression
{
    [System.Serializable]
    public class GlobalVariableGet : BaseExpression
    {
        public string Name;

        public GlobalVariableGet()
        {

        }

        public GlobalVariableGet(string name)
        {
            Name = name;
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            if (!env.ContainsKey(Name)) return new ReferenceError($"Global variable {Name} is not defined");
            return env[Name];
        }
    }
}
