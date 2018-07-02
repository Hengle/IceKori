using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    public class Exit : BaseStatement
    {

        public Exit()
        {
            Reducible = false;
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            throw new NotImplementedException();
        }
    }
}
