using System.Collections.Generic;

namespace Store
{
    public interface IPurchaseService 
    {
        List<StoreProduct> GetProductsList();
        void BuyProduct(string productId);

    }
}