using ABSA_Assessment.Contracts.IRepositories.Queries;
using ABSA_Assessment.DataModels.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ABSA_Assessment.Infrastructure.Repositories.Queries
{
    public class PhonebookQueryRepository : IPhonebookQueryRepository
    {
        private readonly AbsaContext _context;

        public PhonebookQueryRepository(AbsaContext context)
        {
            _context = context;
        }

        public async Task<Phonebook> SelectPhonebook()
        {
            return await _context.Phonebooks.FirstOrDefaultAsync();
        }
    }
}