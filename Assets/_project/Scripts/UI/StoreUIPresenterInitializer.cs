using Zenject;

namespace UI
{
    public class StoreUIPresenterInitializer : IInitializable
    {
        private StoreUIPresenter _storeUIPresenter;
        private StoreUIViewFactory _StoreUIViewFactory;

        private StoreUIPresenterInitializer(StoreUIPresenter storeUIPresenter, StoreUIViewFactory storeUIViewFactory)
        {
            _storeUIPresenter = storeUIPresenter;
            _StoreUIViewFactory = storeUIViewFactory;
        }

        public void Initialize() 
        {
            StoreUIView storeUIView = _StoreUIViewFactory.Create();
            _storeUIPresenter.SetView(storeUIView);
        }
    }
}