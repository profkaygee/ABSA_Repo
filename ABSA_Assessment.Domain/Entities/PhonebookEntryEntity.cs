using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABSA_Assessment.Domain.Entities
{
    [Table("Entries")]
    public class PhonebookEntryEntity : BaseEntity
    {
        public Guid PhoneEntryId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Guid PhonebookId { get; set; }
    }
}