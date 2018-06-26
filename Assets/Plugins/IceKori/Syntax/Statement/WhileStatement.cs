using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class WhileStatement : BaseStatement
    {
        public BinaryExpression Condition;
        public List<BaseStatement> Body = new List<BaseStatement>();

        public WhileStatement()
        {

        }

        public WhileStatement(BinaryExpression condition, List<BaseStatement> body)
        {
            Condition = condition;
            Body = body;
        }

        public override BaseStatement Reduce(Enviroment env)
        {
            if (Condition.Reducible)
            {
                var expression = Condition.Reduce(env);
                if (expression.GetType().IsSubclassOf(typeof(Error.Error)))
                {
                    return new Throw((Error.Error)expression);
                }
                return new WhileStatement((BinaryExpression)expression, Body);
            }
            else
            {
                return new SequenceStatment(new List<BaseStatement>(Body) { this });
            }
        }
    }
}
