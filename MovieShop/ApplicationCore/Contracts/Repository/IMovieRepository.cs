using ApplicationCore.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Model.Response;

namespace ApplicationCore.Contracts.Repository
{
    public interface IMovieRepository : IRepository<Movies>
    {
        Task<IEnumerable<Movies>> GetByGenreAsync(string genre);
    }
}