using ABSA_Assessment.DataModels.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ABSA_Assessment.Contracts.IRepositories.Queries
{
    public interface IPhonebookEntryQueryRepository
    {
        Task<IList<Entry>> SelectPhonebookEntries(Guid phonebookId);
        Task<IList<Entry>> SearchPhonebookEntries(string searchPhrase);
    }
}