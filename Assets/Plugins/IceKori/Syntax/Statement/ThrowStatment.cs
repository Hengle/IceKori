using System;
using Assets.Plugins.IceKori.Syntax.Error;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    public class Throw : BaseStatement
    {
        public Error.Error Error;

        public Throw()
        {
            Reducible = false;
        }

        public Throw(Error.Error error)
        {
            Reducible = false;
            Error = error;
        }

        public override BaseStatement Reduce(Enviroment env)
        {
            throw new NotImplementedException();
        }
    }
}
