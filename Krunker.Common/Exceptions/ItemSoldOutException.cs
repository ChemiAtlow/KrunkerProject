using System;

namespace Krunker.Common.Exceptions
{
    public class ItemSoldOutException : Exception
    {
        public ItemSoldOutException(string msg): base(msg) { }
    }
}
