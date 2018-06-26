using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Error;
using Sirenix.OdinInspector;

namespace Assets.Plugins.IceKori.Syntax.Expression
{
    [System.Serializable]
    public enum BinaryOperator
    {
        Add,
        Sub,
        Mul,
        Div,
        Mod,
        Concat,
        Less,
        LessEqual,
        Equal,
        MoreEqual,
        More,
        NotEqual,
        And,
        Or
    }

    [System.Serializable]
    public class BinaryExpression : BaseExpression
    {
        public BinaryOperator Operator;
        public BaseExpression Left;
        public BaseExpression Right;
        
        public BinaryExpression()
        {
        }

        public BinaryExpression(BinaryOperator op, BaseExpression left, BaseExpression right)
        {
            Operator = op;
            Left = left;
            Right = right;
        }

        public override string ToString()
        {
            return $"({Left} {GetSymbol()} {Right})";
        }

        private string GetSymbol()
        {
            switch (Operator)
            {
                case BinaryOperator.Add:
                    return "+";
                case BinaryOperator.Sub:
                    return "-";
                case BinaryOperator.Mul:
                    return "*";
                case BinaryOperator.Div:
                    return "/";
                case BinaryOperator.Mod:
                    return "%";
                case BinaryOperator.Concat:
                    return "..";
                case BinaryOperator.Less:
                    return "<";
                case BinaryOperator.LessEqual:
                    return "<=";
                case BinaryOperator.Equal:
                    return "==";
                case BinaryOperator.MoreEqual:
                    return ">=";
                case BinaryOperator.More:
                    return ">";
                case BinaryOperator.NotEqual:
                    return "!=";
                case BinaryOperator.And:
                    return "&&";
                case BinaryOperator.Or:
                    return "||";
                default:
                    throw new Exception($"error operator,\"{Operator}\" not define.");
            }
        }

