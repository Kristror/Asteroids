using Store;
using Utilities;

namespace UI
{
    public class StoreUIModel 
    {
        private PurchaseController _purchaseController;
        private LoadingController _loadingController;
        
        public StoreUIModel(LoadingController loadingController, PurchaseController purchaseController)
        {
            _loadingController = loadingController;
            _purchaseController = purchaseController;
        }

        public void BackToMenu()
        {
            _loadingController.LoadMainMenu();
        }

        public void BuyProduct(string productId)
        {
            _purchaseController.BuyProduct(productId);
        }
    }
}