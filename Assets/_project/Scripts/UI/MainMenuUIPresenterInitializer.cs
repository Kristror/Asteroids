using Zenject;

namespace UI
{
    public class MainMenuUIPresenterInitializer : IInitializable
    {
        private MainMenuUIPresenter _mainMenuUIPresenter;
        private MainMenuUIViewFactory _mainMenuUIViewFactory;

        public MainMenuUIPresenterInitializer(MainMenuUIPresenter mainMenuUIPresenter, MainMenuUIViewFactory mainMenuUIViewFactory)
        {
            _mainMenuUIPresenter = mainMenuUIPresenter;
            _mainMenuUIViewFactory = mainMenuUIViewFactory;
        }

        public void Initialize() 
        {
            MainMenuUIView mainMenuUIView = _mainMenuUIViewFactory.Create();
            _mainMenuUIPresenter.SetView(mainMenuUIView);
        }
    }
}