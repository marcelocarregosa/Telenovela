using System.Collections.Generic;

namespace Telenovelas.Interfaces
{
  public interface IRepository<T>
  {
    List<T> List();
    T returnById(int id);
    void Insert(T entity);
    void Delete(int id);
    void Update(int id, T entity);
    int NextId();
  }
}