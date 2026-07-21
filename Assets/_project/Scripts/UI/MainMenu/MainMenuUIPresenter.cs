using System;

namespace UI
{
    public class MainMenuUIPresenter
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
            _mainMenuUIView.OnClick.AddListener(BeginGame);
        }

        public void SubscribeToStartGame(Action func)
        {
            _mainMenuUIModel.StartGame += func;
        }

        public void UnSubscribeToStartGame(Action func)
        {
            _mainMenuUIModel.StartGame -= func;
        }

        private void BeginGame()
        {
            _mainMenuUIModel.BeginGame();
        }

        public void Dispose()
        {
            _mainMenuUIView.OnClick.RemoveAllListeners();
        }
    }
}