        private BaseExpression _Add()
        {
            if(Left is IceKoriInt && Right is IceKoriInt)
            {
                return new IceKoriInt(((IceKoriInt)Left).Value + ((IceKoriInt)Left).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value + ((IceKoriFloat)Left).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriInt)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value + ((IceKoriInt)Left).Value);
            }
            if (Left is IceKoriInt && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriInt)Left).Value + ((IceKoriFloat)Left).Value);
            }
            return new TypeError();
        }

        private BaseExpression _Sub()
        {
            if (Left is IceKoriInt && Right is IceKoriInt)
            {
                return new IceKoriInt(((IceKoriInt)Left).Value - ((IceKoriInt)Left).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value - ((IceKoriFloat)Left).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriInt)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value - ((IceKoriInt)Left).Value);
            }
            if (Left is IceKoriInt && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriInt)Left).Value - ((IceKoriFloat)Left).Value);
            }
            return new TypeError();
        }

        private BaseExpression _Mul()
        {
            if (Left is IceKoriInt && Right is IceKoriInt)
            {
                return new IceKoriInt(((IceKoriInt)Left).Value * ((IceKoriInt)Left).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value * ((IceKoriFloat)Left).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriInt)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value * ((IceKoriInt)Left).Value);
            }
            if (Left is IceKoriInt && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriInt)Left).Value * ((IceKoriFloat)Left).Value);
            }
            return new TypeError();
        }

        private BaseExpression _Div()
        {
            if (Left is IceKoriInt && Right is IceKoriInt)
            {
                return new IceKoriInt(((IceKoriInt)Left).Value / ((IceKoriInt)Left).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value / ((IceKoriFloat)Left).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriInt)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value / ((IceKoriInt)Left).Value);
            }
            if (Left is IceKoriInt && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriInt)Left).Value / ((IceKoriFloat)Left).Value);
            }
            return new TypeError();
        }

        private BaseExpression _Mod()
        {
            if (Left is IceKoriInt && Right is IceKoriInt)
            {
                return new IceKoriInt(((IceKoriInt)Left).Value % ((IceKoriInt)Left).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value % ((IceKoriFloat)Left).Value);
            }
            if (Left is IceKoriFloat && Right is IceKoriInt)
            {
                return new IceKoriFloat(((IceKoriFloat)Left).Value % ((IceKoriInt)Left).Value);
            }
            if (Left is IceKoriInt && Right is IceKoriFloat)
            {
                return new IceKoriFloat(((IceKoriInt)Left).Value % ((IceKoriFloat)Left).Value);
            }
            return new TypeError();
        }

        private BaseExpression _Concat()
        {
            return new IceKoriString($"{((IceKoriBaseType)Left).Unbox()}{((IceKoriBaseType)Right).Unbox()}");
        }

        private BaseExpression _Less()
        {
            if(Left is IceKoriBool || 
               Right is IceKoriBool || 
               Left is IceKoriString || 
               Right is IceKoriString) return new TypeError();
            if (Left is IceKoriInt)
            {
                if (Right is IceKoriInt)
                {
                    return new IceKoriBool(((IceKoriInt)Left).Value < ((IceKoriInt)Right).Value);
                }
                return new IceKoriBool(((IceKoriInt)Left).Value < ((IceKoriFloat)Right).Value);
            }
            if (Right is IceKoriInt)
            {
                return new IceKoriBool(((IceKoriFloat)Left).Value < ((IceKoriInt)Right).Value);
            }
            return new IceKoriBool(((IceKoriFloat)Left).Value < ((IceKoriFloat)Right).Value);

        }

        private BaseExpression _LessEqual()
        {
            if (Left is IceKoriBool ||
                Right is IceKoriBool ||
                Left is IceKoriString ||
                Right is IceKoriString) return new TypeError();
            if (Left is IceKoriInt)
            {
                if (Right is IceKoriInt)
                {
                    return new IceKoriBool(((IceKoriInt)Left).Value > ((IceKoriInt)Right).Value);
                }
                return new IceKoriBool(((IceKoriInt)Left).Value > ((IceKoriFloat)Right).Value);
            }
            if (Right is IceKoriInt)
            {
                return new IceKoriBool(((IceKoriFloat)Left).Value > ((IceKoriInt)Right).Value);
            }
            return new IceKoriBool(((IceKoriFloat)Left).Value > ((IceKoriFloat)Right).Value);
        }

        private BaseExpression _Equal()
        {
            if (Left is IceKoriBool ||
                Right is IceKoriBool ||
                Left is IceKoriString ||
                Right is IceKoriString) return new TypeError();
            if (Left is IceKoriInt)
            {
                if (Right is IceKoriInt)
                {
                    return new IceKoriBool(((IceKoriInt)Left).Value == ((IceKoriInt)Right).Value);
                }
                return new IceKoriBool(((IceKoriInt)Left).Value == ((IceKoriFloat)Right).Value);
            }
            if (Right is IceKoriInt)
            {
                return new IceKoriBool(((IceKoriFloat)Left).Value == ((IceKoriInt)Right).Value);
            }
            return new IceKoriBool(((IceKoriFloat)Left).Value == ((IceKoriFloat)Right).Value);
        }

        private BaseExpression _MoreEqual()
        {
            if (Left is IceKoriBool ||
                Right is IceKoriBool ||
                Left is IceKoriString ||
                Right is IceKoriString) return new TypeError();
            if (Left is IceKoriInt)
            {
                if (Right is IceKoriInt)
                {
                    return new IceKoriBool(((IceKoriInt)Left).Value >= ((IceKoriInt)Right).Value);
                }
                return new IceKoriBool(((IceKoriInt)Left).Value >= ((IceKoriFloat)Right).Value);
            }
            if (Right is IceKoriInt)
            {
                return new IceKoriBool(((IceKoriFloat)Left).Value >= ((IceKoriInt)Right).Value);
            }
            return new IceKoriBool(((IceKoriFloat)Left).Value >= ((IceKoriFloat)Right).Value);
        }

        private BaseExpression _More()
        {
            if (Left is IceKoriBool ||
                Right is IceKoriBool ||
                Left is IceKoriString ||
                Right is IceKoriString) return new TypeError();
            if (Left is IceKoriInt)
            {
                if (Right is IceKoriInt)
                {
                    return new IceKoriBool(((IceKoriInt)Left).Value > ((IceKoriInt)Right).Value);
                }
                return new IceKoriBool(((IceKoriInt)Left).Value > ((IceKoriFloat)Right).Value);
            }
            if (Right is IceKoriInt)
            {
                return new IceKoriBool(((IceKoriFloat)Left).Value > ((IceKoriInt)Right).Value);
            }
            return new IceKoriBool(((IceKoriFloat)Left).Value > ((IceKoriFloat)Right).Value);
        }

        private BaseExpression _NotEqual()
        {
            if (Left is IceKoriBool ||
                Right is IceKoriBool ||
                Left is IceKoriString ||
                Right is IceKoriString) return new TypeError();
            if (Left is IceKoriInt)
            {
                if (Right is IceKoriInt)
                {
                    return new IceKoriBool(((IceKoriInt)Left).Value != ((IceKoriInt)Right).Value);
                }
                return new IceKoriBool(((IceKoriInt)Left).Value != ((IceKoriFloat)Right).Value);
            }
            if (Right is IceKoriInt)
            {
                return new IceKoriBool(((IceKoriFloat)Left).Value != ((IceKoriInt)Right).Value);
            }
            return new IceKoriBool(((IceKoriFloat)Left).Value != ((IceKoriFloat)Right).Value);
        }

        private BaseExpression _And()
        {
            if (Left is IceKoriBool && Right is IceKoriBool) {
                return new IceKoriBool(((IceKoriBool)Left).Value && ((IceKoriBool)Left).Value);
            }
             return new TypeError();       
        }

        private BaseExpression _Or()
        {
            if (Left is IceKoriBool && Right is IceKoriBool)
            {
                return new IceKoriBool(((IceKoriBool)Left).Value || ((IceKoriBool)Left).Value);
            }
            return new TypeError();
        }

        public override BaseExpression Reduce(Enviroment env)
        {
            while (Left.Reducible)
            {
                Left = Left.Reduce(env);
                if (Left.GetType().IsSubclassOf(typeof(Error.Error)))
                {
                    return Left;
                }
            }

            while (Right.Reducible)
            {
                Right = Right.Reduce(env);
                if (Left.GetType().IsSubclassOf(typeof(Error.Error)))
                {
                    return Left;
                }
            }
            switch (Operator)
            {
                case BinaryOperator.Add:
                    return _Add();
                case BinaryOperator.Sub:
                    return _Sub();
                case BinaryOperator.Mul:
                    return _Mul();
                case BinaryOperator.Div:
                    return _Div();
                case BinaryOperator.Mod:
                    return _Mod();
                case BinaryOperator.Concat:
                    return _Concat();
                case BinaryOperator.Less:
                    return _Less();
                case BinaryOperator.LessEqual:
                    return _LessEqual();
                case BinaryOperator.Equal:
                    return _Equal();
                case BinaryOperator.MoreEqual:
                    return _MoreEqual();
                case BinaryOperator.More:
                    return _More();
                case BinaryOperator.NotEqual:
                    return _NotEqual();
                case BinaryOperator.And:
                    return _And();
                case BinaryOperator.Or:
                    return _Or();
                default:
                    throw new Exception($"error operator,\"{Operator}\" not define.");
            }
        }
    }
}
