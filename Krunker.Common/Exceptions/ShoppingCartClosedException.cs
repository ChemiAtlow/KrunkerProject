using System;

namespace Krunker.Common.Exceptions
{
    public class ShoppingCartClosedException : Exception
    {
        public ShoppingCartClosedException(string msg): base(msg) { }
    }
}
