using System.Linq;

namespace SegFyYoutube.Domain.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        void Add(T obj);
        T GetById(string id);
        IQueryable<T> GetAll();
        void Update(T obj);
        void Remove(string id);
        int SaveChanges();
        void AddOrUpdate(T obj);
    }
}
