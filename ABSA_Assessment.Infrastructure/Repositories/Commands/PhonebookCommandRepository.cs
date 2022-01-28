using ABSA_Assessment.Contracts.IRepositories.Commands;
using ABSA_Assessment.DataModels.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ABSA_Assessment.Infrastructure.Repositories.Commands
{
    public class PhonebookCommandRepository : IPhonebookCommandRepository
    {
        private readonly AbsaContext _context;

        public PhonebookCommandRepository(AbsaContext context)
        {
            _context = context;
        }

        public async Task<Phonebook> AddAsync(Phonebook item)
        {
            var entity = await _context.Phonebooks.AddAsync(item);
            await _context.SaveChangesAsync();
            return entity.Entity;
        }

        public async Task UpdateAsync(Phonebook item)
        {
            var phonebook = await _context.Phonebooks.FirstOrDefaultAsync(x => x.PhoneBookId == item.PhoneBookId);
            _context.Entry(item).State = EntityState.Modified;
            _context.Entry(item).Property(x => x.CreatedDate).IsModified = false;
            await _context.SaveChangesAsync();
        }
    }
}