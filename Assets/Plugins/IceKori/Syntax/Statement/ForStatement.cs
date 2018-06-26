using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Plugins.IceKori.Syntax.BaseType;
using Assets.Plugins.IceKori.Syntax.Expression;
using Sirenix.OdinInspector;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class ForStatement : BaseStatement
    {
        public IceKoriInt Count = new IceKoriInt();
        public List<BaseStatement> Body = new List<BaseStatement>();
        [HideInEditorMode]
        public int Index;

        public override BaseStatement Reduce(Enviroment env)
        {
            Index += 1;
            var condition = new BinaryExpression(BinaryOperator.LessEqual, new IceKoriInt(Index), Count);
            return new IfStatement(condition, new List<BaseStatement>(Body) {this}, new List<BaseStatement>());
        }
    }
}
