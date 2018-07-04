using System;
using Assets.Plugins.IceKori.Syntax;
using UnityEngine;

namespace Assets.Plugins.IceKori
{
    public static class IceKori
    {

        public static GlobalConf Conf;
        public static Action<GlobalConf> DefineGlobal;
        public static void LoadGlobalConf()
        {
            var db = Resources.Load<GlobalConf>("GlobalConf");
            db.hideFlags = HideFlags.DontSaveInBuild;
            Conf = db;
        }

        private static void _DefineGlobal()
        {
            DefineGlobal(Conf);
        }

        public static void Init()
        {
            LoadGlobalConf();
            _DefineGlobal();
        }
    }
}
