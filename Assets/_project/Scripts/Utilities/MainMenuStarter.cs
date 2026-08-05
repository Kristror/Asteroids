using UnityEngine;
using Zenject;

namespace Utilities.AssetLoading
{
    public class MainMenuStarter : MonoBehaviour
    {
        [Inject] private LoadingController _loadingController; 

        private void Start()
        {
            _loadingController.LoadMainMenu();
        }
    }
}