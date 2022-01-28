using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABSA_Assessment.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Column(TypeName = "bit")] 
        public bool Active { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime TimeStamp { get; set; }
    }
}