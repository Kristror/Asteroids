using AssetLoading;
using System;
using UnityEditor;
using UnityEngine;
using Utilites;

namespace UI
{
    public class MainMenuUIModel
    {
        public event Action StartGame;

        private AssetsProvider _assetsProvider;
        private SceneLoader _sceneLoader;

        public MainMenuUIModel(AssetsProvider assetsProvider, SceneLoader sceneLoader)
        {
            _assetsProvider = assetsProvider;
            _sceneLoader = sceneLoader;

            StartGame += Start;
        }

        public void BeginGame()
        {
            StartGame?.Invoke();
        }

        private async void Start()
        {
            await _assetsProvider.LoadGameAssets();

            _sceneLoader.LoadGame();
        }
    }
}