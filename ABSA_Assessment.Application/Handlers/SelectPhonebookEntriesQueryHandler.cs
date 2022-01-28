using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ABSA_Assessment.Application.Queries;
using ABSA_Assessment.Contracts.IRepositories.Queries;
using ABSA_Assessment.DataModels.DatabaseModels;
using AutoMapper;
using MediatR;

namespace ABSA_Assessment.Application.Handlers
{
    public class SelectPhonebookEntriesQueryHandler : IRequestHandler<SelectPhonebookEntriesQuery, IList<Entry>>
    {
        private readonly IPhonebookEntryQueryRepository _repository;
        private readonly IMapper _mapper;

        public SelectPhonebookEntriesQueryHandler(IPhonebookEntryQueryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<Entry>> Handle(SelectPhonebookEntriesQuery request, CancellationToken cancellationToken)
        {
            var phonebookEntries = await _repository.SelectPhonebookEntries(request.PhonebookId);
            var entries = _mapper.Map<IList<Entry>>(phonebookEntries);
            return entries;
        }
    }
}