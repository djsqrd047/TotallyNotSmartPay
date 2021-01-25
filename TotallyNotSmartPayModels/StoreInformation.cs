using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TotallyNotSmartPayModels
{
    public class StoreInformation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(1, 100000, ErrorMessage = "Store Number must be between 1 and 100000.")]
        public int StoreNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public int SINId { get; set; }
        [Required]
        public int VINId { get; set; }
        [Required]
        public string RINId { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
