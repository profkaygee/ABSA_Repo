using ABSA_Assessment.Contracts.IRepositories.Queries;
using ABSA_Assessment.DataModels.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABSA_Assessment.Infrastructure.Repositories.Queries
{
    public class PhonebookEntryQueryRepository : IPhonebookEntryQueryRepository
    {
        private readonly AbsaContext _context;
        private readonly DbSet<Entry> _table;

        public PhonebookEntryQueryRepository(AbsaContext context)
        {
            _context = context;
            _table = _context.Set<Entry>();
        }

        public async Task<IList<Entry>> SelectPhonebookEntries(Guid phonebookId)
        {
            return (await Task.Run(() => _table.Where(x => x.PhonebookId == phonebookId))).ToList();
        }

        public async Task<IList<Entry>> SearchPhonebookEntries(string searchPhrase)
        {
            return (await Task.Run(() => _table.Where(x => x.Name.ToLower().Contains(searchPhrase.ToLower())))).ToList();
        }
    }
}