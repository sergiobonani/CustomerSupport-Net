using CustomerSupport.Domain.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerSupport.Domain.Entities
{
    public class EntityBase : IAuditableEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [MaxLength(256)]
        public string CreatedBy { get; set; }
        [MaxLength(256)]
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
