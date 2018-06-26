using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public abstract class BaseStatement : BaseNode
    {
        protected BaseStatement()
        {
            Reducible = true;
        }
        public abstract BaseStatement Reduce(Enviroment env);
    }
}
