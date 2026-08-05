using Utilities;

namespace UI
{
    public class MainMenuUIModel
    {

        private LoadingController _loadingController;

        public MainMenuUIModel(LoadingController loadingController)
        {
            _loadingController = loadingController;
        }

        public void BeginGame()
        {
           _loadingController.LoadGame();
        }
    }
}