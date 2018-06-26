using System;

namespace Assets.Plugins.IceKori.Syntax.BaseType
{
    [System.Serializable]
    public class IceKoriString : IceKoriBaseType
    {
        public string Value;

        public IceKoriString()
        {
        }

        public IceKoriString(string value)
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
