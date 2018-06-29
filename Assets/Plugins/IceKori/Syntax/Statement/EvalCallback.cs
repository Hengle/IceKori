using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    public class EvalCallback : BaseStatement
    {
        public Action<Enviroment, ErrorHandling> Func;

        public EvalCallback(Action<Enviroment, ErrorHandling> func)
        {
            Reducible = true;
            Func = func;
        }
        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            Func(env, errorHandling);
            return new object[]{ new DoNothing(), env, errorHandling };
        }
    }
}
