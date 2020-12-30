using Krunker.Common.Models;

namespace Krunker.Common.DTOs
{
    public class BackItemDTO : ShoppingItemDTO
    {
        public bool IsWings { get; set; }

        public BackItemDTO(BackItem item) : base(item)
        {
            IsWings = item.IsWings;
        }
    }
}
