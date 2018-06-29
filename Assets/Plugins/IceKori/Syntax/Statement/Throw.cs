using Assets.Plugins.IceKori.Syntax.Error;

namespace Assets.Plugins.IceKori.Syntax.Statement
{
    [System.Serializable]
    public class Throw : BaseStatement
    {
        public BaseError Error;

        public Throw()
        {
            Reducible = false;
        }

        public Throw(BaseError error)
        {
            Reducible = false;
            Error = error;
        }

        public override string ToString()
        {
            return $"throw({Error})";
        }

        public override object[] Reduce(Enviroment env, ErrorHandling errorHandling)
        {
            errorHandling.ThrowError(Error);
            return new object[]{ new DoNothing(), env, errorHandling };
        }
    }
}
