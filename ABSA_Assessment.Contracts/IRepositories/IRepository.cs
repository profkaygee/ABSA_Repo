using System.Threading.Tasks;

namespace ABSA_Assessment.Contracts.IRepositories
{
    public interface IRepository<T>
    {
        Task<T> AddAsync(T item);
        Task UpdateAsync(T item);
    }
}
