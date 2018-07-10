using Assets.Plugins.IceKori.Syntax.Expression;
using System;

namespace Assets.Plugins.IceKori.Syntax.BaseType
{
    public abstract class IceKoriBaseType : BaseExpression
    {
        public static int Null = 0;
        public static int Bool = 1;
        public static int Int = 2;
        public static int Float = 3;
        public static int String = 4;
        public static int Object = 5;

        public abstract object Unbox();

        public override BaseExpression Reduce(Enviroment env)
        {
            throw new Exception(ToString());
        }
    }
}
