using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Assets.Plugins.IceKori.Syntax.Expression
{
    [System.Serializable]
    public abstract class BaseExpression : BaseNode
    {

        public int ID = 16;
        public abstract BaseExpression Reduce(Enviroment env);
    }
}
