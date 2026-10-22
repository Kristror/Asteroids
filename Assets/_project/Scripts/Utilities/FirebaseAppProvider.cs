using Cysharp.Threading.Tasks;
using Firebase;
using System;
using Zenject;

namespace Utilities
{
    public class FirebaseAppProvider : IInitializable, IDisposable
    {
        public event Action FirebaseReady;

        public void Initialize()
        {
            StartFirebase();
        }

        public void Dispose()
        {
            FirebaseApp.DefaultInstance?.Dispose();
        }

        private void StartFirebase()
        {
            UniTask firebaseCheck = FirebaseApp.CheckAndFixDependenciesAsync().AsUniTask();
            firebaseCheck.ContinueWith(FirebaseInitialized);
        }

        private void FirebaseInitialized()
        {
                FirebaseReady?.Invoke();
        }
    }
}