using System;
using System.Collections.Generic;
using Telenovelas.Interfaces; 

namespace Telenovelas
{
  public class TelenovelasRepository : IRepository<Telenovela>
  {
    private List<Telenovela> telenovelasList = new List<Telenovela>();
    
    public void Delete(int id)
    {
      telenovelasList[id].Delete();
    }

    public void Insert(Telenovela entity)
    {
      telenovelasList.Add(entity);
    }

    public List<Telenovela> List()
    {
      return telenovelasList;
    }

    public int NextId()
    {
      return telenovelasList.Count;
    }

    public Telenovela returnById(int id)
    {
      return telenovelasList[id];
    }

    public void Update(int id, Telenovela entity)
    {
      telenovelasList[id] = entity;
    }
  }
}