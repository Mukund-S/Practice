using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class GenresRespository: BaseRepository<Genres>, IGenresRepository
{
    public GenresRespository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
    {
    }

    public override Genres GetById(int id)
    {
        return base.GetById(id);
    }
}