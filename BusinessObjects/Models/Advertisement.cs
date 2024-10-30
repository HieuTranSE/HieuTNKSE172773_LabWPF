using System;
using System.Collections.Generic;

namespace BusinessObjects.Models
{
    public partial class Advertisement
    {
        public int AdvertisementId { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int KoiFishId { get; set; }
        public int PostedBy { get; set; }
        public bool? Verified { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual KoiFish KoiFish { get; set; } = null!;
        public virtual Account PostedByNavigation { get; set; } = null!;
    }
}
