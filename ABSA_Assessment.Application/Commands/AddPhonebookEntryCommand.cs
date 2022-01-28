using ABSA_Assessment.Core;
using ABSA_Assessment.DataModels.DatabaseModels;
using MediatR;

namespace ABSA_Assessment.Application.Commands
{
    public class AddPhonebookEntryCommand : IRequest<CommandResult>
    {
        public AddPhonebookEntryCommand(Entry entry)
        {
            Entry = entry;
        }

        public Entry Entry { get; set; }
    }
}