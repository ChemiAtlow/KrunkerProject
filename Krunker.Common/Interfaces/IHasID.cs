using System;

namespace Krunker.Common.Interfaces
{
    public interface IHasID
    {

        /// <summary>
        /// The ID of item.
        /// </summary>
        public Guid Id { get; set; }
    }
}
