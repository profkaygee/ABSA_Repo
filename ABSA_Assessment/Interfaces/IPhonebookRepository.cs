using System;
using ABSA_Assessment.ViewModels;

namespace ABSA_Assessment.Interfaces
{
    public interface IPhonebookRepository : IDisposable
    {
        MessageResponse AddPhonebook(PhonebookViewModel phonebook);
        PhonebookViewModel SelectPhonebook(Guid phonebookId);
    }
}