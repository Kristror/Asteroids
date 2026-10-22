using Cysharp.Threading.Tasks;
using Firebase;
using Firebase.RemoteConfig;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Utilities;
using Zenject;

namespace Configs
{
    public class FirebaseRemoteConfigsProvider: IConfigsProvider, IInitializable, IDisposable
    {
        private GameConfigs _gameConfigs;
        private FirebaseRemoteConfig _remoteConfig;
        private CancellationTokenSource _cts;
        private FirebaseAppProvider _firebaseAppProvider;

        public event Action ConfigsLoaded;

        public FirebaseRemoteConfigsProvider(FirebaseAppProvider firebaseAppProvider)
        {
            _firebaseAppProvider = firebaseAppProvider;
        }

        public void Initialize()
        {
            _cts = new CancellationTokenSource();
            _firebaseAppProvider.FirebaseReady += StartConfigsLoading;
        }

        public void Dispose()
        {
            _firebaseAppProvider.FirebaseReady -= StartConfigsLoading;

            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
                _cts?.Dispose();
            }
        }

        private void StartConfigsLoading()
        {
            if (FirebaseApp.DefaultInstance != null)
            {
                UniTask loadConfigs = FetchConfigsAsync();
            }
        }

        public GameConfigs GetGameConfigs()
        {
            return _gameConfigs;
        }

        private UniTask FetchConfigsAsync()
        {
            Task fetchTask = FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);
            UniTask uniTaskFetch = fetchTask.AsUniTask().AttachExternalCancellation(_cts.Token);
            return uniTaskFetch.ContinueWith(FetchComplete);
        }

        private void FetchComplete()
        {
            _remoteConfig = FirebaseRemoteConfig.DefaultInstance;

            var info = _remoteConfig.Info;

            if (info.LastFetchStatus != LastFetchStatus.Success)
            {
                Debug.LogError($"{nameof(FetchComplete)} was unsuccessful\n{nameof(info.LastFetchStatus)}: {info.LastFetchStatus}");
                return;
            }
            UniTask activateConfigs = _remoteConfig.ActivateAsync().AsUniTask().AttachExternalCancellation(_cts.Token);
            activateConfigs.ContinueWith(FillGameConfigs);
        }

        private void FillGameConfigs()
        {
            string dataString = _remoteConfig.GetValue(FirebaseRemoteConfigsList.GAME_SETTINGS).StringValue;
            _gameConfigs = JsonUtility.FromJson<GameConfigs>(dataString);
            ConfigsLoaded?.Invoke();
        }
    }
}