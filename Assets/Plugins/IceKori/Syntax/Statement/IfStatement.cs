using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Expression;
using System.Collections.Generic;
using Assets.Plugins.IceKori.Syntax.Error;
using Sirenix.OdinInspector;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class IfStatement : BaseStatement
    {

        public IfStatement()
        {
        }

        public IfStatement(BaseExpression condition, List<BaseStatement> consequence, List<BaseStatement> alternative)
        {
            Condition = condition;
            Consequence = consequence;
            Alternative = alternative;
        }

        public BaseExpression Condition;
        public List<BaseStatement> Consequence = new List<BaseStatement>();
        public List<BaseStatement> Alternative = new List<BaseStatement>();

        public override BaseStatement Reduce(Enviroment env)
        {
            if (Condition.Reducible) return new IfStatement(Condition.Reduce(env), Consequence, Alternative);
            if (Condition.GetType() == typeof(IceKoriBool))
            {
                var context = (bool)((IceKoriBool)Condition).Unbox() ? Consequence : Alternative;
                if (context.Count == 0)
                {
                    return new DoNothing();
                }
                return new SequenceStatment(context);
            }
            return new Throw(new TypeError($"Condition \"{Condition}\" not bool"));
        }
    }
}