using System;

namespace Krunker.Common.DTOs
{
    public class UpdateItemRequestDTO
    {
        public Guid ItemId { get; set; }
        public int Amount { get; set; }
    }
}
