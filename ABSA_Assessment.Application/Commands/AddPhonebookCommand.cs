using ABSA_Assessment.Core;
using ABSA_Assessment.DataModels.DatabaseModels;
using MediatR;

namespace ABSA_Assessment.Application.Commands
{
    public class AddPhonebookCommand : IRequest<CommandResult>
    {
        public AddPhonebookCommand(Phonebook phonebook)
        {
            Phonebook = phonebook;
        }

        public Phonebook Phonebook { get; set; }
    }
}