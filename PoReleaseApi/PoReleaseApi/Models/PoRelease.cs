using System;
using System.Collections.Generic;

namespace PoReleaseApi.Models
{
    public partial class PoRelease
    {
        public int Id { get; set; }
        public string? RequestingPlant { get; set; }
        public string? PoNumber { get; set; }
        public string? HighUrgency { get; set; }
        public double? TotalPovalue { get; set; }
        public string? AreaManagerEmail { get; set; }
        public string? RequestReason { get; set; }
        public string? CustomerName { get; set; }
        public string? CustomerCancellationTerms { get; set; }
        public string? CancellationPolicy { get; set; }
        public bool? IsCheckedDnowInventory { get; set; }
        public bool? IsAvailableInCompany { get; set; }
        public bool? IsUsesItemCodes { get; set; }
        public bool? IsCollaborateWithCorporateAndCentral { get; set; }
        public string? VendorName { get; set; }
        public string? VendorReturnPolicy { get; set; }
        public string? RestockingFees { get; set; }
        public string? PoType { get; set; }
        public bool? IsPoGreaterFiftyThousand { get; set; }
        public string? AdditionalNotes { get; set; }
        public string? Attachment { get; set; }
    }
}
