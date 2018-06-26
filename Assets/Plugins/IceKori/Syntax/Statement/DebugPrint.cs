using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class DebugPrint : BaseStatement
    {
        public BaseNode Object;

        public override string ToString()
        {
            return $"print({Object})";
        }

        public override BaseStatement Reduce(Enviroment env)
        {
            Debug.Log(Object);
            return new DoNothing();
        }
    }
}
