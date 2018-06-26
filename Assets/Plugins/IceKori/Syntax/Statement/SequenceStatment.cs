using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sirenix.OdinInspector;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class SequenceStatment : BaseStatement
    {
        public SequenceStatment(List<BaseStatement> statements)
        {

        }

        public override BaseStatement Reduce(Enviroment env)
        {
            throw new NotImplementedException();
        }
    }
}
