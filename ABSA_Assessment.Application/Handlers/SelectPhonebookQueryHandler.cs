using System.Threading;
using System.Threading.Tasks;
using ABSA_Assessment.Application.Queries;
using ABSA_Assessment.Contracts.IRepositories.Queries;
using ABSA_Assessment.DataModels.DatabaseModels;
using AutoMapper;
using MediatR;

namespace ABSA_Assessment.Application.Handlers
{
    public class SelectPhonebookQueryHandler : IRequestHandler<SelectPhonebookQuery, Phonebook>
    {
        private readonly IPhonebookQueryRepository _repository;
        private readonly IMapper _mapper;

        public SelectPhonebookQueryHandler(IPhonebookQueryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Phonebook> Handle(SelectPhonebookQuery request, CancellationToken cancellationToken)
        {
            var phonebook = await _repository.SelectPhonebook();
            var entry = _mapper.Map<Phonebook>(phonebook);
            return entry;
        }
    }
}