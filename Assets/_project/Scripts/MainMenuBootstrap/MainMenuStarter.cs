using UnityEngine;
using Utilities;
using Zenject;

namespace MainMenuBootstrap
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