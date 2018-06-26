using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.BaseType
{
    public abstract class IceKoriBaseType : BaseExpression
    {
        public abstract object Unbox();

        public override BaseExpression Reduce(Enviroment env)
        {
            throw new NotImplementedException();
        }
    }
}
