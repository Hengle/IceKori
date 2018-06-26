using System;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.BaseType
{
    [System.Serializable]
    public class IceKoriInt : IceKoriBaseType
    {
        public int Value;

        public IceKoriInt()
        {
        }

        public IceKoriInt(int value)
        {
           Value = value;
        }

        public override object Unbox()
        {
            return Value;
        }

        public bool ToBool()
        {
            return Convert.ToBoolean(Value);
        }
    }
}
