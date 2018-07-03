using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Sirenix.OdinInspector;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public abstract class BaseStatement : BaseNode
    {
        [HideInEditorMode]
        public int Level;
        public abstract object[] Reduce(Enviroment env, ErrorHandling errorHandling);
    }
}
