using System;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    public class Break : BaseStatement
    {

        public Break()
        {
            Reducible = false;
        }

        public override string ToString()
        {
            return $"break";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            throw new NotImplementedException();
        }
    }
}
