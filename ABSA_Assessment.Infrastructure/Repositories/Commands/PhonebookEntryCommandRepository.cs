using ABSA_Assessment.Contracts.IRepositories.Commands;
using ABSA_Assessment.DataModels.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ABSA_Assessment.Infrastructure.Repositories.Commands
{
    public class PhonebookEntryCommandRepository : IPhonebookEntryCommandRepository
    {
        private readonly AbsaContext _context;

        public PhonebookEntryCommandRepository(AbsaContext context)
        {
            _context = context;
        }

        public async Task<Entry> AddAsync(Entry item)
        {
            var entity = await _context.Entries.AddAsync(item);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task UpdateAsync(Entry item)
        {
            var entry = await _context.Entries.FirstOrDefaultAsync(x => x.PhoneEntryId == item.PhoneEntryId);
            _context.Entry(item).State = EntityState.Modified;
            _context.Entry(item).Property(x => x.CreatedDate).IsModified = false;
            await _context.SaveChangesAsync();
        }
    }
}