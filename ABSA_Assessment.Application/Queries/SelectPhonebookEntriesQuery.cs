using ABSA_Assessment.DataModels.DatabaseModels;
using MediatR;
using System;
using System.Collections.Generic;

namespace ABSA_Assessment.Application.Queries
{
    public class SelectPhonebookEntriesQuery : IRequest<IList<Entry>>
    {
        public SelectPhonebookEntriesQuery(Guid phonebookId)
        {
            PhonebookId = phonebookId;
        }

        public Guid PhonebookId { get; set; }
    }
}