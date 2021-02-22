using System.Collections.Generic;

namespace ABSA_Assessment.ViewModels
{
    public class PhonebookViewModel
    {
        public int PhoneBookId { get; set; }
        public string BookName { get; set; }
        public IList<PhonebookEntryViewModel> PhonebookEntries { get; set; }
    }
}