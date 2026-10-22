using System;

namespace UI
{
    public class MainMenuUIPresenter : IDisposable
    {
        private MainMenuUIModel _mainMenuUIModel;
        private MainMenuUIView _mainMenuUIView;

        public MainMenuUIPresenter(MainMenuUIModel model)
        {
            _mainMenuUIModel = model;
        }

        public void SetView(MainMenuUIView view)
        {
            _mainMenuUIView = view;
            _mainMenuUIView.StartButtonOnClick.AddListener(BeginGame);
            _mainMenuUIView.StoreButtonOnClick.AddListener(OpenStore);
        }

        private void BeginGame()
        {
            _mainMenuUIModel.BeginGame();
        }

        private void OpenStore()
        {
            _mainMenuUIModel.OpenStore();
        }

        public void Dispose()
        {
            _mainMenuUIView.StartButtonOnClick.RemoveListener(BeginGame);
            _mainMenuUIView.StoreButtonOnClick.RemoveListener(OpenStore);
        }
    }
}