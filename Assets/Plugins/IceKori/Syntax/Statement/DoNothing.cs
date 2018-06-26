using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    class DoNothing : BaseStatement
    {
        public new bool Reducible = false;

        public override BaseStatement Reduce(Enviroment env)
        {
            throw new NotImplementedException();
        }
    }
}
