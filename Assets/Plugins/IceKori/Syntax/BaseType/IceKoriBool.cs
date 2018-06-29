using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.BaseType
{
    [System.Serializable]
    public class IceKoriBool : IceKoriBaseType
    {
        public bool Value;
        public IceKoriBool()
        {
            Reducible = false;
        }

        public IceKoriBool(bool value)
        {
            Reducible = false;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Value}";
        }

        public override object Unbox()
        {
            return Value;
        }
    }
}
