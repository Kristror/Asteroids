using Cysharp.Threading.Tasks;
using Firebase;
using Firebase.RemoteConfig;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Configs
{
    public class FirebaseRemoteConfigsProvider: IConfigsProvider, IInitializable, IDisposable
    {
        private GameConfigs _gameConfigs;
        private FirebaseRemoteConfig _remoteConfig;
        private CancellationTokenSource _cts;

        public event Action ConfigsLoaded;

        public void Initialize()
        {
            _cts = new CancellationTokenSource();
            StartConfigsLoading();
        }

        private void StartConfigsLoading()
        {
            if (FirebaseApp.DefaultInstance != null)
            {
                UniTask loadConfigs = FetchConfigsAsync();
            }
            else
            {
                UniTask startFirebase = FirebaseApp.CheckAndFixDependenciesAsync().AsUniTask();
                UniTask loadConfigs = startFirebase.ContinueWith(FetchConfigsAsync);
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

        public void Dispose()
        {
            FirebaseApp.DefaultInstance?.Dispose();

            if (_cts != null && !_cts.IsCancellationRequested)
            {
                _cts.Cancel();
                _cts?.Dispose();
            }
        }
    }
}