using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Assets.Plugins.IceKori.Syntax.Expression
{
    [System.Serializable]
    public abstract class BaseExpression : BaseNode
    {
        [HideInEditorMode]
        public new bool Reducible = true;

        public abstract BaseExpression Reduce(Enviroment env);
    }
}
