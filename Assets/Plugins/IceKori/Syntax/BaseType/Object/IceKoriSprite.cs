using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.BaseType.Object
{
    public class IceKoriSprite : IceKoriObject
    {
        public Sprite Value;

        public IceKoriSprite()
        {
            Reducible = false;
        }

        public IceKoriSprite(Sprite value)
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
            return $"<sprite {Value.name}>";
        }
    }
}
