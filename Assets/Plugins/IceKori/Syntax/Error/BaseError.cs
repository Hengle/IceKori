using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assets.Plugins.IceKori.Syntax.Expression;

namespace Assets.Plugins.IceKori.Syntax.Error
{
     public abstract class BaseError : BaseExpression
     {
         public string Name;
         public string Msg;

         public override BaseExpression Reduce(Enviroment env)
         {
             throw new Exception(ToString());
         }
     }
}
