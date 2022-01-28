using ABSA_Assessment.DataModels.DatabaseModels;
using System.Threading.Tasks;

namespace ABSA_Assessment.Contracts.IRepositories.Queries
{
    public interface IPhonebookQueryRepository
    {
        Task<Phonebook> SelectPhonebook();
    }
}