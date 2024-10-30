using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class FengShuiElement
    {
        public FengShuiElement()
        {
            KoiFishes = new HashSet<KoiFish>();
        }

        public int ElementId { get; set; }
        public string ElementName { get; set; } = null!;
        public string? Description { get; set; }

        public virtual ICollection<KoiFish> KoiFishes { get; set; }
    }
}
