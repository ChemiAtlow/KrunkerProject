using System;

namespace Krunker.Common.Exceptions
{
    public class ItemCreatedWithoutImageException : Exception
    {
        public ItemCreatedWithoutImageException(string msg): base(msg) { }
    }
}
