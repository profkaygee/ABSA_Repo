using System;
using System.Collections.Generic;

#nullable disable

namespace ABSA_Assessment.DataModels.DatabaseModels
{
    public partial class Phonebook
    {
        public Phonebook()
        {
            Entries = new HashSet<Entry>();
        }

        public Guid PhoneBookId { get; set; }
        public string BookName { get; set; }
        public bool? Active { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime TimeStamp { get; set; }

        public virtual ICollection<Entry> Entries { get; set; }
    }
}
