using UnityEngine.Purchasing;

namespace Store
{
    public class StoreProduct 
    {
        public string ProductID;
        public string ProductTitle;
        public ProductType ProductType;

        public StoreProduct(string productID, string productTitle, ProductType productType)
        {
            ProductID = productID;
            ProductTitle = productTitle;
            ProductType = productType;
        }
    }
}