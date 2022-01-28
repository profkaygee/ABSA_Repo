using ABSA_Assessment.DataModels.DatabaseModels;
using MediatR;
using System.Collections.Generic;

namespace ABSA_Assessment.Application.Queries
{
    public class SearchPhonebookEntriesQuery : IRequest<IList<Entry>>
    {
        public SearchPhonebookEntriesQuery(string phrase)
        {
            SearchPhrase = phrase;
        }

        public string SearchPhrase { get; set; }
    }
}