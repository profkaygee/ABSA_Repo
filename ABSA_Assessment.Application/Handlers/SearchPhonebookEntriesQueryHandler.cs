using ABSA_Assessment.Application.Queries;
using ABSA_Assessment.Contracts.IRepositories.Queries;
using ABSA_Assessment.DataModels.DatabaseModels;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ABSA_Assessment.Application.Handlers
{
    public class SearchPhonebookEntriesQueryHandler : IRequestHandler<SearchPhonebookEntriesQuery, IList<Entry>>
    {
        private readonly IPhonebookEntryQueryRepository _repository;
        private readonly IMapper _mapper;

        public SearchPhonebookEntriesQueryHandler(IPhonebookEntryQueryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IList<Entry>> Handle(SearchPhonebookEntriesQuery request, CancellationToken cancellationToken)
        {
            var searchPhrase = await _repository.SearchPhonebookEntries(request.SearchPhrase);
            var entry = _mapper.Map<IList<Entry>>(searchPhrase);
            return entry;
        }
    }
}