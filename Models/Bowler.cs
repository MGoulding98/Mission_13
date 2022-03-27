using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission_13.Models
{
    public class Bowler
    {
        [Key]
        [Required]
        public int BowlerID { get; set; }
        [MaxLength(50, ErrorMessage ="50 characters max")]
        public string BowlerLastName { get; set; }
        [MaxLength(50, ErrorMessage = "50 characters max")]
        public string BowlerFirstName { get; set; }
        [MaxLength(1, ErrorMessage = "1 character max")]
        public string BowlerMiddleInit { get; set; }
        [MaxLength(50, ErrorMessage = "50 characters max")]
        public string BowlerAddress { get; set; }
        [MaxLength(50, ErrorMessage = "50 characters max")]
        public string BowlerCity { get; set; }
        [MaxLength(2, ErrorMessage = "2 characters max")]
        public string BowlerState { get; set; }
        [MaxLength(10, ErrorMessage = "10 characters max")]
        public string BowlerZip { get; set; }
        [MaxLength(14, ErrorMessage = "14 characters max")]
        public string BowlerPhoneNumber { get; set; }
        public int TeamID { get; set; }
    }
}
