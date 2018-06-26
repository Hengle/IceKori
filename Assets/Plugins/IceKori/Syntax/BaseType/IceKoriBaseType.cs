using Assets.Plugins.IceKori.Syntax.Expression;
using System;

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
