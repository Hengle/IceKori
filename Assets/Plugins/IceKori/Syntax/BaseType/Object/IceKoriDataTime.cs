using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Plugins.IceKori.Syntax.BaseType.Object
{
    public class IceKoriDataTime : IceKoriBaseType
    {
        public DateTime Value;

        public IceKoriDataTime()
        {
            Reducible = false;
        }

        public IceKoriDataTime(DateTime value)
        {
            Reducible = false;
            Value = value;
        }

        public override object Unbox()
        {
            return Value;
        }
    }
}
