using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class KoiFish
    {
        public KoiFish()
        {
            Advertisements = new HashSet<Advertisement>();
        }

        public int KoiFishId { get; set; }
        public string KoiFishName { get; set; } = null!;
        public string KoiFishColor { get; set; } = null!;
        public decimal KoiFishSize { get; set; }
        public int KoiFishAge { get; set; }
        public int? FengShuiElementId { get; set; }
        public string? SymbolicMeaning { get; set; }
        public string? EnergyType { get; set; }
        public int? FavorableNumber { get; set; }
        public string? Origin { get; set; }
        public decimal Price { get; set; }

        public virtual FengShuiElement? FengShuiElement { get; set; }
        public virtual ICollection<Advertisement> Advertisements { get; set; }
    }
}
