using ABSA_Assessment.ViewModels;
using System;
using System.Collections.Generic;

namespace ABSA_Assessment.Interfaces
{
    public interface IEntryRepository : IDisposable
    {
        MessageResponse AddPhonebookEntry(PhonebookEntryViewModel entry);
        IList<PhonebookEntryViewModel> SelectPhoneBookEntries(int? phonebookId);
        IList<PhonebookEntryViewModel> SelectSearchedEntries(string phrase);
    }
}