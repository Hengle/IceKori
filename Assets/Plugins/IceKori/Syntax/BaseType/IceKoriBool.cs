namespace Assets.Plugins.IceKori.Syntax.BaseType
{
    [System.Serializable]
    public class IceKoriBool : IceKoriBaseType
    {
        public bool Value;

        public IceKoriBool()
        {
        }

        public IceKoriBool(bool value)
        {
            Value = value;
        }


        public override object Unbox()
        {
            return Value;
        }
    }
}
