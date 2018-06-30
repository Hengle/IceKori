using System.Collections.Generic;
using Assets.Plugins.IceKori.Syntax.BaseType;
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
        public InterpreterState State = InterpreterState.Pending;
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
            Statement = new Sequence(new List<BaseStatement>{ new TryCatch(commands, ErrorType.All, new List<BaseStatement>{new EvalCallback((enviroment, handling) => Debug.Log(new VariableGet("$!")))}) });
        }

        private void _Reduce()
        {
            if (IsDebug) Debug.Log(Statement.ToString());
            if (Statement.Reducible)
            {
                var reduceValue = Statement.Reduce(Env, ErrorHandling);
                Statement = (BaseStatement)reduceValue[0];
                Env = (Enviroment)reduceValue[1];
                ErrorHandling = (ErrorHandling)reduceValue[2];
                if (Statement.GetType().IsSubclassOf(typeof(EventCommandBase)) && ((EventCommandBase)Statement).IsFinsh == false)
                {
                    State = InterpreterState.Stop;
                }
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
                    if (Statement.GetType().IsSubclassOf(typeof(EventCommandBase)) && ((EventCommandBase)Statement).IsFinsh)
                    {
                        State = InterpreterState.Runnig;
                        _Reduce();
                    }
                    break;
                case InterpreterState.End:
                    return;
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
