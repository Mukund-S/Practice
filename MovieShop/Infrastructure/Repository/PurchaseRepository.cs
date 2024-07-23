using ApplicationCore.Contracts.Repository;
using ApplicationCore.Entity;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class PurchaseRepository: BaseRepository<Purchases>, IPurchaseRepository
{
    public PurchaseRepository(MovieShopDbContext movieShopDbContext) : base(movieShopDbContext)
    {
    }

    public override Purchases GetById(int id)
    {
        return base.GetById(id);
    }
}