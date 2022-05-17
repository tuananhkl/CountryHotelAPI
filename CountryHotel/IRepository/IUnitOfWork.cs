using System;
using System.Threading.Tasks;
using CountryHotel.Data;

namespace CountryHotel.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }
        IGenericRepository<Hotel> Hotels { get; }
        Task Save();
    }
}