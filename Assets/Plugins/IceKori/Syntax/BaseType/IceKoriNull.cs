using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Plugins.IceKori.Syntax.BaseType
{
    public class IceKoriNull : IceKoriBaseType
    {
        public IceKoriNull()
        {
            Reducible = false;
        }

        public override object Unbox()
        {
            return null;
        }
    }
}
