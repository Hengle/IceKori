using Assets.Plugins.IceKori.Syntax;
using UnityEngine;

namespace Assets.Plugins.IceKori
{
    public static class IceKori
    {

        public static GlobalConf Conf;

        public static void LoadGlobalConf()
        {
            var db = Resources.Load<GlobalConf>("GlobalConf");
            db.hideFlags = HideFlags.DontSaveInBuild;
            Conf = db;
        }

        public static void DefineGlobal()
        {

        }

        public static void Init()
        {
            LoadGlobalConf();
            DefineGlobal();
        }
    }
}
