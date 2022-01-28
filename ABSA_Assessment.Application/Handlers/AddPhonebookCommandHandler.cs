using ABSA_Assessment.Application.Commands;
using ABSA_Assessment.Contracts.IRepositories.Commands;
using ABSA_Assessment.Core;
using ABSA_Assessment.DataModels.DatabaseModels;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ABSA_Assessment.Application.Handlers
{
    public class AddPhonebookCommandHandler : IRequestHandler<AddPhonebookCommand, CommandResult>
    {
        private readonly IPhonebookCommandRepository _repository;
        private readonly IMapper _mapper;

        public AddPhonebookCommandHandler(IPhonebookCommandRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CommandResult> Handle(AddPhonebookCommand request, CancellationToken cancellationToken)
        {
            var returnValue = new Phonebook();

            var phonebook = _mapper.Map<Phonebook>(request.Phonebook);
            var validationResult = new CommandResult<Phonebook>(returnValue, false, string.Empty);

            try
            {
                var result = await _repository.AddAsync(phonebook);
                validationResult = new CommandResult<Phonebook>(returnValue, true, string.Empty);
            }
            catch (Exception exception)
            {
                while (exception.InnerException != null)
                {
                    exception = exception.InnerException;
                }

                validationResult.AddResultMessage(ResultMessageType.Error, "400", exception.Message.ToString());
                Console.WriteLine(exception);
                throw;
            }

            return validationResult;
        }
    }
}