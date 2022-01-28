using System;
using System.Collections.Generic;

#nullable disable

namespace ABSA_Assessment.DataModels.DatabaseModels
{
    public partial class Entry
    {
        public Guid PhoneEntryId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Guid PhonebookId { get; set; }
        public bool? Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual Phonebook Phonebook { get; set; }
    }
}
