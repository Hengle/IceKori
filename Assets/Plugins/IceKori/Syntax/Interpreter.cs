using System;
using System.Collections.Generic;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.BaseType.Object;
using Assets.Plugins.IceKori.Syntax.EventCommand;
using Assets.Plugins.IceKori.Syntax.Expression;
using UnityEngine;
using Assets.Plugins.IceKori.Syntax.Statement;

namespace Assets.Plugins.IceKori.Syntax
{
    public enum InterpreterState
    {
        Pending,
        Runnig,
        Stop,
        End
    }

    public class Interpreter
    {
        public InterpreterState State;
        public bool IsDebug;
        public BaseStatement Statement;
        public Enviroment Env;
        public ErrorHandling ErrorHandling;
        public Interpreter(Dictionary<string, BaseExpression> commonVariables,
            Dictionary<string, List<BaseStatement>> commonCommands,
            Dictionary<string, IceKoriBaseType> globalVariables,
            Dictionary<string, List<BaseStatement>> globalCommands,
            List<BaseStatement> commands)
        {
            ErrorHandling = new ErrorHandling();
            Env = new Enviroment(this, commonVariables, commonCommands, globalVariables, globalCommands);
            Statement = new Sequence(commands);
            _DefaultDefine();
            State = InterpreterState.Pending;
        }

        private void _DefaultDefine()
        {
            Env.Variables.Add("$!", IceKoriNull.GetNull);
        }

        private void _Reduce()
        {
            if (IsDebug) Debug.Log(Statement.ToString());
            if (Statement.GetType() != typeof(DoNothing))
            {
                var reduceValue = Statement.Reduce(Env, ErrorHandling);
                Statement = (BaseStatement)reduceValue[0];
                Env = (Enviroment)reduceValue[1];
                ErrorHandling = (ErrorHandling)reduceValue[2];
            }
            else
            {
                State = InterpreterState.End;
            }

        }

        public void Reduce()
        {
            switch (State)
            {
                case InterpreterState.Pending:
                    State = InterpreterState.Runnig;
                    _Reduce();
                    break;
                case InterpreterState.Runnig:
                    _Reduce();
                    break;
                case InterpreterState.Stop:
                    _WaiteTime();
                    _WaiteFrame();
                    break;
                case InterpreterState.End:
                    return;
            }

        }

        private void _WaiteTime()
        {
            if (Env.GetTopVariables().ContainsKey("$TIMER"))
            {
                var timer = ((IceKoriDataTime)Env.GetTopVariables()["$TIMER"]).Value;
                var date = ((IceKoriInt)Env.GetTopVariables()["$DATE"]).Value;
                if ((DateTime.Now - timer).Ticks >= date * 10000000)
                {
                    Env.GetTopVariables().Remove("$TIMER");
                    Env.GetTopVariables().Remove("$DATE");
                    State = InterpreterState.Runnig;
                    _Reduce();
                }
            }
        }

        private void _WaiteFrame()
        {
            if (Env.GetTopVariables().ContainsKey("$WAIT_FRAME"))
            {
                var frame = ((IceKoriInt)Env.GetTopVariables()["$WAIT_FRAME"]).Value;
                var index = ((IceKoriInt)Env.GetTopVariables()["$WAIT_FRAME_INDEX"]).Value;
                if (index > frame)
                {
                    Env.GetTopVariables().Remove("$WAIT_FRAME_INDEX");
                    Env.GetTopVariables().Remove("$WAIT_FRAME");
                    State = InterpreterState.Runnig;
                    _Reduce();
                }
                else
                {
                    ((IceKoriInt) Env.GetTopVariables()["$WAIT_FRAME_INDEX"]).Value += 1;
                }
            }
        }

        public void Run()
        {
            State = InterpreterState.Runnig;
            while (Statement.Reducible && State != InterpreterState.Stop)
            {
                Reduce();
            }
        }
    }
}
