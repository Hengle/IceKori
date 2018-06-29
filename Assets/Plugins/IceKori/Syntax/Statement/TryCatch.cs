using System;
using System.Collections.Generic;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public enum ErrorType
    {
        All,
        TypeError,
        ReferenceError
    }

    [System.Serializable]
    public class TryCatch : BaseStatement
    {
        public List<BaseStatement> Body;
        public ErrorType Catch;
        public List<BaseStatement> Rescue;

        public TryCatch()
        {
            Reducible = true;
        }

        public TryCatch(List<BaseStatement> body, ErrorType catchType, List<BaseStatement> rescue)
        {
            Reducible = true;
            Body = body;
            Catch = catchType;
            Rescue = rescue;
        }

        public override string ToString()
        {
            var str = "try{\n";
            foreach (var baseStatement in Body)
            {
                str += $"{baseStatement}\n";
            }

            str += $"}} catch({Catch}) {{\n";
            foreach (var baseStatement in Rescue)
            {
                str += $"{baseStatement}\n";
            }
            return str + "}";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            errorHandling.TryCatchStack.Push(this);
            Body.Add(new EvalCallback((enviroment, handling) => handling.TryCatchStack.Pop()));
            return new object[]{ new Sequence(Body), env, errorHandling};
        }
    }
}
