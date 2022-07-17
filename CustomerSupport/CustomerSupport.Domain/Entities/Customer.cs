using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerSupport.Domain.Entities
{
    public class Customer : EntityBase
    {

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }
        public int Number { get; set; }
        [Required]
        public int TypeInquiry { get; set; }

        [Required]
        [MaxLength(256)]
        public string IssueDescription { get; set; }
        [Required]
        public bool AgreeTerms { get; set; }

    }
}
