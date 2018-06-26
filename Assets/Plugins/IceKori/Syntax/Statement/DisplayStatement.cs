using Assets.Plugins.IceKori.Syntax.BaseType;
using UnityEngine;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class DisplayStatement : BaseStatement
    {
        public BaseExpression Body;

        public DisplayStatement()
        {
        }

        public DisplayStatement(BaseExpression body)
        {
            Body = body;
        }

        public override BaseStatement Reduce(Enviroment env)
        {
            if (Body.Reducible)
            {
                return new DisplayStatement(Body.Reduce(env));
            }
            Debug.Log(((IceKoriBaseType)Body).Unbox());
            return new DoNothing();
        }
    }
}
