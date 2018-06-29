﻿using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Assets.Plugins.IceKori.Syntax.Expression;
using System.Collections.Generic;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class IfStatement : BaseStatement
    {
        public BaseExpression Condition;
        public List<BaseStatement> Consequence = new List<BaseStatement>();
        public List<BaseStatement> Alternative = new List<BaseStatement>();

        public IfStatement()
        {
            Reducible = true;
        }

        public IfStatement(BaseExpression condition, List<BaseStatement> consequence, List<BaseStatement> alternative)
        {
            Reducible = true;
            Condition = condition;
            Consequence = consequence;
            Alternative = alternative;
        }

        public override string ToString()
        {
            var str = $"if({Condition}){{\n";
            foreach (var baseStatement in Consequence)
            {
                str += $"{baseStatement}\n";
            }

            str += "} else {\n";
            foreach (var baseStatement in Alternative)
            {
                str += $"{baseStatement}\n";
            }
            return str + "}";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {

            if (Condition.Reducible) return new object[]{ new IfStatement(Condition.Reduce(env), Consequence, Alternative), env, errorHandling};
            if (Condition.GetType() == typeof(IceKoriBool))
            {
                var context = (bool)((IceKoriBool)Condition).Unbox() ? Consequence : Alternative;
                if (context.Count == 0)
                {
                    return new object[]{ new DoNothing(), env, errorHandling};
                }
                env.VariablesStack.Push(new Dictionary<string, IceKoriBaseType>());
                context.Add(new EvalCallback((enviroment, handling) => enviroment.VariablesStack.Pop()));
                return new object[]{ new Sequence(context), env, errorHandling };
            }

            var error = Condition.GetType().IsSubclassOf(typeof(Error.BaseError)) ? (Error.BaseError)Condition : new TypeError($"Condition \"{Condition}\" not boolean");
            return new object[]{ new Throw(error) , env, errorHandling};
        }
    }
}