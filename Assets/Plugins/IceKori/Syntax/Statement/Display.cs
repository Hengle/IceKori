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
            Reducible = true;
        }

        public Display(BaseExpression body)
        {
            Reducible = true;
            Body = body;
        }

        public override string ToString()
        {
            return $"display({Body})";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            if (Body.Reducible)
            {
                return new object[]{ new Display(Body.Reduce(env)), env, errorHandling };
            }
            Debug.Log(Body);
            return new object[] { new DoNothing(), env, errorHandling };
        }
    }
}
