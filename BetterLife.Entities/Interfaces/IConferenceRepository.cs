using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterLife.Domain.Interfaces
{
    public interface IConferenceRepository
    {
        Task Create(Domain.Entities.Conference conference);
        Task<IEnumerable<Domain.Entities.Conference>> GetAll();
        Task<Domain.Entities.Conference> GetByEncodedType(string encodedType);//Sprawdzenie unikalności
        Task Commit();
    }
}
