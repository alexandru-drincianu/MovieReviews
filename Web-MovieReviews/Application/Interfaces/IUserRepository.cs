using Domain.Entities;

namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAll();
        Task<User> GetById(Guid id);
        Task Add(User user);
        Task Update(User user);
        Task Delete(int id);
    }
}
