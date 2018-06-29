using System;

namespace Assets.Plugins.IceKori.Syntax.BaseType
{
    [System.Serializable]
    public class IceKoriInt : IceKoriBaseType
    {
        public int Value;
        public IceKoriInt()
        {
            Reducible = false;
        }

        public IceKoriInt(int value)
        {
            Reducible = false;
            Value = value;
        }

        public override object Unbox()
        {
            return Value;
        }

        public override string ToString()
        {
            return $"{Value}";
        }

        public bool ToBool()
        {
            return Convert.ToBoolean(Value);
        }
    }
}
