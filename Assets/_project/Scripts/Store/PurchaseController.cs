using System.Collections.Generic;

namespace Store
{
    public class PurchaseController 
    {
        private IPurchaseService _purchaseService;

        public PurchaseController(IPurchaseService purchaseService)
        {
            _purchaseService = purchaseService;
        }

        public void BuyProduct(string productId)
        {
            _purchaseService.BuyProduct(productId);
        }

        public List<StoreProduct> GetProductsList()
        {
            return _purchaseService.GetProductsList();
        }
    }
}