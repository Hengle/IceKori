using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.BaseType.Object
{
    [System.Serializable]
    public class IceKoriTexture : IceKoriObject
    {
        public Texture Value;

        public IceKoriTexture()
        {
            Reducible = false;
        }

        public IceKoriTexture(Texture value)
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
            return $"<Texture {Value.name}>";
        }
    }
}
