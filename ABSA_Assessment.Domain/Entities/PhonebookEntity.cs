using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ABSA_Assessment.Domain.Entities
{
    [Table("Phonebooks")]
    public class PhonebookEntity : BaseEntity
    {
        public Guid PhonebookId { get; set; }
        public string BookName { get; set; }
    }
}
