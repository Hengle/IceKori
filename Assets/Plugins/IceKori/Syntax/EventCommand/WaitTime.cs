using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.BaseType.Object;
using Assets.Plugins.IceKori.Syntax.Statement;
using UnityEngine;

namespace Assets.Plugins.IceKori.Syntax.EventCommand
{
    public class WaitTime : EventCommandBase
    {
        public int Sec;
        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            var top = env.GetTopVariables();
            top.Add("$TIMER", new IceKoriDataTime(DateTime.Now));
            top.Add("$DATE", new IceKoriInt(Sec));
            env.Interpreter.State = InterpreterState.Stop;
            return new object[]{ new DoNothing(), env, errorHandling };
        }
    }
}
