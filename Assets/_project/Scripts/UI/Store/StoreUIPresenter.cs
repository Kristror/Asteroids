using Store;
using System;
using System.Collections.Generic;

namespace UI
{
    public class StoreUIPresenter : IDisposable
    {
        private StoreUIView _storeUIView;
        private StoreUIModel _storeUIModel;
        private PurchaseController _purchaseController;
        private BuyItemButtonFactory _buyItemButtonFactory;

        private List<BuyButton> _productButtons;

        public StoreUIPresenter(StoreUIModel storeUIModel, PurchaseController purchaseController, BuyItemButtonFactory buyItemButtonFactory)
        {
            _storeUIModel = storeUIModel;
            _purchaseController = purchaseController;
            _buyItemButtonFactory = buyItemButtonFactory;
            _productButtons = new List<BuyButton>();
        }

        public void SetView(StoreUIView storeUIView)
        {
            _storeUIView = storeUIView;
            _storeUIView.BackToMenuOnClick.AddListener(BackToMenu);
            FillView();
        }

        private void FillView()
        {
            List<StoreProduct> products = _purchaseController.GetProductsList();

            foreach (var product in products)
            {
                BuyButton button = _buyItemButtonFactory.Create();
                button.transform.SetParent(_storeUIView.ContainerForItems);

                button.SetData(product.ProductID, product.ProductTitle);
                button.ButtonOnClick.AddListener( () => BuyProduct(button.ProductId));

                _productButtons.Add(button);
            }
        }
        private void ClearView()
        {
            foreach(BuyButton button in _productButtons)
            {
                button.ButtonOnClick.RemoveListener(() => BuyProduct(button.ProductId));
            }
        }

        private void BuyProduct(string productID)
        {
            _storeUIModel.BuyProduct(productID);
        }

        private void BackToMenu()
        {
            _storeUIModel.BackToMenu();
        }

        public void Dispose()
        {
            ClearView();
            _storeUIView.BackToMenuOnClick.RemoveListener(BackToMenu);
        }

    }
}