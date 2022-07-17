using System;
using System.ComponentModel.DataAnnotations;

namespace CustomerSupport.Application.ViewModels
{
    public class CustomerViewModel
    {
        public Guid? Id { get; set; } = Guid.NewGuid();

        public string Email { get; set; }
        public string Phone { get; set; }
        public int Number { get; set; }
        public int TypeInquiry { get; set; }

        public string IssueDescription { get; set; }
        public bool AgreeTerms { get; set; }
    }
}
