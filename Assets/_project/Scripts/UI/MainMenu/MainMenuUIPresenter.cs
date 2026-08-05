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
            _mainMenuUIView.OnClick.AddListener(BeginGame);
        }

        private void BeginGame()
        {
            _mainMenuUIModel.BeginGame();
        }

        public void Dispose()
        {
            _mainMenuUIView.OnClick.RemoveListener(BeginGame);
        }
    }
}