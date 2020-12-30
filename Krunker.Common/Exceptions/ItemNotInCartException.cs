using System;

namespace Krunker.Common.Exceptions
{
    public class ItemNotInCartException : Exception
    {
        public ItemNotInCartException(string msg): base(msg) { }
    }
}
