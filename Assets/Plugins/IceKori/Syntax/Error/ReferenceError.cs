using System;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Error
{
    public class ReferenceError : Error
    {
        public ReferenceError()
        {

        }

        public ReferenceError(string msg)
        {
            Msg = msg;
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            throw new NotImplementedException();
        }
    }
}
