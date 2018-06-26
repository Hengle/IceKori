using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Tizen;

namespace Assets.Plugins.IceKori.Syntax
{
    [System.Serializable]
    public abstract class BaseNode
    {
        [HideInEditorMode]
        public bool Reducible;
    }
}
