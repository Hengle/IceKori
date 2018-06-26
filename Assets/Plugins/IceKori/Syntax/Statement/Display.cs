using Assets.Plugins.IceKori.Syntax.BaseType;
using UnityEngine;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class Display : BaseStatement
    {
        public BaseExpression Body;

        public Display()
        {
        }

        public Display(BaseExpression body)
        {
            Body = body;
        }

        public override BaseStatement Reduce(Enviroment env)
        {
            if (Body.Reducible)
            {
                return new Display(Body.Reduce(env));
            }
            Debug.Log(((IceKoriBaseType)Body).Unbox());
            return new DoNothing();
        }
    }
}
