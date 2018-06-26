using System;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.BaseType
{
    [System.Serializable]
    public class IceKoriFloat : IceKoriBaseType
    {
        public float Value;

        public IceKoriFloat()
        {
        }

        public IceKoriFloat(float value)
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
