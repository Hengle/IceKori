using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.BaseType.Object
{
    public class IceKoriColor : IceKoriObject
    {
        public Color Value;

        public IceKoriColor()
        {
            Reducible = false;
        }

        public IceKoriColor(Color value)
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
            return $"<Color r:{Value.r}, g:{Value.g}, b:{Value.b}, a:{Value.a}>";
        }
    }
}
