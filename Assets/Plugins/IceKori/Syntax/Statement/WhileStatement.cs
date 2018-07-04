using Assets.Plugins.IceKori.Syntax.Expression;
using System.Collections.Generic;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class WhileStatement : BaseStatement
    {
        public BaseExpression Condition;
        public List<BaseStatement> Body = new List<BaseStatement>();

        public WhileStatement()
        {
            Reducible = true;
        }

        public WhileStatement(BaseExpression condition, List<BaseStatement> body)
        {
            Reducible = true;
            Condition = condition;
            Body = body;
        }

        public override string ToString()
        {
            var str = $"while({Condition}){{\n";
            foreach (var baseStatement in Body)
            {
                str += $"{baseStatement}\n";
            }
            return str + "}";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            var statement = _IsError(Condition, () => new WhileStatement(Condition.Reduce(env), Body), () =>
            {
                Body.Add(this);
                return new IfStatement(
                    Condition,
                    Body,
                    new List<BaseStatement>
                    {
                        new EvalCallback((enviroment, handling) => enviroment.VariablesStack.Pop())
                    }
                );
            });

            return new object[] { statement, env, errorHandling };
        }
    }
}
