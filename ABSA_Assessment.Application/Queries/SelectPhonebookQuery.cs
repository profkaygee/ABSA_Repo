using ABSA_Assessment.DataModels.DatabaseModels;
using MediatR;
using System;

namespace ABSA_Assessment.Application.Queries
{
    public class SelectPhonebookQuery : IRequest<Phonebook>
    {
        public SelectPhonebookQuery(Guid phonebookId)
        {
            PhonebookId = phonebookId;
        }

        public SelectPhonebookQuery() { }

        public Guid PhonebookId { get; set; }
    }
}