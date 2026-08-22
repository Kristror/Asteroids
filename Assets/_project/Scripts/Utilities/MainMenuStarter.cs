using UnityEngine;
using Zenject;

namespace Utilities.AssetLoading
{
    public class MainMenuStarter : MonoBehaviour
    {
        private LoadingController _loadingController;
        
        [Inject]
        private void Construct(LoadingController loadingController)
        {
            _loadingController = loadingController;
        }

        private void Start()
        {
            _loadingController.LoadMainMenu();
        }
    }
}