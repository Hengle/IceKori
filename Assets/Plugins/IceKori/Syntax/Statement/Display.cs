using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
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
            BaseStatement statement;
            if (Body.Reducible)
            {
                var reduceValue = Body.Reduce(env);
                statement = reduceValue.GetType().IsSubclassOf(typeof(BaseError))
                    ? errorHandling.ThrowError((BaseError)reduceValue, env)
                    : new Display(reduceValue);
            }
            else
            {
                Debug.Log(Body);
                statement = new DoNothing();
            }
            return new object[] { statement, env, errorHandling };
        }
    }
}
