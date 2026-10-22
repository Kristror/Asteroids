using Ads;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Purchasing;
using Zenject;

namespace Store
{
    public class UnityInAppPurchase : IInitializable, IPurchaseService
    {
        private List<StoreProduct> ProductsList;

        private StoreController _storeController;
        private IShowAds _adsController;

        public UnityInAppPurchase(IShowAds adsController)
        {
            _adsController = adsController;
            ProductsList = new List<StoreProduct>();
        }

        public void Initialize()
        {
            FillCataloge();
        }

        public List<StoreProduct> GetProductsList()
        {
            return ProductsList;
        }

        public void BuyProduct(string productId)
        {
            var product = _storeController.GetProductById(productId);
            _storeController.PurchaseProduct(product);
        }

        private void FillCataloge()
        {
            _storeController = UnityIAPServices.StoreController();

            _storeController.OnProductsFetched += OnProductsFetched;
            _storeController.OnPurchasesFetched += OnProductsFetched;
            _storeController.OnPurchasePending += OnPurchasePending;

            ProductCatalog catalog = ProductCatalog.LoadDefaultCatalog();
            CatalogProvider catalogProvider = CodelessCatalogProvider.PopulateCatalogProvider(catalog);

            _storeController.Connect().ContinueWith(_ =>
            {
                catalogProvider.FetchProducts(
                    list => _storeController.FetchProducts(list)
                    );
            });
        }        

        private void OnProductsFetched(List<Product> products)
        {
            foreach(Product product in products)
            {
                StoreProduct storeProduct = new StoreProduct(product.definition.id, product.metadata.localizedTitle, product.type);
                ProductsList.Add(storeProduct);
            }
            _storeController.FetchPurchases();
        }
        private void OnProductsFetched(Orders orders)
        {
            foreach (var order in orders.ConfirmedOrders)
            {
                var purchasedProduct = order.Info.PurchasedProductInfo[0];

                for (int i = 0; i< ProductsList.Count; i++)
                {
                    if (string.Equals(ProductsList[i].ProductID, purchasedProduct.productId) && (ProductsList[i].ProductType == ProductType.NonConsumable))
                    {
                        GrantProduct(purchasedProduct.productId);
                    }
                }
            }
        }

        private void OnPurchasePending(Order order)
        {
            Product product = order.CartOrdered.Items().First().Product;
            string productId = product.definition.id;
            GrantProduct(productId);
        }

        private void GrantProduct(string productId)
        {
            if (string.Equals(ProductsList[0].ProductID, productId))
            {
                    _adsController.DisableAds();
            }
        }
    }
}