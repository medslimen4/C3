using LaverieEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C3.Domain.Services
{
    public interface IDataService
    {
        Task<List<Proprietaire>> GetProprietairesAsync(CancellationToken cancellationToken);
    }
}
