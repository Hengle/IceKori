using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;
using Sirenix.OdinInspector;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class ForStatement : BaseStatement
    {
        public BaseExpression Count;
        public List<BaseStatement> Body = new List<BaseStatement>();
        [HideInEditorMode]
        public int Index;

        public ForStatement()
        {
            Reducible = true;
        }

        public ForStatement(BaseExpression count, List<BaseStatement> body)
        {
            Reducible = true;
            Count = count;
            Body = body;
        }

        public override string ToString()
        {
            var str = $"for({Count}){{\n";
            foreach (var baseStatement in Body)
            {
                str += $"{baseStatement}\n";
            }

            return str + "}";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            if (Count.Reducible)
            {
                BaseStatement statement;
                var reduceValue = Count.Reduce(env);
                if (reduceValue.GetType().IsSubclassOf(typeof(BaseError)))
                {
                    statement = new Throw((BaseError)reduceValue);
                }
                else
                {
                    statement = new ForStatement(reduceValue, Body);
                }
                return new object[]{ statement, env, errorHandling };
            }
            if(Index == 0) env.VariablesStack.Push(new Dictionary<string, IceKoriBaseType>());
            Index += 1;
            var condition = new BinaryExpression(BinaryOperator.LessEqual, new IceKoriInt(Index), Count);
            return new object[]{ new IfStatement(
                    condition, 
                    new List<BaseStatement>(Body) { this },
                    new List<BaseStatement>
                    {
                        new EvalCallback((enviroment, handling) => enviroment.VariablesStack.Pop())
                    }
                    ),
                env,
                errorHandling
            };
        }
    }
}
