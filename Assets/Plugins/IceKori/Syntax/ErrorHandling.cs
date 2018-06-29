using Assets.Plugins.IceKori.Syntax.Statement;
using System.Collections.Generic;
using Assets.Plugins.IceKori.Syntax.Error;

namespace Assets.Plugins.IceKori.Syntax
{
    public class ErrorHandling
    {
        public Stack<TryCatch> TryCatchStack;
        public TryCatch TryCatch => TryCatchStack.Peek();

        public ErrorHandling()
        {
            TryCatchStack = new Stack<TryCatch>();
        }

        public BaseStatement ThrowError(BaseError error)
        {
            if (TryCatch.Catch != ErrorType.All && error.Name != TryCatch.Catch.ToString())
            {
                return new DoNothing();
            }
            TryCatch.Rescue.Insert(0, new Define("$!", error));
            return new Sequence(TryCatch.Rescue);
        }
    }
}
