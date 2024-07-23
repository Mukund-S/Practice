using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class UserRepository: BaseRepository<Users>, IUserRepository
{
    public UserRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
    {
    }

    public override Users GetById(int id)
    {
        return base.GetById(id);
    }
}